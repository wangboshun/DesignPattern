using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace DesignPattern.Build
{
    /// <summary>
    /// 构建模式
    /// </summary>
    public class Builder1
    {
        private Food food = new Food();

        public void BuilderA()
        {
            food.Add("A");
        }

        public void BuilderB()
        {
            food.Add("B");
        }

        public Food GetFood()
        {
            return food;
        }

        public void Construct()
        {
            BuilderA();
            BuilderB();
        }
    }

    public class Food
    {
        private IList<string> list = new List<string>();

        public void Add(string str)
        {
            list.Add(str);
        }

        public string Show()
        {
            string str = "";
            foreach (var item in list)
            {
                str += $" 产品({item}) ";
            }
            return str;
        }
    }

    [TestClass]
    public class BuilderTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Builder1 builder = new Builder1();
            builder.Construct();
            Food food = builder.GetFood();
            string result = food.Show();
        }
    }
}
