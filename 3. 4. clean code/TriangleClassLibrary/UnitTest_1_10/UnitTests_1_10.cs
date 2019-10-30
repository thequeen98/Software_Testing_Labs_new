using System;
using TriangleClassLibrary_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static TriangleClassLibrary_2.IsTriangle;

namespace UnitTest_1_10
{
    [TestClass]
    public class UnitTests_1_10
    {
        //TestMethod1
        [TestMethod]
        public void Correctly_side_c_()
        {
            Assert.AreEqual(it_is_good_triangle(5, 3, 7 ), false, "Side_a_plus_side_b_NOT_more_then_side_c");
        }

        //TestMethod2
        [TestMethod]
        public void Correctly_side_a()
        {
            Assert.AreEqual(it_is_good_triangle(5, 5, 9), true, "Side_b_plus_side_c_NOT_more_then_side_a");
        }

        //TestMethod3
        [TestMethod]
        public void Correctly_side_b()
        {
            Assert.AreEqual(it_is_good_triangle(8, 3, 8), true, "Side_a_plus_side_c_NOT_more_then_side_b");
        }

        //TestMethod4
        [TestMethod]
        public void All_sides_equally()
        {
            Assert.AreEqual(it_is_good_triangle(7, 7, 7), true, "Side_a_equally_side_b_equally_side_c_Not_return_true");
        }

        //TestMethod5
        [TestMethod]
        public void All_sides_equally_0()
        {
            Assert.AreEqual(it_is_good_triangle(0, 0, 0), false, "Sides_cannot_be_equally_0");
        }

        //TestMethod6
        [TestMethod]
        public void Two_sides_equally_0()
        {
            Assert.AreEqual(it_is_good_triangle(0, 10, 0), false, "Sides_cannot_be_equally_0");
        }

        //TestMethod7
        [TestMethod]
        public void One_sides_equally_0()
        {
            Assert.AreEqual(it_is_good_triangle(5, 0, 8), false, "Sides_cannot_be_equally_0");
        }

        //TestMethod8
        [TestMethod]
        public void All_sides_less_then_0()
        {
            Assert.AreEqual(it_is_good_triangle(-5, -12, -6), false, "Sides cannot be less than 0");
        }

        //TestMethod9
        [TestMethod]
        public void Two_sides_less_then_0()
        {
            Assert.AreEqual(it_is_good_triangle(5, -8, -6), false, "Sides cannot be less than 0");
        }

        //TestMethod10
        [TestMethod]
        public void One_sides_less_then_0()
        {
            Assert.AreEqual(it_is_good_triangle(15, 16, -6), false, "Sides cannot be less than 0");
        }
    }
}
