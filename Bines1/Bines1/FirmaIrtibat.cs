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
    public partial class FirmaIrtibat : Form
    {
        public FirmaIrtibat()
        {
            InitializeComponent();
        }

        private void FirmaIrtibat_Load(object sender, EventArgs e)
        {
            List<FirmaIrtibatList> firmairtibatlist = new List<FirmaIrtibatList>();
            string sqlsorgu = "Select Ad,Soyad,TelefonNo,FirmaAd from FirmaIrtibatTable";
            using (SqlCommand cmd = new SqlCommand(sqlsorgu, DataConnection.BaglantiTestEt()))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        firmairtibatlist.Add(new FirmaIrtibatList
                        {
                           
                            Ad = Convert.ToString(reader["Ad"]),
                            Soyad = Convert.ToString(reader["Soyad"]),
                            TelefonNo = Convert.ToString(reader["TelefonNo"]),
                            FirmaAd = Convert.ToString(reader["FirmaAd"])


                           
                        });


                    }
                }
            }
            dataGridView1.DataSource = firmairtibatlist;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = ("Insert into [FirmaIrtibatTable](Ad,Soyad,TelefonNo,FirmaAd) Values (@ad,@soyad,@telefonno,@firmaad)");
            using (SqlCommand cmd = new SqlCommand(sorgu, DataConnection.BaglantiTestEt()))
            {
                cmd.Parameters.AddWithValue("@ad", SqlDbType.VarChar).Value = kisiadtxt.Text;
                cmd.Parameters.AddWithValue("@soyad", SqlDbType.VarChar).Value = kisisoyadtxt.Text;
                cmd.Parameters.AddWithValue("@telefonno", SqlDbType.Char).Value = telefonnotxt.Text;
                cmd.Parameters.AddWithValue("@firmaad", SqlDbType.VarChar).Value = firmaadtxt.Text;
                cmd.ExecuteReader();
            }
            MessageBox.Show("Kayıt Başarıyla Eklendi");
        }

        private void kisiadtxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sorgu = "SELECT * FROM FirmaIrtibatTable WHERE Ad=@ad  ";
            using (SqlCommand cmd = new SqlCommand(sorgu, DataConnection.BaglantiTestEt()))
            {
                cmd.Parameters.AddWithValue("@ad", Convert.ToString(kisiadtxt.Text));


                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string sorgu2 = "DELETE  FROM FirmaIrtibatTable WHERE Ad=@ad AND Soyad=@soyad";
                    using (SqlCommand cmd2 = new SqlCommand(sorgu2, DataConnection.BaglantiTestEt()))
                    {

                        cmd2.Parameters.AddWithValue("@ad", Convert.ToString(kisiadtxt.Text));
                        cmd2.Parameters.AddWithValue("@soyad", Convert.ToString(kisisoyadtxt.Text));

                        SqlDataReader reader2 = cmd2.ExecuteReader();
                        {
                            MessageBox.Show("Kayıt Başarıyla Silindi");

                        }


                    }

                }
                else
                {
                    MessageBox.Show("Kişi Bulunamadı");

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sorgu = "UPDATE FirmaIrtibatTable SET  Ad = @ad,Soyad = @soyad, TelefonNo = @telefonno,FirmaAd = @firmaad  WHERE  Ad = @ad AND Soyad = @soyad";
            using (SqlCommand cmd = new SqlCommand(sorgu, DataConnection.BaglantiTestEt()))
            {
                cmd.Parameters.AddWithValue("@ad", Convert.ToString(kisiadtxt.Text));
                cmd.Parameters.AddWithValue("@soyad", Convert.ToString(kisisoyadtxt.Text));
                cmd.Parameters.AddWithValue("@telefonno", Convert.ToString(telefonnotxt.Text));
                cmd.Parameters.AddWithValue("@firmaad", Convert.ToString(firmaadtxt.Text));

                cmd.ExecuteReader();
                MessageBox.Show("Kayıt Başarıyla Güncellendi");
            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            kisiadtxt.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            kisisoyadtxt.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            telefonnotxt.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            firmaadtxt.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<FirmaIrtibatList> firmairtibatlist = new List<FirmaIrtibatList>();
            string sqlsorgu = "Select * from FirmaIrtibatTable where Ad like'%" + textBox1.Text + "%'";
            using (SqlCommand cmd = new SqlCommand(sqlsorgu, DataConnection.BaglantiTestEt()))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        firmairtibatlist.Add(new FirmaIrtibatList
                        {

                            Ad = Convert.ToString(reader["Ad"]),
                            Soyad = Convert.ToString(reader["Soyad"]),
                            TelefonNo = Convert.ToString(reader["TelefonNo"]),
                            FirmaAd = Convert.ToString(reader["FirmaAd"])



                        });


                    }
                }
            }
            dataGridView1.DataSource = firmairtibatlist;

        }
    }
}
