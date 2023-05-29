using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class PropertyCheckerStrategy : IPropertyChecker
    {
        //public bool PropertyExists(List<Type> classes, string propertyName)
        //{
        //    foreach (Type classType in classes)
        //    {
        //        PropertyInfo property = classType.GetProperty(propertyName);
        //        if (property != null)
        //        {
        //            return true;
        //        }
        //    }

        //    return false;
        //}
        public bool PropertyExists(List<Type> classes, Type propertyName) => 
            classes.Exists(classType => propertyName != null);

    }
}
