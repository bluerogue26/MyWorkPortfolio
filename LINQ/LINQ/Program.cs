using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.ExceptionServices;

namespace LINQ
{
    class Program
    {
        /* Practice your LINQ!
         * You can use the methods in Data Loader to load products, customers, and some sample numbers
         * 
         * NumbersA, NumbersB, and NumbersC contain some ints
         * 
         * The product data is flat, with just product information
         * 
         * The customer data is hierarchical as customers have zero to many orders
         */
        static void Main()
        {
            //PrintOutOfStock();

            //PrintHighCost();

            //WashingtonCustomers();

            //ProductNames();

            //ProductPriceBump();

            //NamesToUpper();

            //EvenStock();

            //RenamePrice();

            //NumCompare();

            //Under500();

            //First3();

            //Washington3();

            //Skip3();

            //Not2Washington();

            //LessThan6();

            //LessThanIndex();

            //DivisBy3();

            //Alphabetical();

            //DecendingInStock();

            //DoubleSort();

            //ReverseC();

            //GroupBy5();

            //GroupByCategory();

            //GroupByDate();

            //ListDistinct();

            //UniqueAb();

            //SameAb();

            //NotSameAb();

            //Just12();

            //CheckProductId();

            //CategoryOutStock();
 
            //LowerThan9();

            //CategoryInStock();

            //NumOfOdds();

            //NumOfOrders();

            //NumOfProducts();

            //TotalProducts();

            //LowestCost();

            //HighestCost();

            //AverageCost();

            Console.ReadLine();
        }

        private static void PrintOutOfStock()
        {
            var products = DataLoader.LoadProducts();

            var results = products.Where(p => p.UnitsInStock == 0);

            foreach (var product in results)
            {
                Console.WriteLine(product.ProductName);
            }
        }

        private static void PrintHighCost()
        {
            var products = DataLoader.LoadProducts();

            var results = products.Where(p => p.UnitsInStock != 0 && p.UnitPrice > 3);

            foreach (var product in results)
            {
                Console.WriteLine(product.ProductName);
            }
        }

        private static void WashingtonCustomers()
        {
            var customers = DataLoader.LoadCustomers();

            var results = customers.Where(c => c.Region == "WA");

            foreach (var customer in results)
            {
                Console.WriteLine(customer.CompanyName);
                foreach (var order in customer.Orders)
                {
                    Console.WriteLine("\t" + order.OrderID + " " + order.OrderDate);
                }
                Console.WriteLine("\n");
            }
        }

        private static void ProductNames()
        {
            var products = DataLoader.LoadProducts();

            var results = from p in products
                select p.ProductName;

            foreach (var r in results)
            {
                Console.WriteLine(r + "\n");
            }
        }

        private static void ProductPriceBump()
        {
            var products = DataLoader.LoadProducts();

            var results = from p in products
                select new {p.ProductName, UnitPrice = p.UnitPrice + (p.UnitPrice*25/100)};

            foreach (var r in results)
            {
                Console.WriteLine(r.ProductName);
                Console.WriteLine(r.UnitPrice + "\n");
            }
        }

        private static void NamesToUpper()
        {
            var products = DataLoader.LoadProducts();

            var results = from p in products
                select p.ProductName.ToUpper();

            foreach (var r in results)
            {
                Console.WriteLine(r + "\n");
            }
        }

        private static void EvenStock()
        {
            var products = DataLoader.LoadProducts();

            var results = products.Where(p => p.UnitsInStock%2 == 0);

            foreach (var r in results)
            {
                Console.WriteLine(r.ProductName + "\n");
            }
        }

        private static void RenamePrice()
        {
            var products = DataLoader.LoadProducts();

            var results = from p in products
                select new {p.ProductName, p.Category, Price = p.UnitPrice};

            foreach (var r in results)
            {
                Console.WriteLine(r.ProductName + "\n" + r.Category + "\n" + r.Price + "\n\n");
            }
        }

        private static void NumCompare()
        {
            var zipped = DataLoader.NumbersB.Zip(DataLoader.NumbersC,
                (b, c) => b < c ? b : c);
            var result = zipped.Intersect(DataLoader.NumbersB);

            foreach (var r in result)
            {
                Console.Write(r + "\t");
            }
        }

        private static void Under500()
        {
            var customers = DataLoader.LoadCustomers();

            var results = from c in customers
                from o in c.Orders
                where o.Total < 500
                select new {c.CustomerID, o.OrderID, o.Total};

            foreach (var r in results)
            {
                Console.WriteLine(r.CustomerID + "\t" + r.OrderID + "\t" + r.Total);
            }
        }

