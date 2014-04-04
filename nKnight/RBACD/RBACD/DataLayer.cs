//
// Created: 1/31/03, Klaus Salchner
// created this abstraction class which abstracts all data access related code; implemented its
// RetrieveSecurityInformation, CheckuserNameAndPassword and the basic data provider logic
//
// Updated: 2/1/03, Klaus Salchner
// Added RetrieveUserInformation
//
using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Configuration;
using System.Globalization;
using System.Resources;
using System.Reflection;
using System.Collections;
using System.Security.Principal;
using System.Collections.Generic;

namespace nKnight.RBACD.DataLayer
{
	/// <summary>
	/// define our custom exception we are throwing whenever we miss config data or run into any 
	/// other issues in the DataLayer class
	/// </summary>
	[Serializable]
	public class DataLayerException : ApplicationException
	{
		/// <summary>
		/// we need to provide our own constructor but we just pass on the message to the base constructor 
		/// </summary>
		/// <param name="ErrorMessage"></param>
		public DataLayerException(string ErrorMessage) : base (ErrorMessage)
		{
		}
	}

    /// <summary>
    /// Trnasfer all the user related info to the calling class when the username and password validated
    /// </summary>
    [Serializable]
    public class User
    {
        public string UserId{get;set;} //User id
        public string UserName{get;set;} //User Name
        public string Password { get; set; } //User Password
    }

	/// <summary>
	/// the data layer class abstracts all data-base and resource file interactions from the
	/// rest of the code
	/// </summary>
	public sealed class DataLayer
	{
		private static string DbConnectionString = "ConnectionString";
		private static string DatabaseTypeString = "DatabaseType";
		private static string SqlCheckUserNameAndPassword = "SqlCheckUserNameAndPassword";
		private static string MissingConnectionString = "MissingConnectionString";
		private static string MissingSqlString = "MissingSqlString";
		private static string MissingParamString = "MissingParamString";
		private static string RecourceBaseName = "RetrieveSecurity.Resources";
		private static string DataAccessException = "DataAccessException";
		private static string UserNameParamName = "UserNameParamName";
		private static string PasswordParamName = "PasswordParamName";
		private static string ListOfSecurityGroups = "ListOfSecurityGroups";
		private static string ListOfSecurityRights = "ListOfSecurityRights";
		private static string UserIdParamName = "UserIdParamName";
		private static string ErrorReadingSecurityGroups = "ErrorReadingSecurityGroups";
		private static string ErrorReadingSecurityRights = "ErrorReadingSecurityRights";
		private static string UserInformation = "UserInformation";
		private static string ErrorReadingUserInfo = "ErrorReadingUserInfo";
		private static string UserNameKey = "UserName";
		private static string FirstNameKey = "FirstName";
		private static string LastNameKey = "LastName";
        private IDbConnection DbConnection;

        // Connection object should be sent by the application programmer
        /// <summary>
        /// define the possible database types we support; drives which data provider will be
        /// used
        /// </summary>
        public enum DatabaseType
        {
            Sql = 1,
            Oracle,
            MySql
        }

		/// <summary>
		/// makes the constructor private so we can't instantiate an object of this
		/// class; because all the memebers are static
		/// </summary>
		public DataLayer(IDbConnection pCon,DatabaseType pDbType)
		{
            DbConnection = pCon;
            if (DbConnection.State == ConnectionState.Open)
            {
                this.DbConnection = pCon;
                if (!InitRBACDSystem(pDbType)) { throw new Exception(); } //throw error while exception raised during database related operation
            }
            else { throw new Exception(); }
		}

