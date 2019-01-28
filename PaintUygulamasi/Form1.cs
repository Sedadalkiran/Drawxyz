using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintUygulamasi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string yap;
       public  enum cizilen
        {
            kare,
            elips,
            silgi,
            cizgi


        }
        int silgikalinlik = 3;



        bool draw;
        int startX, startY;
        int thickness = 3;
        ColorDialog choosecolor = new ColorDialog();


        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            draw = true;
            startX = e.X;
            startY = e.Y;

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

            Graphics g = this.CreateGraphics();
            Pen p = new Pen(choosecolor.Color, thickness);
            Point point1 = new Point(startX,startY);
            Point point2 = new Point(e.X,e.Y);
            
            Rectangle kare = new Rectangle(startX,startY,200,200);
            Rectangle elipss = new Rectangle(startX, startY, 200,200);
            
            
            if (draw == true)
            {
                if (yap == cizilen.cizgi.ToString())
                {
                g.DrawLine(p, point1, point2);
                startX = e.X;
                startY = e.Y;
                }
                if(yap==cizilen.kare.ToString())
                {
                    
                    g.DrawRectangle(p, kare);
                   
                    
                    startX = e.X;
                    startY = e.Y;
                    draw = false;
                    
                }
                if (yap == cizilen.elips.ToString())
                {
                    g.DrawEllipse(p, elipss);
                    startX = e.X;
                    startY = e.Y;
                    draw = false;


                }
                if(yap==cizilen.silgi.ToString())
                {
                    Pen yeni = new Pen(Color.White, silgikalinlik);
                    g.DrawLine(yeni, point1, point2);
                    startX = e.X;
                    startY = e.Y;
                }

                else
                {
                    g.DrawLine(p, point1, point2);
                    startX = e.X;
                    startY = e.Y;

                }
                

            }


        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            draw = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            choosecolor.ShowDialog();

           
                button7.BackColor = choosecolor.Color;
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            thickness = int.Parse(comboBox1.SelectedItem.ToString());
        }

        //private void comboBox1_MouseHover(object sender, EventArgs e)
        //{
        //    ToolTip message = new ToolTip();
        //    message.SetToolTip(comboBox1, "Fırça kalınlığını seçiniz.");
          
        //    message.ToolTipIcon = ToolTipIcon.Info;
        //}

        private void comboBox1_MouseEnter(object sender, EventArgs e)
        {

            ToolTip message = new ToolTip();
            message.SetToolTip(comboBox1, "Fırça kalınlığını seçiniz.");

            message.ToolTipIcon = ToolTipIcon.Info;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {

            ToolTip message = new ToolTip();
            message.SetToolTip(button2, "Çizgi");

            message.ToolTipIcon = ToolTipIcon.Info;

        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            ToolTip mesaj = new ToolTip();
            mesaj.SetToolTip(button3, "Elips");
            mesaj.ToolTipIcon = ToolTipIcon.Info;


        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            ToolTip mesaj = new ToolTip();
            mesaj.SetToolTip(button4, "Kare");
            mesaj.ToolTipIcon = ToolTipIcon.Info;
        }

        private void button2_Click(object sender, EventArgs e)
        {
          yap=Convert.ToString(cizilen.cizgi);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            yap = Convert.ToString(cizilen.elips);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            yap = Convert.ToString(cizilen.kare);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            yap = Convert.ToString(cizilen.silgi);
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            ToolTip mesaj = new ToolTip();
            mesaj.SetToolTip(button3, "Silgi");
            mesaj.ToolTipIcon = ToolTipIcon.Info;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            silgikalinlik = int.Parse(comboBox2.SelectedItem.ToString());
        }

        private void comboBox2_MouseEnter(object sender, EventArgs e)
        {
            ToolTip mesaj = new ToolTip();
            mesaj.SetToolTip(comboBox2, "Silgi boyutu");
            mesaj.ToolTipIcon = ToolTipIcon.Info;
        }


        private void button6_Click(object sender, EventArgs e)
        {
           
            Bitmap screenshot = new Bitmap(this.Width-20, this.Height-120);
            Graphics grafik = Graphics.FromImage((Image)screenshot);
            grafik.CopyFromScreen(this.Location.X+10, this.Location.Y+110, 0, 0, this.Size);
           string isim = Path.GetRandomFileName();
            screenshot.Save("d://"+isim+".png", ImageFormat.Png);
            MessageBox.Show("Dosya " + isim + "ismiyle kaydedildi.");
            

        }

      

        private void button5_Click_1(object sender, EventArgs e)
        {
            yap = Convert.ToString(cizilen.silgi);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Graphics a = this.CreateGraphics();
            a.Clear(Form.DefaultBackColor);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button7.BackColor = Color.Black;
        }
    }
}