        private static void First3()
        {
            var numbers = DataLoader.NumbersA.Take(3);

            foreach (int num in numbers)
            {
                Console.Write(num + "\t");
            }
        }

        private static void Washington3()
        {
            var customers = DataLoader.LoadCustomers();

            var results = customers.Where(p => p.Region == "WA");

            foreach (var r in results)
            {
                int i = 0;
                foreach (var o in r.Orders)
                {
                    i++;
                    if (i > 3)
                        break;
                    Console.WriteLine(o.OrderID + "\t" + o.OrderDate + " \t" + o.Total);
                }
                Console.Write("\n");
            }
        }

        private static void Skip3()
        {
            var numbers = DataLoader.NumbersA.Skip(3);

            foreach (int num in numbers)
            {
                Console.Write(num + "\t");
            }
        }

        private static void Not2Washington()
        {
            var customers = DataLoader.LoadCustomers();

            var results = customers.Where(p => p.Region == "WA");

            foreach (var r in results)
            {
                int i = 0;
                foreach (var o in r.Orders)
                {
                    if (i < 2)
                        i++;
                    else
                    {
                        Console.WriteLine(o.OrderID + "\t" + o.OrderDate + "\t" + o.Total);
                    }
                    Console.Write("\n");
                }

            }
        }

        private static void LessThan6()
        {
            var numbers = DataLoader.NumbersC.TakeWhile(n => n < 6);

            foreach (int r in numbers)
            {
                Console.Write(r + "\t");
            }
        }

        private static void LessThanIndex()
        {
            var results = DataLoader.NumbersC.TakeWhile((r, i) => r > i);

            foreach (int r in results)
            {
                Console.Write(r + "\t");
            }
        }

        private static void DivisBy3()
        {
            var numbers = DataLoader.NumbersC.SkipWhile(n => n%3 != 0);

            foreach (int n in numbers)
            {
                Console.WriteLine(n);
            }
        }

        private static void Alphabetical()
        {
            var products = DataLoader.LoadProducts();

            var results = products.OrderBy(n => n.ProductName);

            foreach (var r in results)
            {
                Console.WriteLine(r.ProductName);
            }
        }

        private static void DecendingInStock()
        {
            var products = DataLoader.LoadProducts();

            var results = products.OrderByDescending(n => n.UnitsInStock);

            foreach (var r in results)
            {
                Console.WriteLine(r.ProductName + "\t" + r.UnitsInStock);
            }
        }

        private static void DoubleSort()
        {
            var products = DataLoader.LoadProducts();

            var results = products.OrderBy(p => p.Category).ThenByDescending(p => p.UnitPrice);

            foreach (var r in results)
            {
                Console.WriteLine(r.Category + "\t" + r.ProductName + "\t" + r.UnitPrice);
            }
        }

        private static void ReverseC()
        {
            var numbers = DataLoader.NumbersC.Reverse();

            foreach (var n in numbers)
            {
                Console.WriteLine(n);
            }
        }

        private static void GroupBy5()
        {
            var numbers = DataLoader.NumbersC.GroupBy(n => n%5);

            foreach (var group in numbers)
            {
                Console.WriteLine(group.Key);
                foreach (var n in group)
                {
                    Console.WriteLine("\t" + n);
                }
            }
        }

        private static void GroupByCategory()
        {
            var products = DataLoader.LoadProducts();

            var results = from p in products 
                          group p by p.Category into newGroup
                          orderby newGroup.Key
                              select newGroup;

            foreach (var group in results)
            {
                Console.WriteLine(group.Key);
                foreach (var r in group)
                {
                    Console.WriteLine("\t" + r.ProductName);
                }
                Console.WriteLine("\n");
            }
        }

        /*private static void GroupByDate()
        {
            var customers = DataLoader.LoadCustomers();

            foreach (var c in customers)
            {
                var byYear = from c in customers
                    from o in c.Orders
                    group o by o.OrderDate.Year
                    into newGroup1
                    select newGroup1;// group by year

                foreach (var y in byYear)
                {
                    
                }
            }
        }*/

        private static void ListDistinct()
        {
            var customers = DataLoader.LoadProducts().Select(p => p.Category).Distinct();

            foreach (var c in customers)
            {
                Console.WriteLine(c);
            }
        }

        private static void UniqueAb()
        {
            var concat = DataLoader.NumbersA.Concat(DataLoader.NumbersB);
            var results = concat.Distinct();

            foreach (var r in results)
            {
                Console.WriteLine(r);
            }
        }

