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

        public Fighter(Fighter fighter)
        {
            this.Name = fighter.Name;
            this.Hp = fighter.Hp;
            this.Damage = fighter.Damage;
            this.Accuracy = fighter.Accuracy;
            this.NumOfShots = fighter.NumOfShots;
        }

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
            if (random.Next(1, 101) <= fighter1.Accuracy)
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
            var fighterA = new Fighter(fighter1);
            var fighterB = new Fighter(fighter2);
            int gameLen;

            if (fighterA.NumOfShots >= fighterB.NumOfShots)
            {
                gameLen = fighterA.NumOfShots;
            }
            else
            {
                gameLen = fighterB.NumOfShots;
            }
            for (int i = 0; i < gameLen; i++)
            {
                if (fighter1.NumOfShots >= 1)
                {
                    Attack(fighterA, fighterB);
                    fighterA.NumOfShots--;
                    //Console.WriteLine("copy 2 : " + fighterB.Hp + "eredeti " + fighter2.Hp);
                    if (IsDead(fighterB))
                    {
                        return fighterA.Name;
                    }
                }
                if (fighterB.NumOfShots >= 1)
                {
                    Attack(fighterB, fighterA);
                    fighterB.NumOfShots--;
                    //Console.WriteLine("copy 1 : " + fighterA.Hp + "eredeti " + fighter1.Hp);
                    if (IsDead(fighterA))
                    {
                        return fighterB.Name;
                    }
                }
            }
            if (fighterA.Hp >= fighterB.Hp)
            {
                return fighterA.Name;
            }
            return fighterB.Name;
        }
    }
}
