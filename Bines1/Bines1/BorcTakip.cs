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
    public partial class BorcTakip : Form
    {
        public BorcTakip()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void BorcTakip_Load(object sender, EventArgs e)
        {
            List<BorcTakipList> borctakiplist = new List<BorcTakipList>();
            string sqlsorgu = "Select KisiAdi,KisiSoyadi,KisiTelefonNo,BorcTutari from BorcTakipTable";
            using (SqlCommand cmd = new SqlCommand(sqlsorgu, DataConnection.BaglantiTestEt()))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        borctakiplist.Add(new BorcTakipList
                        {

                            KisiAdi = Convert.ToString(reader["KisiAdi"]),
                            KisiSoyadi = Convert.ToString(reader["KisiSoyadi"]),
                            KisiTelefonNo = Convert.ToString(reader["KisiTelefonNo"]),
                            BorcTutari = Convert.ToDecimal(reader["BorcTutari"])
                            
                        });


                    }
                }
            }
            dataGridView1.DataSource = borctakiplist;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = ("INSERT INTO [BorcTakipTable](KisiAdi,KisiSoyadi,KisiTelefonNo,BorcTutari) VALUES (@kisiAd,@kisiSoyad,@kisitelno,@borcTutari )");
            using (SqlCommand cmd = new SqlCommand(sorgu, DataConnection.BaglantiTestEt()))
            {
                cmd.Parameters.AddWithValue("@kisiAd", SqlDbType.VarChar).Value = kisiadtxt.Text;
                cmd.Parameters.AddWithValue("@kisiSoyad", SqlDbType.VarChar).Value = kisisoyadtxt.Text;
                cmd.Parameters.AddWithValue("@kisitelno", SqlDbType.VarChar).Value = telefonnotxt.Text;
                cmd.Parameters.AddWithValue("@borcTutari", SqlDbType.Decimal).Value = borctutartxt.Text;
            

                cmd.ExecuteReader();



            }

            MessageBox.Show(" Kayıt Başarıyla Eklendi !");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sorgu = "SELECT * FROM BorcTakipTable WHERE KisiAdi = @kisiAdi ";
            using (SqlCommand cmd = new SqlCommand(sorgu, DataConnection.BaglantiTestEt()))
            {
                cmd.Parameters.AddWithValue("@kisiAdi", Convert.ToString(kisiadtxt.Text));

               
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string sorgu2 = "DELETE  FROM BorcTakipTable WHERE KisiAdi = @kisiAdi and KisiSoyadi = @kisiSoyadi";
                    using (SqlCommand cmd2 = new SqlCommand(sorgu2, DataConnection.BaglantiTestEt()))
                    {

                        cmd2.Parameters.AddWithValue("@kisiAdi", Convert.ToString(kisiadtxt.Text));
                        cmd2.Parameters.AddWithValue("@kisiSoyadi", Convert.ToString(kisisoyadtxt.Text));

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
            string sorgu = "UPDATE BorcTakipTable SET  KisiAdi = @kisiAdi,KisiSoyadi = @kisiSoyadi, KisiTelefonNo = @kisitelno,BorcTutari = @borcTutari  WHERE  KisiAdi = @kisiAdi AND KisiSoyadi = @kisiSoyadi";
            using (SqlCommand cmd = new SqlCommand(sorgu, DataConnection.BaglantiTestEt()))
            {
                cmd.Parameters.AddWithValue("@kisiAdi", Convert.ToString(kisiadtxt.Text));
                cmd.Parameters.AddWithValue("@kisiSoyadi", Convert.ToString(kisisoyadtxt.Text));
                cmd.Parameters.AddWithValue("@kisitelno", Convert.ToString(telefonnotxt.Text));
                cmd.Parameters.AddWithValue("@borcTutari", Convert.ToString(borctutartxt.Text));
                
                cmd.ExecuteReader();
                MessageBox.Show("Kayıt Başarıyla Güncellendi");
            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            kisiadtxt.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            kisisoyadtxt.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            telefonnotxt.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            borctutartxt.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            
        }

        private void kisiadtxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<BorcTakipList> borctakiplist = new List<BorcTakipList>();
            string sqlsorgu = "Select * from BorcTakipTable where KisiAdi like'%" + textBox1.Text + "%'";
            using (SqlCommand cmd = new SqlCommand(sqlsorgu, DataConnection.BaglantiTestEt()))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        borctakiplist.Add(new BorcTakipList
                        {

                            KisiAdi = Convert.ToString(reader["KisiAdi"]),
                            KisiSoyadi = Convert.ToString(reader["KisiSoyadi"]),
                            KisiTelefonNo = Convert.ToString(reader["KisiTelefonNo"]),
                            BorcTutari = Convert.ToDecimal(reader["BorcTutari"])

                        });


                    }
                }
            }
            dataGridView1.DataSource = borctakiplist;
            

        }
    }
}
