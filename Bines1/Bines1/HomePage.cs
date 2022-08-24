using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bines1
{
    public partial class HomePage : Form

    {
        
        private Form activeForm;
        private Random random;
        public HomePage()
        {
            InitializeComponent();
            random = new Random();
            this.Text = string.Empty;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDestkop.Controls.Add(childForm);
            this.panelDestkop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            label1.Text = "ÜRÜN STOK";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void btnSatıs_Click(object sender, EventArgs e)
        {
            OpenChildForm(new SatısEkran(), sender);
            label1.Text = "SATIS";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new ÜrünStok(), sender);

        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            

           

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelDestkop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btncloseclick_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (WindowState==FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;


            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new BorcTakip(), sender);
            label1.Text = "BORÇ TAKİP";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            OpenChildForm(new FirmaIrtibat(), sender);
            label1.Text = "FİRMA İRTİBAT";
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
