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
        string speleraanzet = "Blauw";
        int[,] tegels = new int[8, 8];
        bool helpfunctie = false;

        public Form1()
        {
            InitializeComponent();

            //abonnementen op events
            panel1.Paint += new PaintEventHandler(panel1_Paint);
            panel3.Paint += new PaintEventHandler(panel3_Paint);
            panel1.MouseClick += panel1_MouseClick;




        }


        private bool ValidMove(int MouseX, int MouseY, int PlayerColour)
        {
            if (tegels[MouseX, MouseY] == 0)
            {
                for (int dx = -1; dx < 2; dx++ )
                {
                    for (int dy = -1; dy < 2; dy++)
                    {
                        try
                        {
                            int offset = 1;
                            while (tegels[MouseX + dx * offset, MouseY + dy * offset] == -PlayerColour)
                            {
                                offset++;

                            }

                            if (offset == 1)
                            {
                                continue;

                            }
                            if (tegels[MouseX + dx * offset, MouseY + dy * offset] == PlayerColour)
                            {

                                return true;
                            }

                        }
                        catch(Exception)
                        {


                        }

                    }

                }
                    

            }
            return false;



        }

        void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            int MouseX = e.X / gridvaksize; //x-coördinaten muis
            int MouseY = e.Y / gridvaksize; //y-coördinaten muis

            Graphics gr = this.panel1.CreateGraphics();
            if (speleraanzet == "Blauw")
            {
                if (ValidMove(MouseX, MouseY, 1))
                {
                    tegels[MouseX, MouseY] = 1;
 
                    panel1.Invalidate();
                    speleraanzet = "Rood";
                }

            }
            else
            {
                if (ValidMove(MouseX, MouseY, -1))
                {
                    tegels[MouseX, MouseY] = -1;
                    panel1.Invalidate();
                    speleraanzet = "Blauw";
                }
            }
            

            Label1_Teller();
            TextBox3_Speler();
        }

      

        private void panel1_Paint(object obj, PaintEventArgs e) // tekenen van de Grid
        {
            Pen myPen = new Pen(Color.Black);
            myPen.Width = 3;


            e.Graphics.FillEllipse(Brushes.Blue, numvak / 2 * gridvaksize, numvak / 2 * gridvaksize, gridvaksize, gridvaksize);
            e.Graphics.FillEllipse(Brushes.Blue, numvak / 2 * gridvaksize - gridvaksize, numvak / 2 * gridvaksize - gridvaksize, gridvaksize, gridvaksize);
            e.Graphics.FillEllipse(Brushes.Red, numvak / 2 * gridvaksize, numvak / 2 * gridvaksize - gridvaksize, gridvaksize, gridvaksize);
            e.Graphics.FillEllipse(Brushes.Red, numvak / 2 * gridvaksize - gridvaksize, numvak / 2 * gridvaksize, gridvaksize, gridvaksize);
            for (int y = 0; y <= numvak; y++)
            {
                e.Graphics.DrawLine(myPen, y * gridvaksize, 0, y * gridvaksize, numvak * gridvaksize);  //Vertical Grid Lines
                e.Graphics.DrawLine(myPen, 0, y * gridvaksize, gridvaksize * numvak, y * gridvaksize); // Horizontal Grid Lines

            }

            for (int xgrid = 0; xgrid < numvak; xgrid++)
            {
                for(int ygrid = 0; ygrid < numvak; ygrid++)
                {
                    
                    if(tegels[xgrid, ygrid] == 1)
                    {
                        e.Graphics.FillEllipse(Brushes.Blue, xgrid * gridvaksize, ygrid * gridvaksize, gridvaksize, gridvaksize);

                    }
                    if(tegels[xgrid, ygrid] == -1)
                    {
                        e.Graphics.FillEllipse(Brushes.Red, xgrid * gridvaksize, ygrid * gridvaksize, gridvaksize, gridvaksize);
                    }
                }
            }

                tegels[4, 4] = 1;
            tegels[4, 3] = -1;
            tegels[3, 3] = 1;
            tegels[3, 4] = -1;
        }



        private void button1_Click(object sender, EventArgs e) //New game
        {
            for (int x = 0; x < numvak; x++)
            {
                for (int y = 0; y < numvak; y++)
                {
                    tegels[x, y] = 0;
                }

            }
            speleraanzet = "Blauw";

            panel1.Invalidate();
            label1.Text = "2";
            label2.Text = "2";
            TextBox3_Speler();

        }

        private void Helpfunctie()
        {
            

        }


        private void button3_Click(object sender, EventArgs e) //Help
        {
            helpfunctie = !helpfunctie;
        }


        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e) //panel-positie voor tussenstand rode cirkels1
        {
            e.Graphics.FillEllipse(Brushes.Red, 0, 0, 50, 50);
        }

        private void panel4_Paint(object sender, PaintEventArgs e) //panel-positie voor tussenstand blauwe cirkels 
        {
            e.Graphics.FillEllipse(Brushes.Blue, 0, 0, 50, 50);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Invalidate();
        }

        private void TextBox3_Speler()
        {
            string SpelerX = speleraanzet;
            textBox3.Text = SpelerX;
        }

        private void Label1_Teller()
        {
            int teller1 = 0;
            int teller2 = 0;
            for (int x = 0; x < numvak; x++)
            {
                for (int y = 0; y < numvak; y++)
                {
                    if (tegels[x, y] == 1)
                    {
                        teller1++;

                    }
                    if (tegels[x, y] == -1)
                    {
                        teller2++;
                    }
                }
            }
            label1.Text = teller1.ToString();
            label2.Text = teller2.ToString();

        }


    }
}
