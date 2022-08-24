using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bines1
{

    public class LoginVeriGetir

    {
        public void PullData()
        {
        List<LoginList> loginList = new List<LoginList>();
            string sqlsorgu = "select * from Login";
            using (SqlCommand cmd = new SqlCommand(sqlsorgu, DataConnection.BaglantiTestEt()))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        loginList.Add(new LoginList
                        {

                            UserName = Convert.ToString(reader["Username"]),
                            Password = Convert.ToString(reader["Password"])
                        });
                        



                            
                            
                 
                    }
                }
            }
            
        }
    }
}
