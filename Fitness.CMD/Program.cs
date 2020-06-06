﻿using Fitness.BL.Controller;
using Fitness.BL.Model;
using System;
using System.Globalization;
using System.Resources;

namespace Fitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var culture = CultureInfo.CreateSpecificCulture("en-us");
            var resourceManager = new ResourceManager("Fitness.CMD.Languages.Messages", typeof(Program).Assembly);

            Console.WriteLine(resourceManager.GetString("Hello", culture));

            Console.WriteLine(resourceManager.GetString("EnterName",culture));
            var name = Console.ReadLine();
            
            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            if (userController.IsNewUser)
            {
                Console.Write("EnterGender", culture);
                var gender = Console.ReadLine();
                var birthDate = ParseDataTime();
                var weight = ParseDouble("вес");
                var height = ParseDouble("рост");

                userController.SetNewUserData(gender, birthDate, weight, height);
            }

            Console.WriteLine(userController.CurrentUser);

            Console.WriteLine("Что вы хотите сделать");
            Console.WriteLine("E-ввести прием пищи");
            var key = Console.ReadKey();
            Console.WriteLine();
            if (key.Key == ConsoleKey.E)
            {
                var foods = EnterEating();
                eatingController.Add(foods.Food, foods.Weight);

                foreach (var item in eatingController.Eating.Foods) {
                    Console.WriteLine($"\t{item.Key} - {item.Value}");
                }
            }

            Console.ReadLine();
        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.WriteLine("Введите имя продукта");
            var food = Console.ReadLine();
            
            var calories = ParseDouble("калорийность");
            var prot = ParseDouble("белки");
            var fats = ParseDouble("жиры");
            var carbs = ParseDouble("углеводы");
         
            var weight = ParseDouble("Вес порции");
            var product = new Food(food, calories, prot, fats, carbs);

            return (Food: product, Weight: weight);
        }

        private static DateTime ParseDataTime()
        {
            DateTime birthDate;
            while (true)
            {
                Console.Write("Введите дату рождения(dd.MM.yy): ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Неверный формат даты");
                }
            }

            return birthDate;
        }

        private static double ParseDouble(string name) {
            while (true)
            {
                Console.Write($"Введите {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine("Неверный формат поля {name}");
                }
            }
        }
    }
    
}
