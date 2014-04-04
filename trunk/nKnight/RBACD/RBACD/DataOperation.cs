using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Odbc;

namespace nKnight.RBACD.DataLayer
{
    /// <summary>
    /// Interface for different types of database operation
    /// </summary>
    public interface iDataOperation
    {
        bool InitializeDatabase(IDbConnection pDbCon);
    }
    
    

    /// <summary>
    /// MySqlDataoperation is inherited from interface iDataOperation
    /// </summary>
    public class MySqlDataOperation: iDataOperation
    {
        /// <summary>
        /// Reset the auto increment field with 0
        /// </summary>
        /// <param name=Table Name></param>
        /// <param name=Command object></param>
        /// <returns>true or false</returns>
        private bool ResetAutoIncrementField(string pTableName,IDbCommand pCmd)
        {
            try
            {
                string sql = "ALTER TABLE " + pTableName + " AUTO_INCREMENT=0";
                pCmd.CommandText = sql;
                pCmd.ExecuteNonQuery();
                return true;
            }
            catch { return false; }
        }

        //Initializes the database by calling CreateTabes method
        public bool InitializeDatabase(IDbConnection pDbCon)
        {
            return CreateTables(pDbCon);
        }


        /// <summary>
        /// Create all the tables in the mysql database
        /// </summary>
        /// <returns>true if success and false if failed</returns>
        private bool CreateTables(IDbConnection pDbCon)
        {
            string sqlStr = null;

            //create a command object for execute all the database queries
            IDbCommand sqlCmd = new OdbcCommand();
            //Transaction begins
            IDbTransaction sqlTrans = pDbCon.BeginTransaction();
            try
            {

                //Create table security groups
                sqlStr = "CREATE TABLE if not exists securitygroups (" +
                         " SecurityGroupID int(10) NOT NULL auto_increment," +
                         " Name varchar(50) default NULL," +
                         "DisplayName varchar(50) default NULL," +
                         " PRIMARY KEY  (SecurityGroupID)" +
                          ") ENGINE=InnoDB DEFAULT CHARSET=latin1;";

                sqlCmd.CommandText = sqlStr;
                sqlCmd.Connection = pDbCon;
                sqlCmd.Transaction = sqlTrans;
                sqlCmd.ExecuteNonQuery();

                sqlStr = "select * from securitygroups";
                sqlCmd.CommandText = sqlStr;
                int i = sqlCmd.ExecuteNonQuery();
                if (i == 0)
                {
                    if (!ResetAutoIncrementField("securitygroups", sqlCmd)) { sqlTrans.Rollback(); return false; }
                    sqlStr = "INSERT INTO securitygroups(name,displayname) VALUES ('SuperAdministrator','Super Administrator')";
                    sqlCmd.CommandText = sqlStr;
                    sqlCmd.ExecuteNonQuery();
                }
                i = 0;

                sqlStr = "CREATE TABLE if not exists users (" +
                         " UserId int(10) NOT NULL auto_increment," +
                         " UserName varchar(50) default NULL," +
                         " Password varchar(50) default NULL," +
                         " FirstName varchar(50) default NULL," +
                         " LastName varchar(50) default NULL," +
                         " Citizenship varchar(50) default NULL," +
                         " PRIMARY KEY  (UserId)" +
                         " ) ENGINE=InnoDB DEFAULT CHARSET=latin1;";
                sqlCmd.CommandText = sqlStr;
                sqlCmd.ExecuteNonQuery();

                sqlStr = "select * from users";
                sqlCmd.CommandText = sqlStr;
                i = sqlCmd.ExecuteNonQuery();
                if (i == 0)
                {
                    if (!ResetAutoIncrementField("users", sqlCmd)) { sqlTrans.Rollback(); return false; }
                    sqlStr = "INSERT INTO users(username,password,firstname,lastname,citizenship) VALUES ('Admin','Admin','System','Super Administrator','India')";
                    sqlCmd.CommandText = sqlStr;
                    sqlCmd.ExecuteNonQuery();
                }
                i = 0;

                //For creating table ""
                sqlStr = "CREATE TABLE if not exists securitygroupassigns (" +
                        " AssignID int(10) NOT NULL auto_increment," +
                        " UserId int(10) default NULL," +
                        " SecurityGroupId int(10) default NULL," +
                        " PRIMARY KEY  (AssignID)," +
                        " KEY FK_SecurityGroupAssigns_SecurityGroups (SecurityGroupId)," +
                        " KEY FK_SecurityGroupAssigns_Users (UserId)," +
                        " CONSTRAINT FK_SecurityGroupAssigns_SecurityGroups FOREIGN KEY (SecurityGroupId) REFERENCES securitygroups (SecurityGroupID) ON DELETE NO ACTION ON UPDATE NO ACTION," +
                        " CONSTRAINT FK_SecurityGroupAssigns_Users FOREIGN KEY (UserId) REFERENCES users (UserId) ON DELETE NO ACTION ON UPDATE NO ACTION" +
                        " ) ENGINE=InnoDB DEFAULT CHARSET=latin1;";
                sqlCmd.CommandText = sqlStr;
                sqlCmd.ExecuteNonQuery();

                sqlStr = "select * from securitygroupassigns";
                sqlCmd.CommandText = sqlStr;
                i = sqlCmd.ExecuteNonQuery();

                //Check that the table contains data or not, if not then insert default values
                // 1 is the id of Super Administrator
                if (i == 0)
                {
                    if (!ResetAutoIncrementField("securitygroupassigns", sqlCmd)) { sqlTrans.Rollback(); return false; }
                    sqlStr = "INSERT INTO securitygroupassigns(userid,securitygroupid) VALUES ('1','1')";
                    sqlCmd.CommandText = sqlStr;
                    sqlCmd.ExecuteNonQuery();
                }
                i = 0; //initializes the counter


                sqlStr = "CREATE TABLE if not exists securityright (" +
                         "SecurityRightID varchar(50) NOT NULL," +
                         " SecurityRight varchar(50) default NULL," +
                         "SecurityDescrition varchar(200) default NULL," +
                         "FormName varchar(200) default NULL," +
                         " PRIMARY KEY  (SecurityRightID)" +
                         ") ENGINE=InnoDB DEFAULT CHARSET=latin1;";
                sqlCmd.CommandText = sqlStr;
                sqlCmd.ExecuteNonQuery();

                sqlStr = "CREATE TABLE if not exists securityrightassign (" +
                        " SecurityGroupID varchar(50) default NULL," +
                        " SecurityRightID varchar(50) default NULL," +
                        " PRIMARY KEY  (SecurityGroupID,SecurityRightID)" +
                        " ) ENGINE=InnoDB DEFAULT CHARSET=latin1;";
                sqlCmd.CommandText = sqlStr;
                sqlCmd.ExecuteNonQuery();

                
                sqlTrans.Commit();
                return true;
            }
            catch(Exception ex)
            {
                sqlTrans.Rollback();
                return false;
            }
        }
    }
}
