
namespace Magic
{
    class Genetic : IUnit, ISpecialProperty, IHealtheble
    {
        public override string Name() => name ?? "";
        /// <summary>
        /// ������� ������������ - 10%.
        /// </summary>
        readonly double procentClone = 0.1;
        public Genetic((int, double) percentAttackAndDodge) : base(percentAttackAndDodge)
        {
            attack += 20;
            cost = 5;
            dodge += 0.4;
            defense = 10;
            name = "�������";
        }

        public override string ToString()
        {
            return string.Format($"{Name()}. ��������: {health} ����: {attack} ���������: {cost} ����� {defense}  ��������� {dodge} ");
        }

        public void Heal(int powerTreatment)
        {
            // ������ ������ ������, ��� ������������ ��������.
            health = (health + powerTreatment) < Settings.GetInstance(0, 0).Health ? (health + powerTreatment) : Settings.GetInstance(0, 0).Health;
        }
        public override void GetHit(int strengthAttack)
        {
            Random random = new();
            double randomNumber = random.NextDouble();
            //���� ��������� �� ��������� => unit �������� ����.
            if (dodge < randomNumber)
            {
                if (defense >= strengthAttack) defense -= strengthAttack;
                else if (defense < strengthAttack && defense > 0)
                {
                    int x = strengthAttack - defense;
                    defense = 0;
                    health -= x;
                }
                else health -= strengthAttack;
            }
        }
        public override int Health()
        {
            return health;
        }
        public override int Attack()
        {
            return attack;
        }
        public override int Defense()
        {
            return defense;
        }
        public override double Dodge()
        {
            return dodge;
        }
        public override int Cost()
        {
            return cost;
        }

        public override IUnit MakeClone()
        {
            var a = new Genetic((attack - 20, dodge - 0.4))
            {
                health = health,
                defense = defense
            };
            return new LogGetAttack(a, (attack - 20, dodge - 0.4));
        }

        public IUnit? DoSpecialProperty�olumn(List<IUnit> ownArmy, List<IUnit> enemyArmy, int number)
        {
            if (procentClone >= new Random().NextDouble())
            {
                for (int i = 0; i < ownArmy.Count; i++)
                {
                    if (ownArmy[i] is LogGetAttack lightUnit && lightUnit.unit is ICloneable clone)
                    {
                        return clone.Clone();
                    }
                }
            }
            return null;
        }

        public IUnit? DoSpecialPropertyBattalion(List<IUnit> ownArmy, List<IUnit> enemyArmy, int number)
        {
            if (procentClone >= new Random().NextDouble())
            {
                for (int i = 0; i < ownArmy.Count; i++)
                {
                    if (ownArmy[i] is LogGetAttack lightUnit && lightUnit.unit is ICloneable clone)
                    {
                        return clone.Clone();
                    }
                }
            }
            return null;
        }

        public IUnit? DoSpecialPropertyWallToWall(List<IUnit> ownArmy, List<IUnit> enemyArmy, int number)
        {
            if (procentClone >= new Random().NextDouble())
            {
                for (int i = 0; i < ownArmy.Count; i++)
                {
                    if (ownArmy[i] is LogGetAttack lightUnit && lightUnit.unit is ICloneable clone)
                    {
                        return clone.Clone();
                    }
                }
            }
            return null;
        }
    }
}