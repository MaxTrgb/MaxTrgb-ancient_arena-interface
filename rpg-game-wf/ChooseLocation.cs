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
    public partial class ChooseLocation : Form
    {
        public ChooseLocation()
        {
            InitializeComponent();
        }

        private void ChooseLocation_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StoreInfo.Player1.Location(Hero.BattleLocation.Arena);
            StoreInfo.Player2.Location(Hero.BattleLocation.Arena);            
            Form form = new MainFightForm();
            form.StartPosition = FormStartPosition.Manual;
            form.Height = this.Height;
            form.Width = this.Width;
            form.Location = this.Location;
            form.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StoreInfo.Player1.Location(Hero.BattleLocation.Everest);
            StoreInfo.Player2.Location(Hero.BattleLocation.Everest);
            Form form = new MainFightForm();
            form.StartPosition = FormStartPosition.Manual;
            form.Height = this.Height;
            form.Width = this.Width;
            form.BackgroundImage = Properties.Resources.everest;
            form.Location = this.Location;
            form.Show();
            this.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            StoreInfo.Player1.Location(Hero.BattleLocation.Forest);
            StoreInfo.Player2.Location(Hero.BattleLocation.Forest);
            Form form = new MainFightForm();
            form.StartPosition = FormStartPosition.Manual;
            form.Height = this.Height;
            form.Width = this.Width;
            form.BackgroundImage = Properties.Resources.forest;
            form.Location = this.Location;
            form.Show();
            this.Close();

        }
    }
}
