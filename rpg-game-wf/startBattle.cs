using C_CLASS25._11._2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rpg_game_wf
{

    public partial class startBattle : Form
    {
        
        Hero playerHero = null;
        public startBattle()
        {
            InitializeComponent();
        }

        private void startBattle_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            playerHero = new Warrior();

            if (StoreInfo.isPlayer1Turn)
            {
                StoreInfo.Player1 = playerHero;
                StoreInfo.isPlayer1Turn = false;               
                label1.Text = "Player Two Choose Hero";
            }
            else
            {
                StoreInfo.Player2 = playerHero;
                StoreInfo.isPlayer1Turn = true;
                Form form = new ChooseLocation();
                form.StartPosition = FormStartPosition.Manual;
                form.Height = this.Height;
                form.Width = this.Width;
                form.Location = this.Location;
                form.Show();
                this.Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            playerHero = new Mage();

            if (StoreInfo.isPlayer1Turn)
            {
                StoreInfo.Player1 = playerHero;
                StoreInfo.isPlayer1Turn = false;
                label1.Text = "Player Two Choose Hero!";

            }
            else
            {
                StoreInfo.Player2 = playerHero;
                StoreInfo.isPlayer1Turn = true;
                Form form = new ChooseLocation();
                form.StartPosition = FormStartPosition.Manual;

                form.Height = this.Height;
                form.Width = this.Width;
                form.Location = this.Location;
                form.Show();
                this.Close();

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            playerHero = new Archer();

            if (StoreInfo.isPlayer1Turn)
            {
                StoreInfo.Player1 = playerHero;
                StoreInfo.isPlayer1Turn = false;
                label1.Text = "Player Two Choose Hero!";
            }
            else
            {
                StoreInfo.Player2 = playerHero;
                StoreInfo.isPlayer1Turn = true;

                Form form = new ChooseLocation();
                form.StartPosition = FormStartPosition.Manual;

                form.Height = this.Height;
                form.Width = this.Width;
                form.Location = this.Location;
                form.Show();
                this.Close();
 
            }

        }
    }
}
