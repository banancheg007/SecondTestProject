using FirstTestProject.main;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTests.tests
{
    [TestFixture]
    [AllureNUnit]
    [AllureDisplayIgnored]
    class BaseTest
    {
        [TearDown]
        public void AfterTest()
        {

            var status = TestContext.CurrentContext.Result.Outcome.Status;

            if (status == TestStatus.Failed)
            {
                Console.WriteLine("Тест свалился");
                Driver.MakeScreenShot();


            }
            Driver.Destroy();
        }
    }
}
