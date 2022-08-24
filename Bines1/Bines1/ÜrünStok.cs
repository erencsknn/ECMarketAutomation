using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bines1
{
    public partial class ÜrünStok : Form
    {
       



        public ÜrünStok()
        {
            InitializeComponent();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ÜrünStok_Load(object sender, EventArgs e)
        {
            
            List<UrunStokList> ustoklist = new List<UrunStokList>();
            string sqlsorgu = "Select UrunBarkod, UrunAd,UrunAlısFiyatı, UrunSatısFiyatı, UrunStokAdet from UrunStokTable";
            using (SqlCommand cmd = new SqlCommand(sqlsorgu, DataConnection.BaglantiTestEt()))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ustoklist.Add(new UrunStokList
                        {
                          
                            UrunBarkod = Convert.ToString(reader["UrunBarkod"]),
                            UrunAd = Convert.ToString(reader["UrunAd"]),
                            UrunAlısFiyatı = Convert.ToDecimal(reader["UrunAlısFiyatı"]),
                            UrunSatısFiyatı = Convert.ToDecimal(reader["UrunSatısFiyatı"]),
                            UrunStokAdet = Convert.ToInt32(reader["UrunStokAdet"])
                        });


                    }
                }
            }
            dataGridView1.DataSource = ustoklist;

        }
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = ("INSERT INTO [UrunStokTable](UrunBarkod,UrunAd,UrunAlısFiyatı,UrunSatısFiyatı,UrunStokAdet) VALUES (@urunBarkod,@urunAd,@urunAlıs,@urunSatıs,@urunStokAdet )");
            using (SqlCommand cmd = new SqlCommand(sorgu, DataConnection.BaglantiTestEt()))
            {
                cmd.Parameters.AddWithValue("@urunBarkod", SqlDbType.VarChar).Value = barkodtxt.Text;
                cmd.Parameters.AddWithValue("@urunAd", SqlDbType.VarChar).Value = urunadtxt.Text;
                cmd.Parameters.AddWithValue("@urunAlıs", SqlDbType.Decimal).Value = urunalıstxt.Text;
                cmd.Parameters.AddWithValue("@urunSatıs", SqlDbType.Decimal).Value = urunsatıstxt.Text;
                cmd.Parameters.AddWithValue("@urunStokAdet", SqlDbType.Int).Value = urunstokadettxt.Text;
                cmd.ExecuteReader();



            }
            
            MessageBox.Show(" Kayıt Başarıyla Eklendi !");
            
        }

        private void button4_Click(object sender, EventArgs e)
        {

            //string sorgu = "DELETE  FROM UrunStokTable WHERE UrunBarkod = @urunBarkod OR UrunAd=@urunAd";
            //using (SqlCommand cmd = new SqlCommand(sorgu, DataConnection.BaglantiTestEt()))
            //{

            //    cmd.Parameters.AddWithValue("@urunBarkod", Convert.ToString(barkodtxt.Text));
            //    cmd.Parameters.AddWithValue("@urunAd", Convert.ToString(urunadtxt.Text));
            //    SqlDataReader reader = cmd.ExecuteReader();
            //    {
            //        MessageBox.Show("Kayıt Başarıyla Silindi");

            //    }


            //}


            string sorgu = "SELECT * FROM UrunStokTable WHERE UrunBarkod = @urunBarkod ";
            using (SqlCommand cmd = new SqlCommand(sorgu, DataConnection.BaglantiTestEt()))
            {
                cmd.Parameters.AddWithValue("@urunBarkod", Convert.ToString(barkodtxt.Text));
                cmd.Parameters.AddWithValue("@urunAd", Convert.ToString(urunadtxt.Text));
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string sorgu2 = "DELETE  FROM UrunStokTable WHERE UrunBarkod = @urunBarkod";
                    using (SqlCommand cmd2 = new SqlCommand(sorgu2, DataConnection.BaglantiTestEt()))
                    {

                        cmd2.Parameters.AddWithValue("@urunBarkod", Convert.ToString(barkodtxt.Text));
                        cmd2.Parameters.AddWithValue("@urunAd", Convert.ToString(urunadtxt.Text));
                        SqlDataReader reader2 = cmd2.ExecuteReader();
                        {
                            MessageBox.Show("Kayıt Başarıyla Silindi");
                            

                        }


                    }

                }
                else
                {
                    MessageBox.Show("Ürün Bulunamadı");

                }
            }





        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sorgu = "UPDATE UrunStokTable SET  UrunBarkod = @urunBarkod, UrunAd=@urunAd, UrunAlısFiyatı=@urunAlıs,UrunSatısFiyatı = @urunSatıs, UrunStokAdet = @urunStokAdet WHERE  UrunBarkod = @urunBarkod ";
            using (SqlCommand cmd = new SqlCommand(sorgu, DataConnection.BaglantiTestEt()))
            {
                cmd.Parameters.AddWithValue("@urunBarkod", Convert.ToString(barkodtxt.Text));
                cmd.Parameters.AddWithValue("@urunAd", Convert.ToString(urunadtxt.Text));
                cmd.Parameters.AddWithValue("@urunAlıs", Convert.ToString(urunalıstxt.Text));
                cmd.Parameters.AddWithValue("@urunSatıs", Convert.ToString(urunsatıstxt.Text));
                cmd.Parameters.AddWithValue("@urunStokAdet", Convert.ToString(urunstokadettxt.Text));
                cmd.ExecuteReader();
                MessageBox.Show("Kayıt Başarıyla Güncellendi");
                
            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            
            barkodtxt.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            urunadtxt.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            urunalıstxt.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            urunsatıstxt.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            urunstokadettxt.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void urunstokadettxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void barkodtxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
            List<UrunStokList> ustoklist = new List<UrunStokList>();
            string sorgu = "Select * from UrunStokTable where UrunAd like'%"+textBox1.Text+"%'";
            using (SqlCommand cmd = new SqlCommand(sorgu, DataConnection.BaglantiTestEt()))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ustoklist.Add(new UrunStokList
                        {

                            UrunBarkod = Convert.ToString(reader["UrunBarkod"]),
                            UrunAd = Convert.ToString(reader["UrunAd"]),
                            UrunAlısFiyatı = Convert.ToDecimal(reader["UrunAlısFiyatı"]),
                            UrunSatısFiyatı = Convert.ToDecimal(reader["UrunSatısFiyatı"]),
                            UrunStokAdet = Convert.ToInt32(reader["UrunStokAdet"])
                        });
                        


                    }
                }
            }
            dataGridView1.DataSource = ustoklist;
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

