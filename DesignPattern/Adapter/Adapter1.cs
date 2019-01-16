using Microsoft.VisualStudio.TestTools.UnitTesting;

/// <summary>
/// 类的适配器
/// 老的日志WriteLog方法   新的日志Write方法  为了兼容，切换日志利用适配器模式改动小
/// </summary>
namespace DesignPattern.Adapter1
{
    /// <summary>
    /// 抽象类
    /// </summary>
    public abstract class LogAdapter
    {
        public abstract string WriteLog();
    }

    /// <summary>
    /// 源角色
    /// </summary>
    public class DataLog : LogAdapter
    {
        public override string WriteLog()
        {
            return "DataLog";
        }
    }

    /// <summary>
    /// 源角色
    /// </summary>
    public class ConsoleLog : LogAdapter
    {
        public override string WriteLog()
        {
            return "ConsoleLog";
        }
    }

    /// <summary>
    /// 目标角色
    /// </summary>
    public interface ILogTraget
    {
        string Write();
    }

    /// <summary>
    /// 适配器类
    /// </summary>
    public class DataLogAdapter : DataLog, ILogTraget
    {
        public string Write()
        {
            return WriteLog();
        }
    }

    /// <summary>
    /// 适配器类
    /// </summary>
    public class ConsoleAdapter : ConsoleLog, ILogTraget
    {
        public string Write()
        {
            return WriteLog();
        }
    }

    [TestClass]
    public class Adapter1Test
    {
        [TestMethod]
        public void TestMethod1()
        {
            ILogTraget datalog = new DataLogAdapter();
            var result1 = datalog.Write();

            ILogTraget consolelog = new ConsoleAdapter();
            var result2 = consolelog.Write();
        }
    }
}
