using AllAdSpy.Models;
using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllAdSpy.Classes
{
    public class SqliteDataAccess
    {
        public static List<Account> LoadAccounts()
        {

            using(IDbConnection cnn  = new SqliteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Account>("select * from Accounts",new DynamicParameters());
                return output.ToList();
            }

        }
            public static void SaveAccount(Account AccountModel)
        {

            using(IDbConnection cnn  = new SqliteConnection(LoadConnectionString()))
            {

                var output = cnn.Query<Account>("select * from Accounts",new DynamicParameters());

                cnn.Execute("insert into Accounts (Email, UserName, Password) values (@Email, @UserName, @Password)", AccountModel);
            }

        }






        public static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
