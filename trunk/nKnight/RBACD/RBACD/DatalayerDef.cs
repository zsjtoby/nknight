using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nKnight.RBACD.DatalayerDef
{
    /// <summary>
    /// Class to hold role related data
    /// </summary>
    public class sRole
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDescrition { get; set; }
    }
    /// <summary>
    /// Class to hold resource related data
    /// </summary>
    public class sResource
    {
        public string ResourceId { get; set; }
        public string ResourceName { get; set; }
        public string ResourceDescrition { get; set; }
        public string ResourceParentName { get; set; }
    }

    /// <summary>
    /// Class to hold role resource map related data
    /// </summary>
    public class sRoleResourceMap
    {
        public string RoleId { get; set; }
        public string ResourceId { get; set; }
    }


    /// <summary>
    /// Class to hold user information from frmCreateUser form.
    /// </summary>
    public class sUser
    {
        public string UserId { get; set; } //User id
        public string UserName { get; set; } //User Name
        public string Password { get; set; } //User Password
        public string FirstName { get; set; } //User First Name
        public string LastName { get; set; } //User Last Name
        public string Citizenship { get; set; } //User Citizenship Name
    }

    /// <summary>
    /// Class to hold Security Groups information from frmCreateSecurityGroups form.
    /// </summary>
    public class sSecurityGroups
    {
        public String SecurityGroupID { get; set; } //Security Group ID
        public string Name { get; set; } // Name
        public string DisplayName { get; set; } //Display Name

    }

    /// <summary>
    /// Class to hold Security Groups hold by an User Id.
    /// </summary>
    public class sSecurityGroupAssigns
    {
        public string UserId { get; set; } // User ID
        public List<String> SecurityGroupId { get; set; } // List of Assigned securitygroup to userid.
        
    }

}
