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
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string loginsorgu = "SELECT * FROM Login WHERE UserName =@username AND Password=@password";
            using (SqlCommand cmd = new SqlCommand(loginsorgu, DataConnection.BaglantiTestEt()))
            {
                cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = txtUserName.Text;
                cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = txtpassword.Text;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    MessageBox.Show("giriş yapıldı");
                    //HomePage frm2 = new HomePage();
                    //this.Hide();
                    //frm2.Show();
                    //MessageBox.Show("giriş yapıldı");

                    HomePage hp = new HomePage();
                    this.Hide();
                    hp.Show();


                }
                else
                {
                    MessageBox.Show("Hatalı ID Şifre lütfen tekrar deneyin !");
                    
                }
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {
            txtUserName.Clear();
            txtpassword.Clear();
            txtUserName.Focus();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtpassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1.PerformClick();
            {

            }
        }
    }
}