		/// <summary>
		/// get the request resource string from the resource file
		/// </summary>
		/// <param name="StringResourceName">the string name</param>
		/// <returns>the string requested</returns>
		public static string GetString(string ResourceName)
		{
			// get the resource manager which has access to the resource table
			ResourceManager Resources = new ResourceManager(RecourceBaseName,Assembly.GetExecutingAssembly());

			// retrieve the requested string and return it
			return Resources.GetString(ResourceName,CultureInfo.CurrentUICulture);
		}

         
		/// <summary>
		/// create a command object and set the SQL statement we want to execute
		/// </summary>
		/// <param name="DbConnection">gets the database connection to use</param>
		/// <param name="ConfigSettingName">the name of the config setting to read the SQL statement from</param>
		/// <returns>returns a valid command object</returns>
		private static IDbCommand CreateCommandObject(IDbConnection DbConnection, string pSqlQuery)
		{
			// create a command object which we can use to check for the exitence of the username & pwd
			IDbCommand DbCommand = DbConnection.CreateCommand();
            DbCommand.CommandText = pSqlQuery;
			DbCommand.CommandType = CommandType.Text;

			// check that we have a valid Sql statement to execute
			if ((DbCommand.CommandText == null) || (DbCommand.CommandText.Length <= 0))
				throw new DataLayerException(GetString(MissingSqlString));

			// returns the command object
			return DbCommand;
		}
        
		/// <summary>
		/// create a new data parameter and add it to the command object
		/// </summary>
		/// <param name="DbCommand">the command object we already created before</param>
		/// <param name="ConfigSettingName">the name of the config setting to read the param name from</param>
		/// <returns></returns>
		private static IDataParameter AddParameter(IDbCommand DbCommand,string pParameterName,string Value)
		{
			// add the username to the Sql 
			IDbDataParameter DbParam = DbCommand.CreateParameter();
			DbParam.ParameterName = pParameterName;
			DbParam.Value = Value;
			DbCommand.Parameters.Add(DbParam);

			// check that we have a valid parameter name to execute
			if ((DbParam.ParameterName == null) || (DbParam.ParameterName.Length <= 0))
				throw new DataLayerException(GetString(MissingParamString));

			// returns the Db param we created so it can be further manipulated
			return DbParam;
		}
        
        /// <summary>
        /// Initalize the RBACD system for all database operations
        /// </summary>
        /// <returns>returns true if all the operations are successfull</returns>
        private bool InitRBACDSystem(DatabaseType pDbType)
        {
            RBACD.DataLayer.iDataOperation iMysqlData = null;
            switch (pDbType)
            {
                case DatabaseType.MySql:
                    {
                        iMysqlData = new RBACD.DataLayer.MySqlDataOperation();
                        return iMysqlData.InitializeDatabase(DbConnection);
                    }
                default:
                    {
                        return false;
                    }
            }
        }

		/// <summary>
		/// Retrieve all the user info from user table
		/// </summary>
		/// <returns>Returns list of user information</returns>
    //    [System.Security.Permissions.StrongNameIdentityPermission(
    //System.Security.Permissions.SecurityAction.LinkDemand,PublicKey = "0024000004800000940000000602000000240000525341310004000001000100d5d4c03e7b683369352ee525d7c907528e77dc4b6b1c83f1b6e26d456caa441e1f0e674b3ff85e0746b46b35c54cd01e12b11ca70166a65e413d845ed859a285176889d0eb95d1d7f375a5bf3c0b1ce4d47967ccb2c0478a36d87cb3104ed6c074bbb464e4ea22895c37c7fe3994791ae7ad1f30f8adb4cee4afd75e6703add3")]
        public List<User> RetrieveUsers()
		{
			IDataReader ReturnValue;
            List<User> uInfo = new List<User>();

			// create a command object which we can use to check for the exitence of the username & pwd
            IDbCommand DbCommand = CreateCommandObject(DbConnection, "Select UserId,username,password from Users");

			try
			{
				// open the database, query for the username and password
				ReturnValue = DbCommand.ExecuteReader();
			}

			// we had issue retrieving the user name and password so we throw a custom exception
			// to tell the caller that we failed to check
			catch (Exception e)
			{
				throw new DataLayerException(GetString(DataAccessException));
			}

			// if the return value from ExecuteScalar is null then we did not find the username & password
			if (ReturnValue != null)
			{
                while (ReturnValue.Read())
                {
                    User u = new User();
                    u.UserId = ReturnValue[0].ToString();
                    u.UserName = ReturnValue[1].ToString();
                    u.Password = ReturnValue[2].ToString();
                    uInfo.Add(u);
                }
			}
            return uInfo;
		}

