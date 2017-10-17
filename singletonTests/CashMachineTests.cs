using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using singleton;

namespace singletonTests
{
    [TestClass]
    public class CashMachineTests
    {
        [TestMethod]
        public void CheckCashMachineInstancesTests()
        {
            var cashMachineInstance1 = CashMachine.Instance;
            var cashMachineInstance2 = CashMachine.Instance;

            Assert.AreEqual(cashMachineInstance1, cashMachineInstance2);
        }

        [TestMethod]
        public void OperationsTests()
        {
            var cashMachineInstance1 = CashMachine.Instance;
            var cashMachineInstance2 = CashMachine.Instance;

            cashMachineInstance1.SetMoney(100);
            cashMachineInstance2.GetMoney(50);

            Assert.AreEqual(cashMachineInstance1.GetAccount(), 50);
            Assert.AreEqual(cashMachineInstance2.GetAccount(), 50);
        }

        [TestMethod]
        public void ThreadSafetyTests()
        {
            var cashMachineInstance1 = CashMachine.Instance;
            var thread1 = new Thread(obj => {cashMachineInstance1.SetMoney(100);});
            thread1.Start();

            var cashMachineInstance2 = CashMachine.Instance;
            var thread2 = new Thread(obj => { cashMachineInstance2.GetMoney(50); });
            thread2.Start();

            Assert.AreEqual(cashMachineInstance1.GetAccount(), 50);
            Assert.AreEqual(cashMachineInstance2.GetAccount(), 50);
        }
    }
}
