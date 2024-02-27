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
    public partial class ChoseTypeAttackMessageForm : Form
    {
        public static int ReturnNumber { get; set; }

        public ChoseTypeAttackMessageForm()
        {
            InitializeComponent();
        }

        public ChoseTypeAttackMessageForm(string labelText, string buttonText1, string buttonText2) 
        {
            InitializeComponent();
            label1.Text = labelText;
            button1.Text = buttonText1;
            button2.Text = buttonText2;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReturnNumber = 1;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReturnNumber = 2;
            this.Close();
        }
    }
}
