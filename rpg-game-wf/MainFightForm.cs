using C_CLASS25._11._2;
using System;
using System.Drawing;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rpg_game_wf
{

    public partial class MainFightForm : Form
    {
        int damage = 0;

        private bool playerWins = false;

        PalyersWins palyersWins = new PalyersWins();

        public MainFightForm()
        {
            InitializeComponent();

            BattlePrintMangaer.Form = this;

            label6.Text = StoreInfo.Player1.Health.ToString();
            label8.Text = StoreInfo.Player2.Health.ToString();

            selectPlayerModel();

        }

        private void MainFightForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (StoreInfo.isPlayer1Turn)
            {
                damage = StoreInfo.Player1.CalculateDamage(StoreInfo.Player2.AttackPower, Hero.AttackType.Physical, StoreInfo.Player1.CriticalChance, StoreInfo.Player1.Name);
                damage = StoreInfo.Player2.Defend(damage);

                StoreInfo.isPlayer1Turn = false;
                StoreInfo.totalDamagePlayerOne += damage;

                label2.Text = StoreInfo.totalDamagePlayerOne.ToString();
                label8.Text = StoreInfo.Player2.Health.ToString();

                label10.Show();
                label10.Text = damage.ToString();
                label10.ForeColor = Color.DarkRed;
                MoveLabelUpAndHide(label10);

                whoWins();

                label9.ForeColor = Color.DarkBlue;
                label9.Text = "PLAYER TWO";

            }
            else
            {
                damage = StoreInfo.Player2.CalculateDamage(StoreInfo.Player1.AttackPower, Hero.AttackType.Physical, StoreInfo.Player2.CriticalChance, StoreInfo.Player2.Name);
                damage = StoreInfo.Player1.Defend(damage);

                StoreInfo.isPlayer1Turn = true;
                StoreInfo.totalDamagePlayerTwo += damage;

                label4.Text = StoreInfo.totalDamagePlayerTwo.ToString();
                label6.Text = StoreInfo.Player1.Health.ToString();

                label10.Show();
                label10.Text = damage.ToString();
                label10.ForeColor = Color.DarkBlue;
                MoveLabelUpAndHide(label10);

                whoWins();

                label9.ForeColor = Color.DarkRed;
                label9.Text = "PLAYER ONE";

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (StoreInfo.isPlayer1Turn)
            {
                StoreInfo.Player1.StartDefending();
                StoreInfo.isPlayer1Turn = false;
                label9.ForeColor = Color.DarkBlue;

                label10.Show();
                label10.Text = "Defending";
                label10.ForeColor = Color.Chocolate;
                MoveLabelUpAndHide(label10);


                label9.Text = "PLAYER TWO";
                whoWins();

            }
            else
            {
                StoreInfo.Player2.StartDefending();
                StoreInfo.isPlayer1Turn = true;
                label9.ForeColor = Color.DarkRed;

                label10.Show();
                label10.Text = "Defending";
                label10.ForeColor = Color.Chocolate;
                MoveLabelUpAndHide(label10);

                label9.Text = "PLAYER ONE";
                whoWins();


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (StoreInfo.isPlayer1Turn)
            {
                StoreInfo.Player1.Health += 100;
                label6.Text = StoreInfo.Player1.Health.ToString();
                label9.ForeColor = Color.DarkBlue;
                StoreInfo.isPlayer1Turn = false;

                label10.Show();
                label10.Text = "Heal +100";
                label10.ForeColor = Color.OliveDrab;
                MoveLabelUpAndHide(label10);


                label9.Text = "PLAYER TWO";
            }
            else
            {
                StoreInfo.Player2.Health += 100;
                label8.Text = StoreInfo.Player2.Health.ToString();
                label9.ForeColor = Color.DarkRed;
                StoreInfo.isPlayer1Turn = true;

                label10.Show();
                label10.Text = "Heal +100";
                label10.ForeColor = Color.OliveDrab;
                MoveLabelUpAndHide(label10);


                label9.Text = "PLAYER ONE";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (StoreInfo.isPlayer1Turn)
            {

                Form form = new Form3();
                form.StartPosition = FormStartPosition.CenterScreen;                
                form.ShowDialog();


                damage = StoreInfo.Player1.AttackPower +100;
                damage = StoreInfo.Player2.Defend(damage);
                StoreInfo.isPlayer1Turn = false;
                StoreInfo.totalDamagePlayerOne += damage;



                label2.Text = StoreInfo.totalDamagePlayerOne.ToString();
                label8.Text = StoreInfo.Player2.Health.ToString();
                label9.ForeColor = Color.DarkBlue;

                label10.Show();
                label10.Text = "Skill " + damage.ToString();
                label10.ForeColor = Color.DarkRed;
                MoveLabelUpAndHide(label10);

                label9.Text = "PLAYER TWO";
                whoWins();
            }
            else
            {
                // open new form

                damage = StoreInfo.Player2.AttackPower + 100;
                damage = StoreInfo.Player1.Defend(damage);
                StoreInfo.isPlayer1Turn = true;
                StoreInfo.totalDamagePlayerTwo += damage;

                label4.Text = StoreInfo.totalDamagePlayerTwo.ToString();
                label6.Text = StoreInfo.Player1.Health.ToString();
                label9.ForeColor = Color.DarkRed;

                label10.Show();
                label10.Text = "Skill " + damage.ToString(); 
                label10.ForeColor = Color.DarkBlue;
                MoveLabelUpAndHide(label10);

                label9.Text = "PLAYER ONE";
                whoWins();

            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
        private void whoWins()
        {
            if (StoreInfo.Player1.Health <= 0 || StoreInfo.Player2.Health <= 0)
            {
                if (StoreInfo.Player1.Health <= 0)
                {
                    MessageBox.Show("Player Two Wins!");

                    StoreInfo.statistics.Winner = "Player Two";
                    StoreInfo.statistics.classPlayerOne = StoreInfo.Player1.Name;
                    StoreInfo.statistics.classPlayerTwo = StoreInfo.Player2.Name;
                    StoreInfo.statistics.totalDamagePlayerOne = StoreInfo.totalDamagePlayerOne;
                    StoreInfo.statistics.totalDamagePlayerTwo = StoreInfo.totalDamagePlayerTwo;

                    string path = StoreInfo.date.ToLongTimeString();
                    path = path.Replace(":", "-");

                    using (FileStream file = new FileStream($"..\\..\\{path}.json", FileMode.Create))
                    {
                        JsonSerializer.Serialize<Statistics>(file, StoreInfo.statistics);
                        Console.WriteLine(file.Name);
                    }

                }
                if (StoreInfo.Player2.Health <= 0)
                {
                    MessageBox.Show("Player One Wins!");

                    StoreInfo.statistics.Winner = "Player One";
                    StoreInfo.statistics.classPlayerOne = StoreInfo.Player1.Name;
                    StoreInfo.statistics.classPlayerTwo = StoreInfo.Player2.Name;
                    StoreInfo.statistics.totalDamagePlayerOne = StoreInfo.totalDamagePlayerOne;
                    StoreInfo.statistics.totalDamagePlayerTwo = StoreInfo.totalDamagePlayerTwo;

                    string path = StoreInfo.date.ToLongTimeString();
                    path = path.Replace(":", "-");

                    using (FileStream file = new FileStream($"..\\..\\{path}.json", FileMode.Create))
                    {
                        JsonSerializer.Serialize<Statistics>(file, StoreInfo.statistics);
                        Console.WriteLine(file.Name);
                    }

                }

                this.Close();
                
            }

        }
        private void selectPlayerModel()
        {
            if (StoreInfo.Player1.Name == "Warrior")
            {
                pictureBox1.Image = Properties.Resources.warrior;
            }
            if (StoreInfo.Player1.Name == "Mage")
            {
                pictureBox1.Image = Properties.Resources.mage;
            }
            if (StoreInfo.Player1.Name == "Archer")
            {
                pictureBox1.Image = Properties.Resources.archer;
            }
            if (StoreInfo.Player2.Name == "Warrior")
            {
                pictureBox2.Image = Properties.Resources.warrior;
            }
            if (StoreInfo.Player2.Name == "Mage")
            {
                pictureBox2.Image = Properties.Resources.mage;
            }
            if (StoreInfo.Player2.Name == "Archer")
            {
                pictureBox2.Image = Properties.Resources.archer;
            }

        }
        private async void MoveLabelUpAndHide(Label label)
        {
            Point originalLocation = label.Location;

            int moveDistance = 150; 
            int stepCount = 30;
            int stepDelay = 10; 
            int deltaY = moveDistance / stepCount;

            for (int i = 0; i < stepCount; i++)
            {
                label.Top -= deltaY;
                await Task.Delay(stepDelay);
            }

      
            label.Hide();

            label.Location = originalLocation;
        }
        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
