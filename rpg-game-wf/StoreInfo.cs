using C_CLASS25._11._2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace rpg_game_wf
{
    class StoreInfo
    {

        private StoreInfo() { }
        public static bool isPlayer1Turn = true;

        public static Hero Player1 = null;

        public static Hero Player2 = null;

        public static FightMain fightMain = new FightMain();
        public static FightManager fightManager = new FightManager();

        public static int totalDamage = 0;
        public static int totalDamage2 = 0;
        public static int totalDamagePlayerOne = 0;
        public static int totalDamagePlayerTwo = 0;

        public static DateTime date = DateTime.Now;
        public static Statistics statistics = new Statistics(date.ToLongDateString());

    }
}
