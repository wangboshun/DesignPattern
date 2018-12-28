using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DesignPattern.Factory1
{

    #region 工厂方法模式---基类

    /// <summary>
    /// 生产抽象基类
    /// </summary>
    public abstract class FoodFactory
    {
        public abstract FoodBase1 Create();
    }

    /// <summary>
    /// 食物抽象基类
    /// </summary>
    public abstract class FoodBase1
    {
        public abstract string Eat();
    } 

    #endregion

    #region 实例1 

    /// <summary>
    /// 食物1生产
    /// </summary>
    public class FoodFactory1 : FoodFactory
    {
        public override FoodBase1 Create()
        {
            return new Food1();
        }
    }

    /// <summary>
    /// 食物1
    /// </summary>
    public class Food1 : FoodBase1
    {
        public override string Eat()
        {
            return "Food1";
        }
    }

    #endregion

    #region 实例2 

    /// <summary>
    /// 食物1生产
    /// </summary>
    public class FoodFactory2 : FoodFactory
    {
        public override FoodBase1 Create()
        {
            return new Food1();
        }
    }

    /// <summary>
    /// 食物1
    /// </summary>
    public class Food2 : FoodBase1
    {
        public override string Eat()
        {
            return "Food2";
        }
    }

    #endregion

    [TestClass]
    public class Factory1Test1
    {
        [TestMethod]
        public void TestMethod1()
        {
            FoodFactory factory1 = new FoodFactory1();
            FoodBase1 food1 = factory1.Create();
            string result1 = food1.Eat();

            FoodFactory factory2 = new FoodFactory1();
            FoodBase1 food2 = factory2.Create();
            string result2 = food2.Eat();
        }
    }
}
