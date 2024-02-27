using C_CLASS25._11._2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rpg_game_wf
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "Json files (*.json)|*.json";
            openFileDialog.FilterIndex = 0;
            openFileDialog.RestoreDirectory = true;

            if(openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string selectedFileName = openFileDialog.FileName;
            using(FileStream stream = (FileStream)openFileDialog.OpenFile())
            {
                StoreInfo.statistics = JsonSerializer.Deserialize<Statistics>(stream);

            }
            button1.Hide();

            label1.Show();
            label2.Show();
            label3.Show();
            label4.Show();
            label5.Show();
            label6.Show();
            button2.Show();

            string[] elements = selectedFileName.Split('\\');
            string name = elements[elements.Length - 1];
            name = name.Split('.')[0];


            label1.Text = "Fight number: " + name;
         
            label2.Text = "Player one class: " + StoreInfo.statistics.classPlayerOne;
            label3.Text = "Player two class: " + StoreInfo.statistics.classPlayerTwo;
            label4.Text = "Total damage player One:" + StoreInfo.statistics.totalDamagePlayerOne;
            label5.Text = "Total damage player Two:" + StoreInfo.statistics.totalDamagePlayerTwo;
            label6.Text = "Winner: " + StoreInfo.statistics.Winner;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
