﻿
namespace Magic
{
    internal class Program
    {
        static void Main()
        {
            Settings aa = Settings.GetInstance(100, 100);
            Bowman b = new((5,-5));
            Console.WriteLine(b.ToString());
            b.GetHit(11);
            Console.WriteLine(b.ToString());
            LogGetAttack a = new(b, (1, 1));
            Console.WriteLine(a.ToString());
            a.GetHit(10);
            Console.WriteLine(a.ToString());
            /*Console.Beep(300, 500);
            Console.Beep(300, 500);
            Console.Beep(300, 500);
            Console.Beep(250, 500);
            Console.Beep(350, 250);
            Console.Beep(300, 500);
            Console.Beep(250, 500);*/
            User.UserGame();
            //Settings settings = Settings.GetInstance(4, 5);
           /* HeavyWarrior a = new(settings, (1, 1));
            a.Print();
            HeavyWarrior b = new(settings, (2, 2));
            b.Print();
            Console.WriteLine(b.Attack);
            a.GetHit(b.Attack);
            a.Attack(b);
            a.Attack(b);
            a.Print();
            b.Print();*/
            /*AbstractArmyFactory aA = new AttackArmy(); //с атакой
            ArmyCreatedFactories bB = new RandomArmy(aA, settings); // балансированно (в параментрах передаём абстрактну фабрику!)
            List<IUnit> army = bB.CreateArmy(100);
            foreach(IUnit unit in army)
            {
                Console.WriteLine(unit.ToString());
            }*/

        }
    }
}
