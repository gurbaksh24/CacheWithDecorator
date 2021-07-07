using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
namespace DecoratorRuntimeCache
{
    class Program
    {
        static void Main(string[] args)
        {
            Items items = new Items();
            List<MyData> availableItems = (List<MyData>)items.GetItems();
            List<MyData> defaultItems = (List<MyData>)items.GetDefaultItems();


            string cacheKey = "itemCache";
            ObjectCache cache = MemoryCache.Default;
            List<MyData> itemsFromCache = (List<MyData>)cache.Get(cacheKey);
            Console.WriteLine("Item Before Decoration");
            foreach (MyData list in itemsFromCache)
            {
                Console.Write("Id: "+list.id+"\t");
                Console.Write("Name: "+list.name+"\t");
                Console.WriteLine("Price: "+list.price);
            }

            Console.WriteLine("Item After Decoration");
            ICacheDecorator objCache = new Items();
            Decorator decorator = new ExtraItem(objCache);
            foreach(MyData list in decorator.GetItems())
            {
                Console.Write("Id: " + list.id + "\t");
                Console.Write("Name: " + list.name + "\t");
                Console.WriteLine("Price: " + list.price);
            }
            Console.ReadKey();
        }
    }
}
