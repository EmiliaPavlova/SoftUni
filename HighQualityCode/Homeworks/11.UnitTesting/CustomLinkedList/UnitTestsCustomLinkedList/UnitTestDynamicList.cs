using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestsCustomLinkedList
{
    using CustomLinkedList;

    [TestClass]
    public class UnitTestDynamicList
    {
        private DynamicList<object> dynamicList;

        [TestInitialize]
        public void InitializeList()
        {
            this.dynamicList = new DynamicList<object>();
        }

        [TestMethod]
        public void Test_Count_On_New_List()
        {
            this.dynamicList.Add(2);
            int count = this.dynamicList.Count;
            Assert.AreEqual(1, count, "Dynamic list does not add elements correctly");
        }

        [TestMethod]
        public void Test_Correct_Adding_Element_In_List()
        {
            this.dynamicList.Add(1);
            this.dynamicList[0] = "ElementZero";
            var expectedElement = "ElementZero";
            Assert.AreEqual(expectedElement, this.dynamicList[0], "Index setter does not add values correct");
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        public void Index_Larger_Than_ElementsCount_Should_Throw_Exception()
        {
            int count = this.dynamicList.Count + 1;
            var element = this.dynamicList[count];
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Negative_Index_Should_Throw_Exception()
        {
            this.dynamicList[-1] = 2;
        }

        [TestMethod]
        public void TestAdd_EmptyList()
        {
            this.dynamicList.Add(22);

            var expectedElement = 22;

            Assert.AreEqual(expectedElement, this.dynamicList[this.dynamicList.Count - 1],
                "The add method doesn't add the right element in an empty list");
        }

        [TestMethod]
        public void Add_NonEmpty_List()
        {
            this.dynamicList.Add(2);
            this.dynamicList.Add(3);
            var expectedElement = 3;
            Assert.AreEqual(expectedElement, this.dynamicList[this.dynamicList.Count-1],
                "The add method doesn't add the right element in a non-empty list");
        }

        [TestMethod]
        public void Adding_New_Elements_Into_List()
        {
            this.dynamicList.Add(22);
            this.dynamicList.Add(32);
            int expectedCount = 2;
            Assert.AreEqual(expectedCount, this.dynamicList.Count,
                "The add method doesn't increment the elements count when adding new element");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RemoveAt_Negative_Index_Should_Throw_Exception()
        {
            this.dynamicList.RemoveAt(-5);
        }

        [TestMethod]
        public void Count_Decrementation_Remove()
        {
            this.dynamicList.Add(22);
            this.dynamicList.Add(33);
            this.dynamicList.Add(44);
            this.dynamicList.Remove(33);
            int expectedCount = 2;
            Assert.AreEqual(expectedCount, this.dynamicList.Count,
                "The remove method doesn't decrement the elements count when removing an element");
        }

        //No more time, sorry!
    }
}
