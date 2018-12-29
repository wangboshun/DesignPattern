using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

/// <summary>
/// 依赖倒置原则：原型管理器(FoodManager)仅仅依赖于抽象部分(Food)
/// 而具体实现细节(FoodPrototype)则依赖与抽象部分(Food)，所以Prototype很好的满足了依赖倒置原则。
/// </summary>
namespace DesignPattern.Prototype2
{
    /// <summary>
    /// 抽象部分
    /// </summary>
    [Serializable]
    public abstract class Food
    {
        public abstract Food Clone(bool deepcopy = false);
    }

    /// <summary>
    /// 具体实现
    /// </summary>
    [Serializable]
    public class FoodPrototype : Food
    {
        private string Milk, Ege;
        public FoodPrototype(string milk, string ege)
        {
            Milk = milk;
            Ege = ege;
        }

        public override Food Clone(bool deepcopy = false)
        {
            if (deepcopy)
                return DeepCopy();
            return (Food)MemberwiseClone();
        }

        /// <summary>
        /// 深拷贝
        /// </summary>
        /// <returns></returns>
        public Food DeepCopy()
        {
            Food food;
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, this);
            stream.Position = 0;
            food = (Food)formatter.Deserialize(stream);
            return food;
        }

        public string Show(string type)
        {
            return $"Type:{type}   Milk:{Milk}   Ege:{Ege}";
        }
    }

    /// <summary>
    /// 原型管理器
    /// </summary>
    public class FoodManager
    {
        public Hashtable foods = new Hashtable();
        public Food this[string type]
        {
            set => foods.Add(type, value);
            get => (Food)foods[type];
        }

        public int GetCount()
        {
            return foods.Count;
        }
    }

    [TestClass]
    public class PrototypeTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
            FoodManager foods = new FoodManager();
            foods["a"] = new FoodPrototype("1", "2");
            foods["b"] = new FoodPrototype("3", "4");
            foods["c"] = new FoodPrototype("5", "6");

            string type1 = "a";
            FoodPrototype food1 = (FoodPrototype)foods[type1].Clone();

            string type2 = "c";
            FoodPrototype food2 = (FoodPrototype)foods[type2].Clone(true);
        }
    }
}
