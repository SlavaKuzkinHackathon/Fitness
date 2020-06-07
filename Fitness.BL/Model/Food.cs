﻿using System;

namespace Fitness.BL.Model
{
    [Serializable]

    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Callories { get; set; }
        /// <summary>
        /// Белки
        /// </summary>
        public double Proteins { get; set; }
        /// <summary>
        /// Жиры
        /// </summary>
        public double Fats { get; set; }
        public double Carbohydates { get; set; }

        /// <summary>
        /// Углеводы
        /// </summary>
        public double Carbohydrates { get; set; }
        /// <summary>
        /// калории за 100 грамм продукта
        /// </summary>
        public double Calories { get; set; }


        public Food(string name) : this(name, 0, 0, 0, 0) { }

        public Food(string name, double callories, double proteins,
            double fats, double carbohydates) {
            //TODO: Проверка
            Name = name;
            Callories = callories / 100.0;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydates = carbohydates / 100.0;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}

//private double CalloriesOneGramm { get { return Callories / 100.0; } }
//private double ProteinsOneGramm { get { return Proteins / 100.0; } }
//private double FactsOneGramm { get { return Fats / 100.0; } }
//private double CarbohydratesOneGramm { get { return Carbohydrates / 1000.0; } }
