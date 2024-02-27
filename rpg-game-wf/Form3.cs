using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rpg_game_wf
{
    public partial class Form3 : Form
    {
        private List<PictureBox> pictures = new List<PictureBox>();

        private int score = 0;

        private int counter = 1;


        public Form3()
        {
            InitializeComponent();
            timer1.Interval = 1;
            timer1.Start();

            timer2.Interval = 1000;
            timer2.Start();

            timer3.Interval = 10;
            timer3.Start();

            timer4.Interval = 1;
            timer4.Start();

            timer5.Interval = 1;
            timer5.Start();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox picture = (PictureBox)sender;
            this.Controls.Remove(picture);
            pictures.Remove(picture);
            score += 1;
            counter += 1;

        }

        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    if (livesCounter == 2)
        //    {
        //        pictureBox3.Visible = false;
        //    }
        //    else if (livesCounter == 1)
        //    {
        //        pictureBox2.Visible = false;
        //    }

        //}

        private void timer2_Tick(object sender, EventArgs e)
        {
            


        }

        private void timer3_Tick(object sender, EventArgs e)
        {
        }

        private void timer4_Tick(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {


        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void timer2_Tick_1(object sender, EventArgs e)
        {
            Random rand = new Random();

            PictureBox picture = new PictureBox();
            picture.Location = new Point(rand.Next(0, 500), 300);
            picture.Size = new Size(25, 22);
                        
            picture.Image = Properties.Resources.star;

            picture.BackColor = Color.Transparent;
            picture.Click += pictureBox1_Click;

            if (counter >= 5)
            {
                timer2.Interval = 500;
            }
            else if (counter >= 10)
            {
                timer2.Interval = 300;
            }
            pictures.Add(picture);
            this.Controls.Add(picture);
        }

        private void timer3_Tick_1(object sender, EventArgs e)
        {

            int baseSpeed = 3;
            double speedMultiplier = 0.5;

            int speed = (int)(baseSpeed + counter * speedMultiplier);

            foreach (var pic in pictures)
            {
                Point point = Point.Add(pic.Location, new Size(0, -speed));
                pic.Location = point;
            }
        }

        private void timer4_Tick_1(object sender, EventArgs e)
        {
            if(score == 3)
            {
                this.Close();
            }
        }

        private void timer5_Tick_1(object sender, EventArgs e)
        {

        }
    }
}
