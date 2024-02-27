using System;

namespace C_CLASS25._11._2
{
    public abstract class Hero
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int AttackPower { get; set; }
        public int ResistanceToPhysical { get; set; }
        public int ResistanceToMagical { get; set; }
        public int CriticalChance { get; set; }
        public int DodgeChance { get; set; }
        public bool IsDefending { get; set; }
        public enum AttackType
        {
            Physical,
            Magical
        }
        Random random = new Random();
        public enum BattleLocation
        {
            Arena,
            Everest,
            Forest
        }
        public double CalculateAttackOptions(String Name, double damageMultiplier, int CriticalChance, int typeAttack)
        {
            if (typeAttack == 1)
            {
                if (random.Next(1, 101) <= CriticalChance + 50)
                {
                    damageMultiplier *= 2;
                    // BattlePrintMangaer.printCrit();
                    return damageMultiplier -= 0.5;
                }
                return damageMultiplier -= 0.5;
            }
            else
            {
                return damageMultiplier += 0.5;
            }

        }

        public double attackOptions(String Name, double damageMultiplier, int CriticalChance)
        {
            double calculated = 1.0;

            if (Name == "Warrior")
            {
                int typeAttack = BattlePrintMangaer.Instance.printWarriorAttackType();
                return calculated = CalculateAttackOptions(Name, damageMultiplier, CriticalChance, typeAttack);
            }
            if (Name == "Mage")
            {
                int typeAttack = BattlePrintMangaer.Instance.printMageAttackType();
                return calculated = CalculateAttackOptions(Name, damageMultiplier, CriticalChance, typeAttack);

            }
            else
            {
                int typeAttack = BattlePrintMangaer.Instance.printArcherAttackType();
                return calculated = CalculateAttackOptions(Name, damageMultiplier, CriticalChance, typeAttack);
            }
        }
        public int CalculateDamage(int enemyAttackPower, AttackType enemyAttackType, int CriticalChance, String Name)
        {
            double damageMultiplier = 1.0;
        
            if (enemyAttackType == AttackType.Physical)
            {
                damageMultiplier -= ResistanceToPhysical / 100.0;
            }
            else
            {
                damageMultiplier -= ResistanceToMagical / 100.0;
            }

            return (int)(AttackPower * attackOptions(Name, damageMultiplier, CriticalChance));


        }
        public int Defend(int damage)
        {
            if (IsDefending)
            {
                damage -= 100;
                if (damage < 0) damage = 0;
                IsDefending = false;
            }

            Health -= damage;
            return damage;
        }


        public abstract void Location(BattleLocation location);

        public abstract int Skill(int damage);

        public abstract void Heal();

        public void StartDefending()
        {
            IsDefending = true;
        }

        public void StopDefending()
        {
            IsDefending = false;
        }

    }

}