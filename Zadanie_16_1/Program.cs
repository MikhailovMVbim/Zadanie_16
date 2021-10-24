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
 * 1.    Необходимо разработать программу для записи информации о товаре в текстовый файл в формате json.
 * Разработать класс для моделирования объекта «Товар». Предусмотреть члены класса «Код товара» (целое число), 
 * «Название товара» (строка), «Цена товара» (вещественное число).
 * Создать массив из 5-ти товаров, значения должны вводиться пользователем с клавиатуры.
 * Сериализовать массив в json-строку, сохранить ее программно в файл «Products.json».
 */



namespace Zadanie_16_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "C:\\Temp\\Products.json";

            Console.WriteLine("Задание 16-1. Запись информации в json файл.");
            Console.WriteLine("--------------------------------------------");
            Product [] products = new Product [5];
            for (int i = 0; i < products.Length; i++)
            {
                Console.WriteLine("Введите данные продукта №{0}: ", i+1);
                products[i] = new Product();
                Console.Write("Название товара: ");
                products[i].ProductName = Console.ReadLine();
                Console.Write("Код товара: ");
                products[i].ProductCode = Convert.ToInt32(Console.ReadLine());
                Console.Write("Цена товара: ");
                products[i].ProductCost = Convert.ToDouble(Console.ReadLine());
            }

            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic)
            };


            if (!File.Exists(fileName))
            {
                File.Create(fileName).Close();
            }

            using (StreamWriter streamWriter = new StreamWriter(fileName))
            {
                for (int i = 0; i < products.Length; i++)
                {
                    string jsonProducts = JsonSerializer.Serialize(products[i], options);
                    streamWriter.WriteLine(jsonProducts);
                }
            }
            Console.ReadKey();
        }
    }

    class Product
    {
        public int ProductCode { get; set; }
        public string ProductName { get; set; }
        public double ProductCost{ get; set; }
    }
}
