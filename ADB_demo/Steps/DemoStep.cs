using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADB_demo.DriverCode;
using TechTalk.SpecFlow;

namespace ADB_demo.Steps
{
    [Binding]
    class DemoStep
    {

        private AndroidDriver myDriver;

        [BeforeScenario]
        public void Setup()
        {
            myDriver = new AndroidDriver();
        }

        [AfterScenario]
        public void TearDown()
        {
            myDriver.Stop();
        }


        [Given(@"I install the app ""(.*)""")]
        public void GivenIInstallTheApp(string installFile)
        {
            myDriver.installApplication(installFile);
            myDriver.printHelloWorld();
        }

        [Given(@"I launch it")]
        public void GivenILaunchIt()
        {
            myDriver.printHelloWorld();
        }


        [Given(@"I load the ""(.*)"" level")]
        public void GivenILoadTheLevel(string p0)
        {
            myDriver.printHelloWorld();
        }

        [Then(@"I should have a ""(.*)""")]
        public void ThenIShouldHaveA(string p0)
        {
            myDriver.printHelloWorld();
        }

        
    }
}
