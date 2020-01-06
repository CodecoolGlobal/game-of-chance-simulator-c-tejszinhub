using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfChanceSimulator
{
    class Fighter
    {
        //csv header Name,Hp,Dmg,Acc,NoS
        string Name;
        int Hp;
        int Damage;
        int Accuracy;
        int NumOfShots;

        public Fighter(string name, int hp, int damage, int accuracy, int numOfShots)
        {
            this.Name = name;
            this.Hp = hp;
            this.Damage = damage;
            this.Accuracy = accuracy;
            this.NumOfShots = numOfShots;
        }
        private void Attack(Fighter fighter1, Fighter fighter2)
        {
            Random random = new Random();
            if (random.Next(1,101) <= fighter1.Accuracy)
            {
                fighter2.Hp = fighter2.Hp - fighter1.Damage;
            }
            return;
        }

        private bool IsDead(Fighter fighter)
        {
            if (fighter.Hp <= 0)
            {
                return true;
            }
            return false;
        }

        public string Fight(Fighter fighter1, Fighter fighter2)
        {
            // deep copy fighter 1 and 2
            int gameLen;
            if (fighter1.NumOfShots >= fighter2.NumOfShots)
            {
                gameLen = fighter1.NumOfShots;
            }
            else
            {
                gameLen = fighter2.NumOfShots;
            }
            for (int i = 0; i < gameLen; i++)
            {
                if (fighter1.NumOfShots >= 1)
                {
                    Attack(fighter1, fighter2);
                    fighter1.NumOfShots--;
                    if (IsDead(fighter2))
                    {
                        return fighter1.Name; 
                    }
                }
                if (fighter2.NumOfShots >= 1)
                {
                    Attack(fighter2, fighter1);
                    fighter2.NumOfShots--;
                    if (IsDead(fighter1))
                    {
                        return fighter2.Name;
                    }
                }
            }
            if (fighter1.Hp>= fighter2.Hp)
            {
                return fighter1.Name;
            }
            return fighter2.Name;
        }
    }
}
