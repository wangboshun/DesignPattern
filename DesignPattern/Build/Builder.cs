using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace DesignPattern.Build
{
    /// <summary>
    /// 抽象建造者 --- 构建模式
    /// </summary>
    public abstract class BuilderFactory
    {
        public abstract void BuilderA();

        public abstract void BuilderB();

        public abstract Food GetFood();
    }

    /// <summary>
    ///  指挥创建过程类
    /// </summary>
    public class Director
    {
        public void Construct(BuilderFactory builder)
        {
            builder.BuilderA();
            builder.BuilderB();
        }
    }

    /// <summary>
    /// 资源类
    /// </summary>
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

    /// <summary>
    /// 具体创建者1
    /// </summary>
    public class Builder1 : BuilderFactory
    {
        Food food = new Food();

        public override void BuilderA()
        {
            food.Add("A1");
        }
        public override void BuilderB()
        {
            food.Add("B1");
        }
        public override Food GetFood()
        {
            return food;
        }
    }

    /// <summary>
    ///  具体创建者2
    /// </summary>
    public class Builder2 : BuilderFactory
    {
        Food food = new Food();

        public override void BuilderA()
        {
            food.Add("A2");
        }
        public override void BuilderB()
        {
            food.Add("B2");
        }
        public override Food GetFood()
        {
            return food;
        }
    }
       
    [TestClass]
    public class BuilderTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Director director = new Director();
            BuilderFactory builder1 = new Builder1();
            director.Construct(builder1);
            Food food1 = builder1.GetFood();
            food1.Show();
        }
    }
}
