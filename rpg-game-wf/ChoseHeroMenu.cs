using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace C_CLASS25._11._2
{
    class ChoseHeroMenu
    {
        ChooseHero cHero = new ChooseHero();
        FightMain fightMain = new FightMain();

        private bool isPlayer1Turn = true;
        public void chooseHeroMenu()
        {
            while (true)
            {
                ConsoleKeyInfo loc;

                Console.Clear();

                string currentPlayer = isPlayer1Turn ? "Player one" : "Player two";

                Hero Player1 = cHero.chooseHero("Player one");
                Console.Clear();
                Hero Player2 = cHero.chooseHero("Player two");
                Console.Clear();

                //BattlePrintMangaer.printChooseLoc();

                loc = Console.ReadKey();

                if (loc.KeyChar == '1')
                {
                    Player1.Location(Hero.BattleLocation.Arena);
                    Player2.Location(Hero.BattleLocation.Arena);
                }
                else if (loc.KeyChar == '2')
                {
                    Player1.Location(Hero.BattleLocation.Everest);
                    Player2.Location(Hero.BattleLocation.Everest);
                }
                else if (loc.KeyChar == '3')
                {
                    Player1.Location(Hero.BattleLocation.Forest);
                    Player2.Location(Hero.BattleLocation.Forest);
                }
                Console.Clear();

                //BattlePrintMangaer.printStartGame();

                fightMain.runFight(isPlayer1Turn, Player1, Player2, currentPlayer);

                break;
            }
        }

    }
}