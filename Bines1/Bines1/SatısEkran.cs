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
    public partial class SatısEkran : Form
    {
        int stokazalt;
        int kontrol = 0;
        decimal toplam = 0;
        public decimal toplamnakitsatis =0 ;
        public decimal toplamkredisatis =0 ;



        


        List<UrunStokList> ustoklist = new List<UrunStokList>();

        public void ToplamNakitSatis()
        {

           

            toplamnakitsatis += toplam;
            label3.Text = "Toplam Nakit Satış : " + toplamnakitsatis;
        }
        public void ToplamKrediSatis()
        {
            
            toplamkredisatis += toplam;
            label4.Text = "Toplam  Kredi Satış : " + toplamkredisatis;
        }

        public void ToplamFiyat()
        {

            toplam = 0;

            for (int y = 0; y < listBox2.Items.Count; y++)
            {
                toplam += Convert.ToDecimal(listBox2.Items[y]);
                

            }


            label2.Text = "Toplam Tutar : " + toplam;
            
            

        
      


        }
       



        public SatısEkran()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void SatısEkran_Load(object sender, EventArgs e)
        {
            ToplamFiyat();
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
                            UrunSatısFiyatı = Convert.ToDecimal(reader["UrunSatısFiyatı"]),
                            UrunStokAdet = Convert.ToInt32(reader["UrunStokAdet"])


                        });


                    }
                }
            }
            


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
         


        }

        private void button3_Click(object sender, EventArgs e)
        {






            for (int i = 0; i < ustoklist.Count; i++)
            {
                if (ustoklist[i].UrunBarkod == textBox1.Text)
                {
                    listBox1.Items.Add(ustoklist[i].UrunAd);
                    listBox2.Items.Add(ustoklist[i].UrunSatısFiyatı);
                }
            }
            ToplamFiyat();
            


        }

        private void button1_Click(object sender, EventArgs e)
        {
            string lbitem;

            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                kontrol = 1;

                lbitem = Convert.ToString(listBox1.Items[i]);

                kontrol = 0;

                string sorgu = "UPDATE UrunStokTable SET UrunStokAdet = @urunStokAdet WHERE  UrunAd = '" + lbitem + "'";
                using (SqlCommand cmd = new SqlCommand(sorgu, DataConnection.BaglantiTestEt()))
                {
                    for (int ik = 0; ik < ustoklist.Count; ik++) 
                    {
                        if(ustoklist[ik].UrunAd == lbitem)
                        {
                            stokazalt = ustoklist[ik].UrunStokAdet;
                            ustoklist[ik].UrunStokAdet = ustoklist[ik].UrunStokAdet - 1;
                        }
                    }
                    stokazalt = stokazalt - 1;

                    cmd.Parameters.Add("urunStokAdet", SqlDbType.Int).Value = stokazalt;

                    cmd.ExecuteNonQuery();



                

                }
                


            }
            ToplamFiyat();
            ToplamNakitSatis();
            listBox2.Items.Clear();
            listBox1.Items.Clear();
            ToplamFiyat();
            





        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if(kontrol == 0)
            {

                int l1;

                l1 = Convert.ToInt32(listBox1.SelectedIndex);

                listBox2.SelectedIndex = l1;

            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(kontrol == 0)
            {

                int l1;

                l1 = Convert.ToInt32(listBox2.SelectedIndex);

                listBox1.SelectedIndex = l1;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            kontrol = 1;

                listBox1.Items.Remove(listBox1.SelectedItem);
                listBox2.Items.Remove(listBox2.SelectedItem);

            kontrol = 0;
            ToplamFiyat();




        }


        private void button2_Click(object sender, EventArgs e)
        {
            string lbitem;

            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                kontrol = 1;

                lbitem = Convert.ToString(listBox1.Items[i]);

                kontrol = 0;

                string sorgu = "UPDATE UrunStokTable SET UrunStokAdet = @urunStokAdet WHERE  UrunAd = '" + lbitem + "'";
                using (SqlCommand cmd = new SqlCommand(sorgu, DataConnection.BaglantiTestEt()))
                {
                    for (int ik = 0; ik < ustoklist.Count; ik++)
                    {
                        if (ustoklist[ik].UrunAd == lbitem)
                        {
                            stokazalt = ustoklist[ik].UrunStokAdet;
                            ustoklist[ik].UrunStokAdet = ustoklist[ik].UrunStokAdet - 1;
                        }
                    }
                    stokazalt = stokazalt - 1;

                    cmd.Parameters.Add("urunStokAdet", SqlDbType.Int).Value = stokazalt;

                    cmd.ExecuteNonQuery();



                }


            }
            ToplamFiyat();
            ToplamKrediSatis();
            listBox2.Items.Clear();
            listBox1.Items.Clear();
            ToplamFiyat();



        }

        private void label2_Click(object sender, EventArgs e)
        {
           
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }
    }

    }

    