		/// <summary>
		/// delegate which can be used to pass along to ReadValuesIntoHashtable; if a delegate is provided
		/// then it is called otherwise ReadValuesIntoHashtable implements a default behavior how to add
		/// information to the NameValues hash-table
		/// </summary>
		private delegate void AddRecordInfo(Hashtable NameValues,IDataReader DataReader);

		/// <summary>
		/// read the data by executing the command object we pass on and then read all the data into a
		/// hash-table we return; first column is always the ID and second always the Name; the ID is
		/// used as the key and the Name as the value in the hash-table
		/// </summary>
		/// <param name="DbConnection">the database connection to use</param>
		/// <param name="DbCommand">the command object to use</param>
		/// <param name="ExceptionStringResourceName">the user-friendly exception; the resource string name we read</param>
		/// <returns>the hash-table with the ID/Name values; returned to the caller</returns>
		private static Hashtable ReadValuesIntoHashtable(IDbConnection DbConnection, IDbCommand DbCommand,string ExceptionStringResourceName,AddRecordInfo AddRecordInfoDelegate)
		{
			// create the empty hashtable
			Hashtable NameValues = new Hashtable();

			try
			{
				IDataReader DataReader = DbCommand.ExecuteReader();

				// now read all the information belonging to the user into a hash-table; the first column
				// contains always the ID and the second column the name; and we read it one-to-one into
				// the hashtable
				while (DataReader.Read())
				{
					// if we a delegate has been passed along then call it to add the values to the 
					// hash-table
					if (!(AddRecordInfoDelegate == null))
						AddRecordInfoDelegate(NameValues,DataReader);
					
					// otherwise implement a standard way how values are added to the hash-table
					else
                        NameValues.Add(DataReader.GetString(0), DataReader.GetString(1));	
				}
			}

			// if we run into any error reading the into, then re-throw a user-friendly exception
			catch (Exception e)
			{
				throw new DataLayerException(GetString(ExceptionStringResourceName));
			}

			// the hash-table with the info
			return NameValues;
		}

		/// <summary>
		/// reads all the security information for this user from the database; we separately return the
		/// unique list of groups the user is belonging to plus a unique list of security rights the 
		/// user has; this information is used for the IPrincipal object
		/// </summary>
		/// <param name="UserId">the user ID</param>
		/// <param name="SecurityGroups">the list of security groups</param>
    //    [System.Security.Permissions.StrongNameIdentityPermission(
    //System.Security.Permissions.SecurityAction.LinkDemand, PublicKey = "0024000004800000940000000602000000240000525341310004000001000100d5d4c03e7b683369352ee525d7c907528e77dc4b6b1c83f1b6e26d456caa441e1f0e674b3ff85e0746b46b35c54cd01e12b11ca70166a65e413d845ed859a285176889d0eb95d1d7f375a5bf3c0b1ce4d47967ccb2c0478a36d87cb3104ed6c074bbb464e4ea22895c37c7fe3994791ae7ad1f30f8adb4cee4afd75e6703add3")]
        public Hashtable RetrieveUserSecurityGroups(string UserId)
		{
            Hashtable SecurityGroups = null;
            // gets the command object to read the list of secuirty groups the user belongs too
            IDbCommand DbCommand = CreateCommandObject(DbConnection, "Select SecurityGroups.SecurityGroupID, SecurityGroups.Name from Users inner join SecurityGroupAssigns on Users.UserId = SecurityGroupAssigns.UserId inner join SecurityGroups on SecurityGroups.SecurityGroupId = SecurityGroupAssigns.SecurityGroupId group by SecurityGroups.SecurityGroupID, SecurityGroups.Name, Users.UserId having Users.UserId='" + UserId + "'");

            // add the user id to the command object
            //AddParameter(DbCommand, "@UserId", UserId);

            // reads all the security group info into a hash-table 
            SecurityGroups = ReadValuesIntoHashtable(DbConnection, DbCommand, ErrorReadingSecurityGroups, null);

            return SecurityGroups;
		}