        private static void SameAb()
        {
            var a = DataLoader.NumbersA;
            var b = DataLoader.NumbersB;

            List<int> sameNums = new List<int>();

            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < b.Length; j++)
                {
                    if (a[i] == b[j])
                    {
                        sameNums.Add(a[i]);
                    }
                }
            }

            foreach (var r in sameNums)
            {
                Console.WriteLine(r);
            }
        }

        private static void NotSameAb()
        {
            var a = DataLoader.NumbersA;
            var b = DataLoader.NumbersB;
            List<int> results = new List<int>();
            bool sameNum = false;
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < b.Length; j++)
                {
                    if (a[i] == b[j])
                    {
                        sameNum = true;
                    }
                }
                if (sameNum == false)
                {
                    results.Add(a[i]);
                }
                else
                {
                    sameNum = false;
                }
            }
            var finalResults = results.Distinct();

            foreach (var r in finalResults)
            {
                Console.WriteLine(r);
            }
        }

        private static void Just12()
        {
            var item = DataLoader.LoadProducts().Single(p => p.ProductID == 12);

            Console.WriteLine(item.ProductName);
        }

        private static void CheckProductId()
        {
            var products = DataLoader.LoadProducts();

            Console.WriteLine("Was it there? Survey says : {0}", products.Exists(p => p.ProductID == 789));
        }

        private static void CategoryOutStock()
        {
            var products = DataLoader.LoadProducts();

            var results = from p in products
                group p by p.Category
                into newGroup
                where newGroup.Any(p => p.UnitsInStock == 0)
                select new {Category = newGroup.Key, products = newGroup};
            foreach (var r in results)
            {
                Console.WriteLine(r.Category);
            }

        }

        private static void LowerThan9()
        {
            var numbers = DataLoader.NumbersB.All(n => n < 9);

            Console.WriteLine("Is there a number higher than nine? Survey says : {0}", numbers);
        }

        private static void CategoryInStock()
        {
            var products = DataLoader.LoadProducts();

            var results = from p in products
                          group p by p.Category
                              into newGroup
                              where newGroup.All(p => p.UnitsInStock != 0)
                              select new { Category = newGroup.Key, products = newGroup };
            foreach (var r in results)
            {
                Console.WriteLine(r.Category, r.products);
            }

        }

        private static void NumOfOdds()
        {
            var numbers = DataLoader.NumbersA.Count(p => p%2 != 0);

            Console.WriteLine(numbers);
        }

        private static void NumOfOrders()
        {
            var customers = DataLoader.LoadCustomers();

            foreach (var c in customers)
            {
                Console.WriteLine(c.CompanyName);
                Console.WriteLine("\t" + c.Orders.Count());
            }
        }

        private static void NumOfProducts()
        {
            var products = DataLoader.LoadProducts().GroupBy(p => p.Category);

            foreach (var group in products)
            {
                Console.WriteLine(group.Key);
                Console.WriteLine("\t" + group.Count());
            }
        }

        private static void TotalProducts()
        {
            var products = DataLoader.LoadProducts().GroupBy(p => p.Category);
            int count = 0;

            foreach (var group in products)
            {
                Console.WriteLine(group.Key);
                foreach (var p in group)
                {
                    count += p.UnitsInStock;
                }
                Console.WriteLine("\t" + count);
            }
        }

        private static void LowestCost()
        {
            var products = DataLoader.LoadProducts();

            var results = from p in products
                group p.UnitPrice by p.Category
                into newGroup
                select new {category = newGroup.Key, minPrice = newGroup.Min()};

            foreach (var group in results)
            {
                Console.WriteLine(group.category);
                Console.WriteLine(group.minPrice);
            }
        }

        private static void HighestCost()
        {
            var products = DataLoader.LoadProducts();

            var results = from p in products
                group p.UnitPrice by p.Category
                into newGroup
                select new {category = newGroup.Key, maxPrice = newGroup.Max()};

            foreach (var group in results)
            {
                Console.WriteLine(group.category);
                Console.WriteLine(group.maxPrice);
            }
        }

        private static void AverageCost()
        {
            var products = DataLoader.LoadProducts();

            var results = from p in products
                          group p.UnitPrice by p.Category
                              into newGroup
                              select new { category = newGroup.Key, averagePrice = newGroup.Average() };

            foreach (var group in results)
            {
                Console.WriteLine(group.category);
                Console.WriteLine(group.averagePrice);
            }
        }
    }
}
