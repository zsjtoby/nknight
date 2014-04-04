//
// created this abstraction class which abstracts all security related code; implemented its
// SecurityPrincipal and UserIdentiy
// Added RestoreSecurityPrincipal and the custom RetrieveSecurityException exception
//
using System;
using System.Threading;
using System.Collections;
using System.Security;
using System.Security.Policy;
using System.Security.Principal;
using System.Security.Permissions;
using System.Resources;
using System.Reflection;
using System.Globalization;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using nKnight.RBACD.DataLayer;

namespace nKnight
{
    namespace RBAC.SecurityLayer
    {
        /// <summary>
        /// throw our custom security exception so the caller can catch any exception associated with
        /// our security classes
        /// </summary>
        [Serializable]
        public class RetrieveSecurityException : ApplicationException
        {
            /// <summary>
            /// create a custom constructor which takes a exception message and then passes it along
            /// to the base class
            /// </summary>
            /// <param name="ExceptioMessage">the message of the excpetion</param>
            public RetrieveSecurityException(string ExceptionMessage)
                : base(ExceptionMessage)
            {
            }
        }

        /// <summary>
        /// encapsulates the access to resources we need in this namespace
        /// </summary>
        class Resources
        {
            private static string BaseResourceName = "RetrieveSecurity.Resources";

            /// <summary>
            /// create a private constructor which prevents an object of this class to be instantiated
            /// because all the methods are staticanyway
            /// </summary>
            private Resources()
            {
            }

            /// <summary>
            /// reads a string from the resource associated with this assembly and then returns it
            /// </summary>
            /// <param name="ResourceStringName">the name of the string to read</param>
            /// <returns>returns the string</returns>
            public static string GetString(string ResourceStringName)
            {
                ResourceManager ResourceMngr = new ResourceManager(BaseResourceName, Assembly.GetExecutingAssembly());

                // get the string from the resource and return it
                return ResourceMngr.GetString(ResourceStringName);
            }
        }

        /// <summary>
        /// creates the IPrincipal which will be associated with the current thread and all the
        /// future threads in this app domain; this IPrincipal will be based of the security 
        /// information we pass along and which has been read out of the database after the 
        /// user logged on
        /// </summary>
        public class SecurityPrincipal : IPrincipal
        {

            private static string CanNotCreateClass = "CanNotCreateClass";
            /// <summary>
            ///  For checking that RBAC initialized or not
            /// </summary>
            public static bool IsRBACInitialized = false;
            /// <summary>
            /// For checking that RBAC has been authenticated by a valid user and password or not
            /// </summary>
            public static bool IsRBACAuthenticated = false;
            // stores the list of security rights the user belongs too
            static Hashtable SecurityGroups;

            // stores the list of security rights the user has
            static Hashtable SecurityRights;

            // the user identity we create and associate with this IPrincipal
            static UserIdentity TheUserIdentity;

            /// <summary>
            /// Private constructor 
            /// </summary>
            private SecurityPrincipal() { }


            /// <summary>
            /// marks the constructor private so only SetSecurityPrincipal can instantiate an
            /// object of this class
            /// </summary>
            /// <param name="SecurityGroups">the list of security groups the user belongs too</param>
            /// <param name="SecurityRights">the list of security rights the user has</param>
            /// <param name="UserInfo">list of information we have about the user itself</param>
            private static SecurityPrincipal SetSecurityValues(Hashtable pSecurityGroups, Hashtable pSecurityRights, Hashtable pUserInfo)
            {
                SecurityGroups = pSecurityGroups;
                SecurityRights = pSecurityRights;

                // creates the IIdentity for the user and associates it with this IPrincipal
                TheUserIdentity = UserIdentity.CreateUserIdentity(pUserInfo);
                return new SecurityPrincipal();
            }

            /// <summary>
            /// creates a security principal and returns it to the caller
            /// </summary>
            /// <param name="SecurityGroups">the list of security groups the user belongs too</param>
            /// <param name="SecurityRights">the list of security rights the user has</param>
            /// <param name="UserInfo">list of information we have about the user itself</param>
            /// <returns>the new security principal created</returns>
            public static SecurityPrincipal CreatePrincipal(Hashtable SecurityGroups, Hashtable SecurityRights, Hashtable UserInfo)
            {
                return SetSecurityValues(SecurityGroups, SecurityRights, UserInfo);
            }

