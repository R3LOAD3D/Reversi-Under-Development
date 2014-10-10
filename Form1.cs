using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        int numvak = 8;
        int gridvaksize = 60;
        //int xPanel = 12; -> voor coordinatie grid
        //int yPanel = 106; -> ""


        public Form1()
        {
            InitializeComponent();

            panel1.Paint += new PaintEventHandler(panel1_Paint);
            panel3.Paint += new PaintEventHandler(panel3_Paint);


        }


        private void panel1_Paint(object obj, PaintEventArgs e)
        {
            Pen myPen = new Pen(Color.Black);
            myPen.Width = 3;


            for (int y = 0; y <= numvak; y++)
            {
                e.Graphics.DrawLine(myPen, y * gridvaksize, 0, y * gridvaksize, numvak * gridvaksize);  //Vertical Grid Lines
                e.Graphics.DrawLine(myPen, 0, y * gridvaksize, gridvaksize * numvak, y * gridvaksize); // Horizontal Grid Lines

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) //New game
        {

        }

        private void button3_Click(object sender, EventArgs e) //Help
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e) // textbox voor de rode cirkels --> auto-update
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e) // textbox voor de blauwe cirkels --> auto-update
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillEllipse(Brushes.Red, 0, 0, 50, 50);
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillEllipse(Brushes.Blue, 0, 0, 50, 50);
        }
    }
}
