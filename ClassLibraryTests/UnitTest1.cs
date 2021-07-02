using System.Diagnostics;
using ClassLibrarys.Enums;
using ClassLibrarys.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassLibraryTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
           var myenum = EnumHelper.SortEnum<MyEnum>();
        }

        [TestMethod]
        public void TestMethod2()
        {
            var myenumorder = typeof(MyEnum).GetWithOrder<MyEnum>();
            foreach (var item in myenumorder)
            {
                Debug.WriteLine(item);
            }
            var myenum = typeof(TestEnum).GetWithOrder<TestEnum>();
            foreach (var item in myenum)
            {
                Debug.WriteLine(item);
            }
        }
    }
}
