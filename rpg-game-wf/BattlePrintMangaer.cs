using rpg_game_wf;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace C_CLASS25._11._2
{
    class BattlePrintMangaer
    {
        public static Form Form { get; set; }

        private static BattlePrintMangaer instance = new BattlePrintMangaer();

        public static BattlePrintMangaer Instance { get { return instance; } }

        private BattlePrintMangaer() { }

        public void mainMenuIntro()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t\tWelcome to The Ancient Arena!");
            Console.ResetColor();
            Console.WriteLine("\n\t\t\t1 --- Choose Your Hero!\n\t\t\t2 --- Statistics\n\t\t\t3 --- Exit");
        }
        public void invalidChoice()
        {
            Console.WriteLine("Invalid choice. Please enter a valid option.");
        }
        public void printChooseLoc()
        {
            Console.WriteLine($"\n\t\t\tChoose location:");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"\n\t\t\t1.Arena");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine($"\n\t\t\t2.Everest");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"\n\t\t\t3.Forest");
            Console.ResetColor();
        }
        public void printHeros()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n\t\t\t1.Warrior");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"\n\t\t\t2.Mage");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n\t\t\t3.Archer");
            Console.ResetColor();
        }
        public void printTotalDamage(int totalDamage, int totalDamage2)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"\nTotal damage Player one: {totalDamage} ");
            Console.WriteLine($"Total damage Player two: {totalDamage2} ");
            Console.ResetColor();
        }
        public void printRemainingHealth(Hero Player1, Hero Player2)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"Player one remaining health: {Player1.Health}");
            Console.WriteLine($"Player two remaining health: {Player2.Health}");
            Console.ResetColor();
        }
        public void printCurrentPlayerMove(string currentPlayer)
        {
            Console.WriteLine($"\n\t\t\t{currentPlayer} move:");
            Console.WriteLine("\t\t\t1.Attack\n\t\t\t2.Defence\n\t\t\t3.Heal\n\t\t\t4.Skill");
        }
        public void pressEnterMainMenu()
        {
            Console.WriteLine("\n\nPress enter to return to the main menu...");
        }
        public void pressEnterContinue()
        {
            Console.WriteLine("\n\nPress enter to continue...");

        }
        public void printSkillCdOne(int skillCounterPOne)
        {
            if (skillCounterPOne == 1)
            {
                Console.WriteLine($"Skill is on the cooldown!\n{skillCounterPOne} move left...");
            }
            else
            {
                Console.WriteLine($"Skill is on the cooldown!\n{skillCounterPOne} moves left...");

            }
        }
        public void printSkillCdTwo(int skillCounterPTwo)
        {
            if (skillCounterPTwo == 1)
            {
                Console.WriteLine($"Skill is on the cooldown!\n{skillCounterPTwo} move left...");
            }
            else
            {
                Console.WriteLine($"Skill is on the cooldown!\n{skillCounterPTwo} moves left...");

            }
        }

        public void printCrit()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nCritical strike!");
            Console.ResetColor();
        }

        public int printWarriorAttackType()
        {
            // Label control = (Label)Form.Controls["label1"];

            Form messageBox = new ChoseTypeAttackMessageForm("Choose attack type:", "Swords hail", "Axe strike");
            messageBox.ShowDialog();
            return ChoseTypeAttackMessageForm.ReturnNumber;
        }
        public int printMageAttackType()
        {
            Form messageBox = new ChoseTypeAttackMessageForm("Choose attack type:", "Meteor", "Blizzard");
            messageBox.ShowDialog();
            return ChoseTypeAttackMessageForm.ReturnNumber;
        }
        public int printArcherAttackType()
        {
            Form messageBox = new ChoseTypeAttackMessageForm("Choose attack type:", "Quick strike", "Multi shot");
            messageBox.ShowDialog();
            return ChoseTypeAttackMessageForm.ReturnNumber;
        }
        private void printChooseAttackType()
        {
            Console.WriteLine("\t\t\tChoose attack type:");
        }
        public void printPlOneDamage(string currentPlayer, int damage)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"\n{currentPlayer} dealt {damage} damage.");
            Console.ResetColor();
        }
        public void printPlTwoDamage(string currentPlayer, int damage2)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"\n{currentPlayer} dealt {damage2} damage.");
            Console.ResetColor();
        }
        public void printPlDefending(string currentPlayer)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{currentPlayer} started defending.");
            Console.ResetColor();
        }

        public void printPlHealed(string currentPlayer)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{currentPlayer} healed.");
            Console.ResetColor();
        }
        public void printPlayerWins(string currentPlayer)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"\n\t\t\t{currentPlayer} wins!");
            Console.ResetColor();
        }
        public void printStat(Statistics statistics, string fileName)
        {
            Console.WriteLine("\n\t\t\t\tStatistics");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n\t\t\tFight Number: {fileName}");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\t\t\tPlayer One Class: {statistics.classPlayerOne}");
            Console.WriteLine($"\t\t\tPlayer Two Class: {statistics.classPlayerTwo}");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\t\t\tTotal Damage Player One: {statistics.totalDamagePlayerOne}");
            Console.WriteLine($"\t\t\tTotal Damage Player Two: {statistics.totalDamagePlayerTwo}");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"\t\t\tWinner: {statistics.Winner}");
            Console.ResetColor();
        }
        public void printStartGame()
        {
            Console.WriteLine($"\n\nPress enter to start the game!");
            Console.ReadLine();
            Console.Clear();
        }
        public void printEnterFileName()
        {
            Console.WriteLine("\n\t\t\tEnter the file name (format: HH-mm-ss):");

        }
    }
}