using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Infrastructure.Controls.Elements
{
    public class DefaultElementFactory : IElementFactory
    {
        public static T GetElement<T>() where T : new()
        {
            var element = new T();            
            return element;
        }
    }
}
