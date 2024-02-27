using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace C_CLASS25._11._2
{

    internal class FightMain
    {
        private int totalDamage = 0;
        private int totalDamage2 = 0;

        FightManager fightManager = new FightManager();

        public void runFight(bool isPlayer1Turn, Hero Player1, Hero Player2, string currentPlayer)
        {
            fightManager.runFight(totalDamage, totalDamage2, isPlayer1Turn, Player1, Player2, currentPlayer);
        }
    }
}