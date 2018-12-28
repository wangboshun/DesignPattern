using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPattern.Factory2
{
    #region 工厂基类---抽象工厂模式   

    /// <summary>
    /// 生产抽象基类
    /// </summary>
    public abstract class FoodFactory
    {
        public abstract FoodBase1 CreateFood1();

        public abstract FoodBase2 CreateFood2();
    }

    /// <summary>
    /// 食物1基类
    /// </summary>
    public abstract class FoodBase1
    {
        public abstract string Eat();
    }

    /// <summary>
    /// 食物2基类
    /// </summary>
    public abstract class FoodBase2
    {
        public abstract string Eat();
    }

    #endregion

    #region 食物1生产线

    /// <summary>
    /// 食物1工厂
    /// </summary>
    public class CreateFood1Factory : FoodFactory
    {
        public override FoodBase1 CreateFood1()
        {
            return new Food1();
        }
        public override FoodBase2 CreateFood2()
        {
            return new Food2();
        }
    }

    /// <summary>
    /// 食物1生产
    /// </summary>
    public class Food1 : FoodBase1
    {
        public override string Eat()
        {
            return "Food1";
        }
    }
    #endregion

    #region 食物2生产线
    /// <summary>
    /// 食物2工厂
    /// </summary>
    public class CreateFood2Factory : FoodFactory
    {
        public override FoodBase1 CreateFood1()
        {
            return new Food1();
        }
        public override FoodBase2 CreateFood2()
        {
            return new Food2();
        }
    }

    /// <summary>
    /// 食物2生产
    /// </summary>
    public class Food2 : FoodBase2
    {
        public override string Eat()
        {
            return "Food2";
        }
    }

    #endregion

    [TestClass]
    public class Factory1Test2
    {
        [TestMethod]
        public void TestMethod1()
        {
            FoodFactory factory1 = new CreateFood1Factory();
            FoodBase1 food1 = factory1.CreateFood1();
            string result1= food1.Eat();

            FoodFactory factory2 = new CreateFood2Factory();
            FoodBase2 food2 = factory2.CreateFood2();
            string result2 = food2.Eat();
        }
    }
}