            /// <summary>
            /// Initializes the security system by passing user name and password
            /// </summary>
            /// <param name=UserName></param>
            /// <param name=Password></param>
            /// <returns>yes/ no</returns>
            public static bool InitSecuritySystem(DataLayer pRbacD, string UserName, string Password)
            {
                Hashtable SecurityGroups = null;
                Hashtable SecurityRights = null;
                Hashtable UserInfo = null;
                List<User> uInfo = new List<User>();
                if (pRbacD != null)
                {
                    uInfo = pRbacD.RetrieveUsers(); //Retrieve all the user list from datalayer
                    string uId = CheckUserNameAndPassword(UserName, Password, uInfo);
                    if (uId != string.Empty)
                    {
                        SecurityGroups = pRbacD.RetrieveUserSecurityGroups(uId); //if (SecurityGroups.Count == 0) { throw new RetrieveSecurityException("Security groups not found"); }
                        SecurityRights = pRbacD.RetrieveUserSecurityRights(uId); //if (SecurityRights.Count == 0) { throw new RetrieveSecurityException("Security rights not found"); }
                        UserInfo = pRbacD.RetrieveUserInformation(uId); //if (UserInfo.Count == 0) { throw new RetrieveSecurityException("User information not found"); }
                        IPrincipal ip = SetSecurityPrincipal(SecurityGroups, SecurityRights, UserInfo); //if (ip == null) { throw new RetrieveSecurityException("Error while set the security principal"); }
                        IsRBACAuthenticated = true;
                        IsRBACInitialized = true;
                        return true;
                    }
                    else { return false; }
                }
                else { return false; }
            }

            /// <summary>
            /// Check user name and password from the user list, returned from the datalayer
            /// </summary>
            /// <param name="UserName"></param>
            /// <param name="Password"></param>
            /// <returns></returns>
            private static string CheckUserNameAndPassword(string UserName, string pPassword, List<User> puInfo)
            {
                string uId = string.Empty;
                if (puInfo != null)
                {
                    foreach (User u in puInfo)
                    {
                        if ((u.UserName == UserName) && (u.Password == pPassword))
                        {
                            uId = u.UserId;
                            break;
                        }
                        else { uId = string.Empty; }
                    }
                }
                else { uId = string.Empty; }
                return uId;
            }

            /// <summary>
            /// switches the current security principal to our custom security principal which works
            /// with the security information read from the database and passed along here
            /// </summary>
            /// <param name="SecurityGroups">the list of secuiryt groups the user belongs too</param>
            /// <param name="SecurityRights">the list of security rights the user has</param>
            /// <param name="UserInfo">list of information we have about the user itself</param>
            /// <returns>returns the current IPrincipal object so it can be restored after a log off of the user; returns null if we don't switch the security principal</returns>
            private static IPrincipal SetSecurityPrincipal(Hashtable SecurityGroups, Hashtable SecurityRights, Hashtable UserInfo)
            {
                // set that we want to use authentication within the current app-domain; this means
                // a thread will have a IPrincipal associated which is then used by the .NET
                // security classes when checking role based security
                AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);

                // we switch to the new security principal only if we didn't do so already; this
                // protects us from the consumer calling this method multiple times
                if (!(Thread.CurrentPrincipal is SecurityPrincipal))
                {
                    // create a new instance of the security principal which we can do only within 
                    // a class memebr as we marked the constructor private
                    SecurityPrincipal TheSecurityPrincipal = SetSecurityValues(SecurityGroups, SecurityRights, UserInfo);

                    // get a reference to the current security principal so the caller can keep hold of it
                    IPrincipal CurrentSecurityPrincipal = Thread.CurrentPrincipal;

                    // set the security principal for the current thread to the newly created one
                    Thread.CurrentPrincipal = TheSecurityPrincipal;

                    // return the current security principal;
                    return CurrentSecurityPrincipal;
                }

                // return null if we don't switch the security principal
                else
                    return null;
            }

            /// <summary>
            /// restores the original IPrincipal; should be called after the user is logged off
            /// </summary>
            /// <param name="OriginalPrincipal">pass along the original IPrincipal you get returned from SetSecurityPrincipal</param>
            public static void RestoreSecurityPrincipal(IPrincipal OriginalPrincipal)
            {
                // set the original IPrincipal for this thread;
                Thread.CurrentPrincipal = OriginalPrincipal;
            }

            /// <summary>
            /// retrieves the IIdentity of the authenticated user; this provides information
            /// of the user itself; 
            /// </summary>
            public IIdentity Identity
            {
                get
                {
                    return TheUserIdentity;
                }
            }

            /// <summary>
            /// checks whether the user belongs to the requested role; this method checks whether
            /// the role is listed in the security groups hash-table for this user
            /// </summary>
            /// <param name="Role"></param>
            /// <returns></returns>

            public bool IsInRole(string Role)
            {
                return SecurityGroups.ContainsValue(Role);
            }

