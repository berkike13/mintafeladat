using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonzolosApp
{
    public class Program
    {
        public static void Beolvas(List<Product> lista1, List<StockEntry> lista2, List<Supplier> lista3) 
        {
            foreach (string line in File.ReadLines("products_data.txt").Skip(1))
            {
                lista1.Add(new Product(line));
            }

            foreach (string line in File.ReadLines("stock_entries_data.txt").Skip(1))
            {
                lista2.Add(new StockEntry(line));
            }

            foreach (string line in File.ReadLines("suppliers_data.txt").Skip(1))
            {
                lista3.Add(new Supplier(line));
            }

            Console.WriteLine("Az adatok beolvasása megtörtént a products_data.txt és a stock_entries_data.txt valamint a suppliers_data.txt állományokból!");

        }

        public static void Feltoltes()
        {

        }
        static void Main(string[] args)
        {
            List<Product> lista1 = new List<Product>();
            List<StockEntry> lista2 = new List<StockEntry>();
            List<Supplier> lista3 = new List<Supplier>();

            Beolvas(lista1, lista2, lista3);

            //3/1 feladat
            Console.WriteLine("3/1 feladat: ");
            for (int i = 0; i < lista3.Count; i++) 
            {
                for (int j = 0; j < lista1.Count; j++) 
                {
                    for(int k = 0; k < lista2.Count; k++) 
                    {
                        if (lista2[k].Supplier_id == lista3[i].Id && lista2[k].Product_id == lista1[j].Id)
                            Console.WriteLine(lista1[j].Name + ", " + lista1[j].Quantity + " db " + "(Beszállító: " + lista3[k].Name + ")");
                    }
                }
            }
            //3/2 feladat
            Console.Write("3/2. feladat: Beszállító neve: ");
            string beszallito = Console.ReadLine();
            Console.WriteLine("MobileShop termékei:");
            for (int i = 0; i < lista3.Count; i++)
            {
                if (beszallito == lista3[i].Name)
                {
                    for (int j = 0; j < lista2.Count; j++)
                    {
                        if (lista3[i].Id == lista2[j].Supplier_id)
                        {
                            for (int k = 0; k < lista1.Count; k++)
                            {
                                if (lista2[j].Product_id == lista1[k].Id)
                                {
                                    Console.WriteLine("- " + lista1[k].Name + ", " + lista1[k].Quantity + " db");
                                }
                            }
                        }
                    }
                }
            }
            //3/3 feladat
            Console.Write("3/3. feladat: Legnagyobb készlettel rendelkező termék: ");
            int legnagyobb_keszlet = 0;
            for(int i = 0;i < lista1.Count; i++) 
            {
                if (lista1[i].Quantity > lista1[legnagyobb_keszlet].Quantity) 
                {
                    legnagyobb_keszlet = i;
                }
            }
            Console.Write(lista1[legnagyobb_keszlet].Name + " (" + lista1[legnagyobb_keszlet].Quantity + ")");

            //3/4 feladat
            Console.WriteLine("3/4. feladat: 2024.04.01 és 2024.06.30 közötti beszállítások:");
            DateTime kezdet = new DateTime(2024, 04, 01);
            DateTime veg = new DateTime(2024, 06, 30);
            
                for (int j = 0; j < lista1.Count; j++)
                {
                    for (int k = 0; k < lista2.Count; k++)
                    {
                    if (lista2[k].Product_id == lista1[j].Id)
                    {
                        if (lista2[k].Stock_date >= kezdet && lista2[k].Stock_date <= veg)
                            Console.WriteLine($"- {lista1[j].Name},  {lista2[k].Stock_date:yyyy-MM-dd}");
                    }
                    }
                }
    

            Console.ReadKey();
        }
    }
}
