using NUnit.Framework;
using System;
namespace DeliverooCronParser
{
    [TestFixture()]
    public class Test
    {
        [Test()]
        public void TestCaseRange()
        {
            string[] args = { "*/15", "5", "1-15", "1-2", "1-5", "/usr/bin/find" };
            bool success;

            Program p = new Program();
            if(p.PrintMins(args[0]) == true && p.PrintHour(args[1]) == true && p.PrintDOM(args[2]) == true && p.PrintWeek(args[3]) == true && p.PrintMonths(args[4]) == true)
            {
                success = true;
            } else { success = false; }

            Assert.IsTrue(success);
        }

        [Test()]
        public void TestCaseAll()
        {
            string[] args = { "*/15", "5", "*", "*", "*", "/usr/bin/find" };
            bool success;

            Program p = new Program();
            if (p.PrintMins(args[0]) == true && p.PrintHour(args[1]) == true && p.PrintDOM(args[2]) == true && p.PrintWeek(args[3]) == true && p.PrintMonths(args[4]) == true)
            {
                success = true;
            }
            else { success = false; }

            Assert.IsTrue(success);
        }

        [Test()]
        public void TestCaseFew()
        {
            string[] args = { "*/15", "5", "1,2", "1,2", "1,2", "/usr/bin/find" };
            bool success;

            Program p = new Program();
            if (p.PrintMins(args[0]) == true && p.PrintHour(args[1]) == true && p.PrintDOM(args[2]) == true && p.PrintWeek(args[3]) == true && p.PrintMonths(args[4]) == true)
            {
                success = true;
            }
            else { success = false; }

            Assert.IsTrue(success);
        }
    }
}
