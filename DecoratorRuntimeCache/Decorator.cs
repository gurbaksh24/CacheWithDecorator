using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorRuntimeCache
{
    class Decorator:ICacheDecorator
    {
        private ICacheDecorator _cacheDecorator;
        public Decorator(ICacheDecorator cacheDecorator)
        {
            _cacheDecorator = cacheDecorator;
        }

        public virtual IEnumerable GetItems()
        {
            return this._cacheDecorator.GetItems();
        }
        
        
    }
}