        /// <summary>
        /// reads all the security information for this user from the database; we separately return the
        /// unique list of Rights the user is belonging to plus a unique list of security rights the 
        /// user has; this information is used for the IPrincipal object
        /// </summary>
        /// <param name="UserId">the user ID</param>
        /// <param name="SecurityGroups">the list of security rights</param>
    //    [System.Security.Permissions.StrongNameIdentityPermission(
    //System.Security.Permissions.SecurityAction.LinkDemand, PublicKey = "0024000004800000940000000602000000240000525341310004000001000100d5d4c03e7b683369352ee525d7c907528e77dc4b6b1c83f1b6e26d456caa441e1f0e674b3ff85e0746b46b35c54cd01e12b11ca70166a65e413d845ed859a285176889d0eb95d1d7f375a5bf3c0b1ce4d47967ccb2c0478a36d87cb3104ed6c074bbb464e4ea22895c37c7fe3994791ae7ad1f30f8adb4cee4afd75e6703add3")]
        public Hashtable RetrieveUserSecurityRights(string UserId)
        {
            Hashtable SecurityRights = null;
            // gets the command object to read the list of secuirty rights the user has
            IDbCommand DbCommand = CreateCommandObject(DbConnection, "Select SecurityRight.SecurityRightID, SecurityRight.SecurityRightID from Users inner join SecurityGroupAssigns on Users.UserId = SecurityGroupAssigns.UserId inner join SecurityRightAssign on SecurityGroupAssigns.SecurityGroupID = SecurityRightAssign.SecurityGroupID inner join SecurityRight on SecurityRightAssign.SecurityRightID = SecurityRight.SecurityRightID group by SecurityRight.SecurityRightID, SecurityRight.SecurityRight, Users.UserId having Users.UserId = '" + UserId + "'");

            // add the user id to the command object
            //AddParameter(DbCommand, "@UserId", Convert.ToString(UserId, CultureInfo.InvariantCulture));

            // reads all the all the security rights info into a hash-table 
            SecurityRights = ReadValuesIntoHashtable(DbConnection, DbCommand, ErrorReadingSecurityRights, null);
            return SecurityRights;
        }

		/// <summary>
		/// read the information associated with the user; this information is then used for the 
		/// IIdentity object
		/// </summary>
		/// <param name="UserId">the user id</param>
		/// <param name="UserInfo">the list of user information</param>
    //    [System.Security.Permissions.StrongNameIdentityPermission(
    //System.Security.Permissions.SecurityAction.LinkDemand, PublicKey = "0024000004800000940000000602000000240000525341310004000001000100d5d4c03e7b683369352ee525d7c907528e77dc4b6b1c83f1b6e26d456caa441e1f0e674b3ff85e0746b46b35c54cd01e12b11ca70166a65e413d845ed859a285176889d0eb95d1d7f375a5bf3c0b1ce4d47967ccb2c0478a36d87cb3104ed6c074bbb464e4ea22895c37c7fe3994791ae7ad1f30f8adb4cee4afd75e6703add3")]
        public Hashtable RetrieveUserInformation(string UserId)
		{
            Hashtable UserInfo = null;
            
            // gets a command obejct used to read all the user information associated with the user
            IDbCommand DbCommand = CreateCommandObject(DbConnection, "Select UserId,FirstName,LastName,Citizenship from Users where UserId='"+ UserId + "'");

            // add the user id to the command object
            //AddParameter(DbCommand, "@UserId", Convert.ToString(UserId, CultureInfo.InvariantCulture));

            // read all the user info into the has-table
            UserInfo = ReadValuesIntoHashtable(DbConnection, DbCommand, ErrorReadingUserInfo, new AddRecordInfo(AddUserInfoToHashtable));

            // the IIdenty object always expects a UserName entry in the hash-table so we always
            // create it here if it doesn't exist already
            if (UserInfo[UserNameKey] == null)
            {
                UserInfo[UserNameKey] = ((UserInfo[FirstNameKey] == null) ? String.Empty : UserInfo[FirstNameKey]) + " " +
                                        ((UserInfo[LastNameKey] == null) ? String.Empty : UserInfo[LastNameKey]);
            }
            return UserInfo;
		}

