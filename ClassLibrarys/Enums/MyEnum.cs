using System;
using ClassLibrarys.Attributes;

namespace ClassLibrarys.Enums
{
    public enum MyEnum
    {
        [Order(1)]
        ElementA = 1,
        [Order(0)]
        ElementB = 2,
        [Order(2)]
        ElementC = 3
    }
}
