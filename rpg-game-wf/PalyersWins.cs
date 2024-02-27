using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;

namespace C_CLASS25._11._2
{

    class PalyersWins
    {
        private static DateTime date = DateTime.Now;
        Statistics statistics = new Statistics(date.ToLongDateString());

        public bool whichPlayerWin(int totalDamage, int totalDamage2, string currentPlayer, Hero Player1, Hero Player2)
        {

            if (Player1.Health <= 0 || Player2.Health <= 0)
            {
                //BattlePrintMangaer.printPlayerWins(currentPlayer);

                //BattlePrintMangaer.printTotalDamage(totalDamage, totalDamage2);
//
               // BattlePrintMangaer.pressEnterMainMenu();

                statistics.Winner = currentPlayer;
                statistics.classPlayerOne = Player1.Name;
                statistics.classPlayerTwo = Player2.Name;
                statistics.totalDamagePlayerOne = totalDamage;
                statistics.totalDamagePlayerTwo = totalDamage2;

                string path = date.ToLongTimeString();
                path = path.Replace(":", "-");

                using (FileStream file = new FileStream($"..\\..\\{path}.json", FileMode.Create))
                {
                    JsonSerializer.Serialize<Statistics>(file, statistics);
                    Console.WriteLine(file.Name);
                }
                return true;
            }
            return false;
        }

    }
}