using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    interface IPropertyChecker
    {
        bool PropertyExists(List<Type> classes, Type propertyName);
    }
}