		/// <summary>
		/// a delagate used by RetrieveUserInformation so we can implement our custom way how we
		/// add user information to the user info hash-table
		/// </summary>
		/// <param name="NameValues"></param>
		/// <param name="DataReader"></param>
		private static void AddUserInfoToHashtable(Hashtable NameValues,IDataReader DataReader)
		{
			for (int Count=0; Count<DataReader.FieldCount; Count++)
				NameValues.Add(DataReader.GetName(Count),DataReader.GetValue(Count));
		}

        /// <summary>
        /// Get all the roles form the database.
        /// </summary>
        /// <returns>List of Rles</returns>
        public List<RBACD.DatalayerDef.sRole> GetAllRoles()
        {
            List<RBACD.DatalayerDef.sRole> sRoleList = new List<RBACD.DatalayerDef.sRole>();
            DataSet ds = new DataSet();
            string sql = string.Empty;
            try
            {
                sql = "Select securitygroupid,name,displayname from securitygroups order by name";
                IDbConnection con = this.DbConnection;
                IDbCommand dbCommand = DbConnection.CreateCommand();
                dbCommand.CommandText = sql;
                IDataReader DataReader = dbCommand.ExecuteReader();

                while (DataReader.Read())
                {
                    RBACD.DatalayerDef.sRole srole = new RBACD.DatalayerDef.sRole();
                    srole.RoleId = DataReader[0].ToString();
                    srole.RoleName = DataReader[1].ToString();
                    srole.RoleDescrition = DataReader[2].ToString();
                    sRoleList.Add(srole);
                }
                return sRoleList;
            }
            catch
            {
                return sRoleList;
            }
        }
        /// <summary>
        /// Get all the roles  the database.
        /// </summary>
        /// <returns>List of Rles</returns>
        public List<RBACD.DatalayerDef.sResource> GetAllResources()
        {
            List<RBACD.DatalayerDef.sResource> sResourceList = new List<RBACD.DatalayerDef.sResource>();
            DataSet ds = new DataSet();
            string sql = string.Empty;
            try
            {
                sql = "Select SecurityRightID,SecurityRight,SecurityDescrition,FormName from securityright order by formname,securityright";
                OdbcConnection con = (OdbcConnection)this.DbConnection;
                OdbcDataAdapter adp = new OdbcDataAdapter(sql, con);
                adp.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    RBACD.DatalayerDef.sResource sresource = new RBACD.DatalayerDef.sResource();
                    sresource.ResourceId = ds.Tables[0].Rows[i][0].ToString();
                    sresource.ResourceName = ds.Tables[0].Rows[i][1].ToString();
                    sresource.ResourceDescrition = ds.Tables[0].Rows[i][2].ToString();
                    sresource.ResourceParentName = ds.Tables[0].Rows[i][3].ToString();
                    sResourceList.Add(sresource);
                }
                return sResourceList;
            }
            catch
            {
                return sResourceList;
            }
        }

        

        

