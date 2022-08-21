using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Task_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string jsonString = string.Empty;

            using (StreamReader sr = new StreamReader("../../../Products.json"))
            {
                jsonString = sr.ReadToEnd();
            }
            Products[] products = JsonSerializer.Deserialize<Products[]>(jsonString);
            Products maxProduct = products[0];
            foreach (Products c in products)
            {
                if (c.costProduct > maxProduct.costProduct)
                {
                    maxProduct = c;
                }
            }
            Console.WriteLine($"{maxProduct.codeProduct} {maxProduct.nameProduct} {maxProduct.costProduct}");
            Console.ReadKey();
        }
    }
}
