using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bines1
{
    public  class DataConnection
    {

        public static SqlConnection BaglantiTestEt()

        {

            string dataSource = ConfigurationManager.AppSettings["DataSource"].ToString();

            string InitialCatalog = ConfigurationManager.AppSettings["InitialCatalog"].ToString();



            SqlConnection baglanti = new SqlConnection();

            {





                baglanti.ConnectionString = string.Format(@"Data Source={0};Initial Catalog={1};Integrated Security=True", dataSource, InitialCatalog);





                if (baglanti != null)

                {

                    if (baglanti.State == ConnectionState.Closed)

                        baglanti.Open();

                    SqlConnection.ClearPool(baglanti);

                    SqlConnection.ClearAllPools();

                }

                //baglanti.Database = ""

                return baglanti;
            }
        }
    }
}