            /// <summary>
            /// checks whether the user has the permission 
            /// </summary>
            /// <param name="Permission">the specific permission to check for</param>
            /// <returns></returns>
            //[assembly:InternalsVisibleTo("RBACD,Publickey = 0024000004800000940000000602000000240000525341310004000001000100d5d4c03e7b683369352ee525d7c907528e77dc4b6b1c83f1b6e26d456caa441e1f0e674b3ff85e0746b46b35c54cd01e12b11ca70166a65e413d845ed859a285176889d0eb95d1d7f375a5bf3c0b1ce4d47967ccb2c0478a36d87cb3104ed6c074bbb464e4ea22895c37c7fe3994791ae7ad1f30f8adb4cee4afd75e6703add3")]
            public static bool HasPermission(string Permission)
            {
                bool has = SecurityRights.ContainsValue(Permission);
                return has;
            }
        }

        /// <summary>
        /// creates the IIdentity which will be associated with a IPrincipal and provides all the
        /// information about the authenticated user itself; this IIdentity is based on the 
        /// information passed along and which has been read out of the database after the 
        /// user logged on
        /// </summary>
        public class UserIdentity : IIdentity
        {
            private static string UserNameKey = "UserName";
            private static string CanNotCreateClass = "CanNotCreateClass";

            // the authentication type for us is always database
            private static string AuthenticationTypeString = "Database";

            // hash table with all the user info we have
            private Hashtable UserInfo;

            /// <summary>
            /// marks the constructor private so only CreateUserIdentity can create an instance of this
            /// class; throw an exception as we only allow a constructor which takes the hashtable with
            /// the user info
            /// </summary>
            private UserIdentity()
            {
                throw new RetrieveSecurityException(Resources.GetString(CanNotCreateClass));
            }

            /// <summary>
            /// marks the constructor private so only CreateUserIdentity can create an instance of this
            /// class; 
            /// </summary>
            /// <param name="UserInfo">hash table of the user info we read from the database</param>
            private UserIdentity(Hashtable UserInfo)
            {
                this.UserInfo = UserInfo;
            }

            /// <summary>
            /// creates an instance of the UserIdentity object which represents the authenticated user
            /// and is then associated with the IPrinicpal object; only this method can create an 
            /// instance of this class
            /// </summary>
            /// <param name="UserInfo">hashtable with all the user info we have read from the DB</param>
            /// <returns>returns the IIdentity object</returns>
            public static UserIdentity CreateUserIdentity(Hashtable UserInfo)
            {
                return new UserIdentity(UserInfo);
            }

            /// <summary>
            /// returns the authentication type used to identify the user; in our case it has been
            /// database authentication
            /// </summary>
            public string AuthenticationType
            {
                get
                {
                    return AuthenticationTypeString;
                }
            }

            /// <summary>
            /// returns whether the user has been authenticated or not; we always assume that the user
            /// has been authenticated before the IPrincipal and IIdentity are created; so we always
            /// return true
            /// </summary>
            public bool IsAuthenticated
            {
                get
                {
                    return true;
                }
            }

            /// <summary>
            /// returns the name of the user this IIdentity represents; is passed along when the IIdentiy
            /// object is created
            /// </summary>
            public string Name
            {
                get
                {
                    return Convert.ToString(UserInfo[UserNameKey], CultureInfo.InvariantCulture).Trim();
                }
            }

            /// <summary>
            /// returns the names of all the properties this IIdentiy object supports
            /// </summary>
            /// <returns>returns a array of property names</returns>
            public string[] GetPropertyNames()
            {
                // create a array of strings which will store a list of all keys
                string[] PropertyNames = new string[UserInfo.Count];
                int Count = 0;

                // loop through all the keys in the hash-table and store its name in the property name array
                foreach (object Key in UserInfo.Keys)
                    PropertyNames[Count++] = (string)Key;

                // return the array of keys to the caller
                return PropertyNames;
            }

            /// <summary>
            /// returns the requested property value
            /// </summary>
            /// <param name="PropertyName">the name of the property</param>
            /// <returns>returns the value of the proeprty</returns>
            public string GetProperty(string PropertyName)
            {
                return Convert.ToString(UserInfo[PropertyName], CultureInfo.InvariantCulture);
            }

            /// <summary>
            /// sets a value of a property
            /// </summary>
            /// <param name="PropertyName">the name of the property</param>
            /// <param name="PropertyValue">the value of the property</param>
            public void SetProperty(string PropertyName, string PropertyValue)
            {
                UserInfo[PropertyName] = PropertyValue;
            }
        }
    }
}