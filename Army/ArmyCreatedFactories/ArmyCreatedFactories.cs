﻿using System.Reflection;
using static System.Collections.Specialized.BitVector32;

namespace Magic
{
    abstract class ArmyCreatedFactories
    {
        /// <summary>
        /// Словарь с каждым unit и их соответствующей стоимостью.
        /// </summary>
        public readonly Dictionary<Type, int> unitCost;
        /// <summary>
        /// Фабрика создания unit.
        /// </summary>
        protected AbstractArmyFactory army;
        /// <summary>
        ///  Метод, который создаёт армию конкретного способа.
        /// </summary>
        /// <returns>Армию.</returns>
        public abstract List<IUnit> CreateArmy();
        public ArmyCreatedFactories(AbstractArmyFactory army) {
           
            // Выбираем конкретную фабрику создания unit.
            this.army = army;
            unitCost = [];
            // Получаем текущую сборку (assembly).
            Assembly assembly = Assembly.GetExecutingAssembly();

            // Получаем массив всех типов в текущей сборке.
            Type[] unitTypes = assembly.GetTypes()
                // Фильтруем только те типы, которые являются наследниками IUnit.
                .Where(t => t.IsSubclassOf(typeof(IUnit)))
                // Преобразуем результат в массив.
                .ToArray();

            // Перебираем каждый найденный тип.
            foreach (Type unitType in unitTypes)
            {
                // Получаем конструктор с параметрами для типа юнита.
                var constructor = unitType.GetConstructor([typeof((int, double))]);
                if (constructor != null)
                {
                    // Создаем экземпляр типа, передавая параметры конструктору.

                    // Добавляем тип IUnit и его стоимость в словарь.
                    if (constructor.Invoke(new object[] { (1, 1.0) }) is IUnit unitInstance)
                    {
                        unitCost.Add(unitType, unitInstance.Cost());
                    }
                }
            }
        }
        protected IUnit? CreateUnit(Type unitType)
        {
            if (unitType == typeof(LightWarrior))
            {
                return army.CreateLightUnit();
            }
            else if (unitType == typeof(HeavyWarrior))
            {
                return army.CreateHeavyUnitUnit();
            }
            else if (unitType == typeof(Genetic))
            {
                return army.CreateGeneticUnit();
            }
            else if (unitType == typeof(Doctor))
            {
                return army.CreateDoctorUnit();
            }
            else if (unitType == typeof(Bowman))
            {
                return army.CreateBowmanUnit();
            }
            else if (unitType == typeof(AdapterGulyayGorod))
            {
                return army.CreateGulyayGorodUnit();
            }
            return null;
        }
    }
}
