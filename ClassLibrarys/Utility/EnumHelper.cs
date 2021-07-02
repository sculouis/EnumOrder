using System;
using System.Collections.Generic;
using System.Linq;
using ClassLibrarys.Attributes;

namespace ClassLibrarys.Utility
{
    public static class EnumHelper
    {
        public static T[] SortEnum<T>()
        {
            Type myEnumType = typeof(T);
            var enumValues = Enum.GetValues(myEnumType).Cast<T>().ToArray();
            var enumNames = Enum.GetNames(myEnumType);
            int[] enumPositions = Array.ConvertAll(enumNames, n =>
            {
                OrderAttribute orderAttr = (OrderAttribute)myEnumType.GetField(n)
                    .GetCustomAttributes(typeof(OrderAttribute), false)[0];
                return orderAttr.Order;
            });

            Array.Sort(enumPositions, enumValues);

            return enumValues;
        }

        public static T[] GetWithOrder<T>(this Type type)
        {
            Type myEnumType = typeof(T);
            var customInfos = myEnumType.GetMembers().Where(e => e.GetCustomAttributes(typeof(OrderAttribute), false).Count() > 0);

            var enumValues = Enum.GetValues(myEnumType).Cast<T>().ToArray();
            if (customInfos.Count() > 0)
            {
                var enumNames = Enum.GetNames(myEnumType);
                int[] enumPositions = Array.ConvertAll(enumNames, n =>
                {
                    OrderAttribute orderAttr = (OrderAttribute)myEnumType.GetField(n)
                        .GetCustomAttributes(typeof(OrderAttribute), false)[0];
                    return orderAttr.Order;
                });
                Array.Sort(enumPositions, enumValues);
            }

            return enumValues;

        }
    }
}