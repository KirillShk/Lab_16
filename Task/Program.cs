using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int n= 5;
            Products[] product = new Products[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Введите код товара");
                int CodeProduct = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите название товара");
                string NameProduct = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Введите сумму товара");
                double CostProduct = Convert.ToDouble(Console.ReadLine());
                product[i] = new Products() {codeProduct = CodeProduct, nameProduct = NameProduct, costProduct = CostProduct};
            }
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(product,options);
            using (StreamWriter sw = new StreamWriter("../../../Products.json"))
            {
                sw.WriteLine(jsonString);
            }

        }
    }
}