        /// <summary>
        /// Get all the resources against a specific role id
        /// </summary>
        /// <param name="pRoleId"></param>
        /// <returns></returns>
        public List<RBACD.DatalayerDef.sRoleResourceMap> GetMappedResources(string pRoleId)
        {
            List<RBACD.DatalayerDef.sRoleResourceMap> sResourceList = new List<RBACD.DatalayerDef.sRoleResourceMap>();
            DataSet ds = new DataSet();
            string sql = string.Empty;
            try
            {
                sql = "Select SecurityRightID from securityrightassign where securityGroupID='"+pRoleId+"'";
                OdbcConnection con = (OdbcConnection)this.DbConnection;
                OdbcDataAdapter adp = new OdbcDataAdapter(sql, con);
                adp.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    RBACD.DatalayerDef.sRoleResourceMap map = new RBACD.DatalayerDef.sRoleResourceMap();
                    map.ResourceId = ds.Tables[0].Rows[i][0].ToString();
                    map.RoleId = pRoleId;
                    sResourceList.Add(map);
                }
                return sResourceList;
            }
            catch
            {
                return sResourceList;
            }
        }

        /// <summary>
        /// Save resources into resource table
        /// </summary>
        /// <param name="pResource"></param>
        /// <returns></returns>
        public bool SaveResources(List<RBACD.DatalayerDef.sResource> pResource)
        {
            OdbcTransaction tran = null;
            try
            {
                OdbcConnection con = (OdbcConnection)this.DbConnection;
                OdbcCommand cmd = new OdbcCommand();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                tran = con.BeginTransaction();
                cmd.Transaction = tran;

                string sqlDelete = "delete from rbac.securityright";
                cmd.CommandText = sqlDelete;
                cmd.ExecuteNonQuery();

                foreach(RBACD.DatalayerDef.sResource fRecs in pResource)
                {
                    string sql = "insert into rbac.securityright values('" + fRecs.ResourceId + "','" + fRecs.ResourceName + "','" + fRecs.ResourceDescrition + "','"+ fRecs.ResourceParentName +"')";
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                }
                tran.Commit();
                return true;
            }
            catch
            {
                if (tran != null) { tran.Rollback(); }
                return false;
            }
        }

        /// <summary>
        /// Map resources with roles
        /// </summary>
        /// <param name="pMap"></param>
        /// <returns></returns>
        public bool MapResourcesWithRoles(List<RBACD.DatalayerDef.sRoleResourceMap> pMap)
        {
            OdbcTransaction tran = null;
            string roleId = string.Empty;
            try
            {
                OdbcConnection con = (OdbcConnection)this.DbConnection;
                OdbcCommand cmd = new OdbcCommand();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                tran = con.BeginTransaction();
                cmd.Transaction = tran;
                foreach (RBACD.DatalayerDef.sRoleResourceMap mp in pMap)
                {
                    roleId = mp.RoleId;
                }
                //First all the data will be delted against a role
                string sqlDelete = "delete from rbac.securityrightassign where SecurityGroupID='"+ roleId +"'"; 
                cmd.CommandText = sqlDelete;
                cmd.ExecuteNonQuery();
                //All the mapping related data will be stored
                foreach (RBACD.DatalayerDef.sRoleResourceMap mp in pMap)
                {
                    string sql = "insert into rbac.securityrightassign values('" + roleId + "','" + mp.ResourceId + "')";
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                }
                tran.Commit();
                return true;
            }
            catch
            {
                if (tran != null) { tran.Rollback(); }
                return false;
            }
        }
        /*
        /// <summary>
        /// Get all the user from user table
        /// </summary>
        /// <returns>DataSet</returns>
        public DataSet GetAllUser()
        {
            DataSet ds = new DataSet();
            string sql = string.Empty;
            try
            {
                sql = "SELECT * FROM users";
                OdbcConnection con = (OdbcConnection)this.DbConnection;
                OdbcDataAdapter adp = new OdbcDataAdapter(sql, con);
                adp.Fill(ds, "User");

                return ds;
            }
            catch
            {
                return ds;
            }
        }
        */

        /// <summary>
        /// Retrieve all the user from users table
        /// </summary>
        /// <returns>Returns list of User</returns>

        public List<RBACD.DatalayerDef.sUser> GetAllUser()
        {
            IDataReader ReturnValue;
            List<RBACD.DatalayerDef.sUser> userList = new List<RBACD.DatalayerDef.sUser>();

            // create a command object which we can use to get all user
            IDbCommand DbCommand = CreateCommandObject(DbConnection, "SELECT * FROM users");

            try
            {
                // open the database, query for the user
                ReturnValue = DbCommand.ExecuteReader();
            }
            catch (Exception e)
            {
                throw new DataLayerException(GetString(DataAccessException));
            }

            // if the return value is null then we did not find the user
            if (ReturnValue != null)
            {
                while (ReturnValue.Read())
                {
                    RBACD.DatalayerDef.sUser user = new RBACD.DatalayerDef.sUser();
                    user.UserId = ReturnValue[0].ToString();
                    user.UserName = ReturnValue[1].ToString();
                    user.Password = ReturnValue[2].ToString();
                    user.FirstName = ReturnValue[3].ToString();
                    user.LastName = ReturnValue[4].ToString();
                    user.Citizenship = ReturnValue[5].ToString();
                    userList.Add(user);
                }
            }
            return userList;
        }



        /// <summary>
        /// Save user information in user table from frmCreateUser form.
        /// </summary>
        /// <returns></returns>
        public bool SaveUser(RBACD.DatalayerDef.sUser userInfo)
        {
            OdbcTransaction tran = null;
            string sql = string.Empty;
            try
            {
                OdbcConnection con = (OdbcConnection)this.DbConnection;
                OdbcCommand cmd = new OdbcCommand();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                tran = con.BeginTransaction();
                cmd.Transaction = tran;

                sql = "INSERT INTO rbac.users (UserName, Password, FirstName, LastName, Citizenship) VALUES('" + userInfo.UserName + "', '" + userInfo.Password + "', '" + userInfo.FirstName + "', '" + userInfo.LastName + "', '" + userInfo.Citizenship + "')";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();

                tran.Commit();
                return true;
                
            }
            catch
            {
                if (tran != null) { tran.Rollback(); }
                return false;

            }
        }


        /// <summary>
        /// Update user information in user table from frmCreateUser form.
        /// </summary>
        /// <returns></returns>
        public bool UpdateUser(RBACD.DatalayerDef.sUser userInfo)
        {
            OdbcTransaction tran = null;
            string sql = string.Empty;
            try
            {
                OdbcConnection con = (OdbcConnection)this.DbConnection;
                OdbcCommand cmd = new OdbcCommand();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                tran = con.BeginTransaction();
                cmd.Transaction = tran;

                sql = "UPDATE rbac.users SET UserName='" + userInfo.UserName + "' , Password='" + userInfo.Password + "' , FirstName='" + userInfo.FirstName + "', LastName='" + userInfo.LastName + "', Citizenship='" + userInfo.Citizenship + "' WHERE UserId ='" + userInfo.UserId + "'";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();

                tran.Commit();
                return true;

            }
            catch
            {
                if (tran != null) { tran.Rollback(); }
                return false;

            }
        }
        

        

        /// <summary>
        /// Save Security Group information in securitygroups table from frmCreateSecurityGroups form.
        /// </summary>
        /// <returns></returns>
        public bool SaveSecurityGroups(RBACD.DatalayerDef.sSecurityGroups securityGroupInfo)
        {
            OdbcTransaction tran = null;
            string sql = string.Empty;
            try
            {
                OdbcConnection con = (OdbcConnection)this.DbConnection;
                OdbcCommand cmd = new OdbcCommand();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                tran = con.BeginTransaction();
                cmd.Transaction = tran;

                sql = "INSERT INTO rbac.securitygroups (Name, DisplayName) VALUES('" + securityGroupInfo.Name + "', '" + securityGroupInfo.DisplayName + "')";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();

                tran.Commit();
                return true;

            }
            catch
            {
                if (tran != null) { tran.Rollback(); }
                return false;

            }
        }

        /// <summary>
        /// Update Security Group information in securitygroups table from frmCreateSecurityGroup form.
        /// </summary>
        /// <returns></returns>
        public bool UpdateSecurityGroups(RBACD.DatalayerDef.sSecurityGroups securityGroupInfo)
        {
            OdbcTransaction tran = null;
            string sql = string.Empty;
            try
            {
                OdbcConnection con = (OdbcConnection)this.DbConnection;
                OdbcCommand cmd = new OdbcCommand();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                tran = con.BeginTransaction();
                cmd.Transaction = tran;

                sql = "UPDATE rbac.securitygroups SET Name='" + securityGroupInfo.Name + "' , DisplayName='" + securityGroupInfo.DisplayName + "' WHERE SecurityGroupID ='" + securityGroupInfo.SecurityGroupID + "'";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();

                tran.Commit();
                return true;

            }
            catch
            {
                if (tran != null) { tran.Rollback(); }
                return false;

            }
        }


        /// <summary>
        /// Retrieve all the Security Group info from securitygroup table
        /// </summary>
        /// <returns>Returns list of Security Group information</returns>
        public List<RBACD.DatalayerDef.sSecurityGroups> RetrieveSecurityGroup()
		{
			IDataReader ReturnValue;
            List<RBACD.DatalayerDef.sSecurityGroups> sgInfo = new List<RBACD.DatalayerDef.sSecurityGroups>();

			// create a command object which we can use to retrive security group
            IDbCommand DbCommand = CreateCommandObject(DbConnection, "Select SecurityGroupID, Name, DisplayName from securitygroups");

			try
			{
				// open the database, query for the security group
				ReturnValue = DbCommand.ExecuteReader();
			}
			catch (Exception e)
			{
				throw new DataLayerException(GetString(DataAccessException));
			}

			// if the return value is null then we did not find the security group
			if (ReturnValue != null)
			{
                while (ReturnValue.Read())
                {
                    RBACD.DatalayerDef.sSecurityGroups sg = new RBACD.DatalayerDef.sSecurityGroups();
                    sg.SecurityGroupID = ReturnValue[0].ToString();
                    sg.Name = ReturnValue[1].ToString();
                    sg.DisplayName = ReturnValue[2].ToString();
                    sgInfo.Add(sg);
                }
			}
            return sgInfo;
		}

        /// <summary>
        /// Retrieve assigned Security Group to an user from securitygroupassigns table
        /// </summary>
        /// <returns>Returns list of Security Group Assigns information</returns>
        public RBACD.DatalayerDef.sSecurityGroupAssigns RetrieveAssingedSecurityGroup(RBACD.DatalayerDef.sSecurityGroupAssigns usrScuGruAgnInfo)
        {
            IDataReader ReturnValue;
            

            // create a command object which we can use to retrive security gruoup assignment information
            IDbCommand DbCommand = CreateCommandObject(DbConnection, "Select SecurityGroupID from securitygroupassigns where UserId=" + usrScuGruAgnInfo.UserId);

            try
            {
                // open the database, query for the security group assigns
                ReturnValue = DbCommand.ExecuteReader();
            }
            catch (Exception e)
            {
                throw new DataLayerException(GetString(DataAccessException));
            }

            // if the return value is null then we did not find security group assignment information
            if (ReturnValue != null)
            {
                List<String> sgID = new List<String>();
                while (ReturnValue.Read())
                {
                    
                    sgID.Add(ReturnValue[0].ToString());

                }
                usrScuGruAgnInfo.SecurityGroupId = sgID;
            }
            return usrScuGruAgnInfo;
        }

        /// <summary>
        /// Save Security Group assignment to an User information in securitygroupassigns table from frmAssignsSecurityGroup form.
        /// </summary>
        /// <returns></returns>
        public bool SaveSecurityGroupsAssings(RBACD.DatalayerDef.sSecurityGroupAssigns usrScuGruAgnInfo)
        {
            String uId = usrScuGruAgnInfo.UserId;
            //List<String> sgID = usrScuGruAgnInfo.SecurityGroupId; 

            OdbcTransaction tran = null;
            string sql = string.Empty;
            try
            {
                OdbcConnection con = (OdbcConnection)this.DbConnection;
                OdbcCommand cmd = new OdbcCommand();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                tran = con.BeginTransaction();
                cmd.Transaction = tran;

                sql = "DELETE FROM securitygroupassigns WHERE UserId = " + uId;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();

                foreach (String sgId in usrScuGruAgnInfo.SecurityGroupId)
                {
                    sql = "INSERT INTO rbac.securitygroupassigns (UserId, SecurityGroupId) VALUES(" + uId + ", '" + sgId + "')";
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                }
                tran.Commit();
                return true;

            }
            catch
            {
                if (tran != null) { tran.Rollback(); }
                return false;

            }
        }
        



	}
}
