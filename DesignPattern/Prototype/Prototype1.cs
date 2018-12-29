using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPattern.Prototype1
{
    /// <summary>
    /// 原型
    /// </summary>
    public abstract class Food
    {
        public string Name { set; get; }

        public int Price { set; get; }

        public Food(string name,int price)
        {
            Price = price;
            Name = name;
        }

        public abstract Food Clone();
    }

    /// <summary>
    /// 创建具体原型
    /// </summary>
    public class Food1 : Food
    {
        public Food1(string name,int price) : base(name, price)
        {

        }

        /// <summary>
        ///  浅拷贝
        /// </summary>
        /// <returns></returns>
        public override Food Clone() => (Food)MemberwiseClone();

        ///// <summary>
        ///// 深拷贝
        ///// </summary>
        ///// <returns></returns>
        //public override Food Clone()
        //{
        //    Food food = (Food)MemberwiseClone();
        //    food.Name = string.Copy(Name);
        //    return food;
        //}
    }

    [TestClass]
    public class PrototypeTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Food food1 = new Food1("Food1",1);

            //不改变内部值
            Food food2 = food1.Clone() as Food1;
            food2.Name = "food2";
            food2.Price =2;

            //已经改变内部值
            Food food4 = food1;
            food4.Name = "food4";
            food4.Price = 4;

            Food food3 = food1.Clone() as Food1;
        }
    }
}
