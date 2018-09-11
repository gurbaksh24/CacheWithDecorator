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
            List<string> availableItems = (List<string>)items.GetItems();
            List<string> defaultItems = (List<string>)items.GetDefaultItems();


            string cacheKey = "itemCache";
            ObjectCache cache = MemoryCache.Default;
            List<string> itemsFromCache = (List<string>)cache.Get(cacheKey);
            Console.WriteLine("Item Before Decoration");
            foreach (string list in itemsFromCache)
            {
                Console.WriteLine(list);
            }

            Console.WriteLine("Item After Decoration");
            ICacheDecorator objCache = new Items();
            Decorator decorator = new ExtraItem(objCache);
            foreach(string list in decorator.GetItems())
            {
                Console.WriteLine(list);
            }
            Console.ReadKey();
        }
    }
}
