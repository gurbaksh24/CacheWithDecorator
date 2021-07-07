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
            List<MyData> list = (List<MyData>)base.GetItems();
            MyData myData = new MyData();
            myData.id = 102;
            myData.name = "pencil";
            myData.price = 5;
            list.Add(myData);
            return list;
        }
    }
}
