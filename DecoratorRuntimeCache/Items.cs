using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
namespace DecoratorRuntimeCache
{
    class Items:ICacheDecorator
    {
        private string _cache;
        public Items()
        {
            _cache = "itemCache";
        }
        public string getCacheKey()
        {
            return _cache;
        }
        public IEnumerable GetItems()
        {
            ObjectCache cache = MemoryCache.Default;
            if (cache.Contains(_cache))
                return (IEnumerable)cache.Get(_cache);
            else
            {
                IEnumerable availableItems = this.GetDefaultItems();
                CacheItemPolicy cacheItemPolicy = new CacheItemPolicy();
                cacheItemPolicy.AbsoluteExpiration = DateTime.Now.AddHours(1.0);
                cache.Add(_cache, availableItems, cacheItemPolicy);
                return availableItems;
            }
        }
        public List<MyData> GetDefaultItems()
        {
            DataItemsEntities dataItemsEntities = new DataItemsEntities();
            List<MyData> data = dataItemsEntities.MyDatas.ToList();
            return data;
        }
    }
}
