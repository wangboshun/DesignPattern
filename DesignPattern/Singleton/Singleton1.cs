using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DesignPattern.Singleton
{
    public class Singleton1
    {
        static readonly Singleton1 instance = new Singleton1();
        static Singleton1() => Console.WriteLine("静态构造函数");
        Singleton1() { }
        public static Singleton1 Instance { get => instance; }

        public string Test() => "Test";
    }

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Singleton1 singleton = Singleton1.Instance;
            string result = singleton.Test();
        }
    }
}
