using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Text.Json.Serialization;
using System.IO;
/*
 * 2.    Необходимо разработать программу для получения информации о товаре из json-файла.
 *  Десериализовать файл «Products.json» из задачи 1. Определить название самого дорогого товара.
 */
namespace Zadanie_16_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "C:\\Temp\\Products.json";
            double maxCost = 0;
            int maxCostIndex = 0;

            Console.WriteLine("Задание 16-1. Запись информации в json файл.");
            Console.WriteLine("--------------------------------------------");
            Product[] products = new Product[5];

            using (StreamReader streamReader = new StreamReader(fileName))
            {
                for (int i = 0; i < products.Length; i++)
                {
                    products[i] = new Product();
                    string jsonProducts = streamReader.ReadLine();
                    products[i] = JsonSerializer.Deserialize<Product>(jsonProducts);
                    if (products[i].ProductCost > maxCost)
                    {
                        maxCost = products[i].ProductCost;
                        maxCostIndex = i;
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine("Самый дорогой товар в списке: {0}, его цена: {1} руб.", products[maxCostIndex].ProductName, products[maxCostIndex].ProductCost);
            Console.ReadKey();

        }

    }

    class Product
    {
        public int ProductCode { get; set; }
        public string ProductName { get; set; }
        public double ProductCost { get; set; }
    }
}
