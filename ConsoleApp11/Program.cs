using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ConsoleApp11
{
    class Program
    {
        static string conectionString = @"Data Source=USER-PC\SQLEXPRESS;Initial Catalog=master;Trusted_Connection=yes;";

        static void Main(string[] args)
        {
            List<VeggieAndFruit> veggieAndFruits = GetVeggieAndFruit();

            //var query1 = veggieAndFruits.ToList();
            //foreach(var item in query1)
            //{
            //    Console.WriteLine($"ID: {item.Id}");
            //    Console.WriteLine($"Name: {item.NameFruit}");
            //    Console.WriteLine($"Type fruit: {item.TypeFruit}");
            //    Console.WriteLine($"Color: {item.Color}");
            //    Console.WriteLine($"Calories: {item.Calories}");
            //    Console.WriteLine();
            //}

            //foreach (var item in query1)
            //{
            //    Console.WriteLine($"Name: {item.NameFruit}");
            //}

            //foreach (var item in query1)
            //{
            //    Console.WriteLine($"Color: {item.Color}");
            //}

            //var query2 = veggieAndFruits.Max(m => m.Calories);
            //Console.WriteLine($"Максимальная каллорийность: {query2}");
            //var query3 = veggieAndFruits.Min(m => m.Calories);
            //Console.WriteLine($"Минимальная каллорийность: {query3}");
            //var query4 = veggieAndFruits.Average(m => m.Calories);
            //Console.WriteLine($"Средняя каллорийность: {query4}");


            //var query5 = veggieAndFruits.Count(c => c.TypeFruit == "Veggie");
            //Console.WriteLine($"Колличество овощей: {query5}");
            //var query6 = veggieAndFruits.Count(c => c.TypeFruit == "Fruit");
            //Console.WriteLine($"Колличество фруктов: {query6}");
            //var query7 = veggieAndFruits.Count(c => c.Color == "Green");
            //Console.WriteLine($"Колличество фруктов и овощей определенного цвета: {query7}");


            //string[] colors = new string[veggieAndFruits.Count()];
            //int v = 0;
            //foreach (var item in veggieAndFruits)
            //{
            //    colors[v] = item.Color;
            //    v++;
            //}

            //var hashset = new HashSet<string>();
            //foreach (var x in colors)
            //{ 
            //    if (!hashset.Contains(x))
            //    { 
            //        hashset.Add(x);
            //    }
            //}
            //Array.Resize(ref colors, hashset.Count); 
            //colors = hashset.ToArray();

            //int[] query8 = new int[colors.Count()];
            //for (int i = 0; i < colors.Count(); i++)
            //{
            //    query8[i] = veggieAndFruits.Count(c => c.Color == colors[i]);
            //    Console.WriteLine($"Кол-во фруктов и овощей такого цвета {colors[i]}: {query8[i]}");
            //}


            //Console.Write("Введите максимальную допустимую каллорийность: ");
            //int YourCal = Convert.ToInt32(Console.ReadLine());
            //var query9 = veggieAndFruits.Where(w => w.Calories < YourCal).ToList();
            //foreach (var item in query9)
            //{
            //    Console.WriteLine($"ID: {item.Id}");
            //    Console.WriteLine($"Name: {item.NameFruit}");
            //    Console.WriteLine($"Type fruit: {item.TypeFruit}");
            //    Console.WriteLine($"Color: {item.Color}");
            //    Console.WriteLine($"Calories: {item.Calories}");
            //    Console.WriteLine();
            //}

            //Console.Write("Введите минимальную допустимую каллорийность: ");
            //YourCal = Convert.ToInt32(Console.ReadLine());
            //var query10 = veggieAndFruits.Where(w => w.Calories > YourCal).ToList();
            //foreach (var item in query10)
            //{
            //    Console.WriteLine($"ID: {item.Id}");
            //    Console.WriteLine($"Name: {item.NameFruit}");
            //    Console.WriteLine($"Type fruit: {item.TypeFruit}");
            //    Console.WriteLine($"Color: {item.Color}");
            //    Console.WriteLine($"Calories: {item.Calories}");
            //    Console.WriteLine();
            //}

            //Console.Write("Введите начало диапазона каллорийности: ");
            //int CalA = Convert.ToInt32(Console.ReadLine());
            //Console.Write("Введите конец диапазона каллорийности: ");
            //int CalB = Convert.ToInt32(Console.ReadLine());
            //var query11 = veggieAndFruits.Where(w => w.Calories > CalA && w.Calories < CalB).ToList();
            //foreach (var item in query11)
            //{
            //    Console.WriteLine($"ID: {item.Id}");
            //    Console.WriteLine($"Name: {item.NameFruit}");
            //    Console.WriteLine($"Type fruit: {item.TypeFruit}");
            //    Console.WriteLine($"Color: {item.Color}");
            //    Console.WriteLine($"Calories: {item.Calories}");
            //    Console.WriteLine();
            //}

            var query12 = veggieAndFruits.Where(w => w.Color == "Red" || w.Color == "Yellow").ToList();
            foreach (var item in query12)
            {
                Console.WriteLine($"ID: {item.Id}");
                Console.WriteLine($"Name: {item.NameFruit}");
                Console.WriteLine($"Type fruit: {item.TypeFruit}");
                Console.WriteLine($"Color: {item.Color}");
                Console.WriteLine($"Calories: {item.Calories}");
                Console.WriteLine();
            }
        }

        public static List<VeggieAndFruit> GetVeggieAndFruit()
        {
            List<VeggieAndFruit> veggieAndFruit = new List<VeggieAndFruit>();

            using (SqlConnection con = new SqlConnection(conectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from VeggieAndFruit";

                var reder = cmd.ExecuteReader();
                while (reder.Read())
                {
                    VeggieAndFruit veggieAndFruit1 = new VeggieAndFruit();
                    veggieAndFruit1.Id = Convert.ToInt32(reder[0]);
                    veggieAndFruit1.NameFruit = reder[1].ToString();
                    veggieAndFruit1.TypeFruit = reder[2].ToString();
                    veggieAndFruit1.Color = reder[3].ToString();
                    veggieAndFruit1.Calories = Convert.ToInt32(reder[4]);

                    veggieAndFruit.Add(veggieAndFruit1);
                }
            }

            return veggieAndFruit;
        }
    }
}