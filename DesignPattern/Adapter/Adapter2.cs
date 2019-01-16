using Microsoft.VisualStudio.TestTools.UnitTesting;

/// <summary>
/// 对象适配器
/// 老的日志WriteLog方法   新的日志Write方法  为了兼容，切换日志利用适配器模式改动小
/// </summary>
namespace DesignPattern.Adapter2
{
    public class FirstLog
    {
        public virtual string WriteLog()
        {
            return "FirstLog";
        }
    }

    public class LastLog
    {
        public string Write()
        {
            return "LastLog";
        }
    }

    public class LogAdapter : FirstLog
    {
        public LastLog log = new LastLog();

        public override string WriteLog()
        {
            return log.Write();
        }
    }

    [TestClass]
    public class Adapter2Test
    {
        [TestMethod]
        public void TestMethod1()
        {
            FirstLog log = new LogAdapter();
            string result = log.WriteLog();
        }
    }
}
