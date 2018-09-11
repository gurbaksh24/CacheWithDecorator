using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorRuntimeCache
{
    class ExtraItem:Decorator
    {
        public ExtraItem(ICacheDecorator cacheDecorator):base(cacheDecorator)
        {

        }
        public override IEnumerable GetItems()
        {
            List<string> list = (List<string>)base.GetItems();
            list.Add("new item");
            return list;
        }
    }
}
