using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace WhoBrokeIt.App.Test
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Screeenshots
    {
        IApp app;
        Platform platform;

        public Screeenshots(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void AppLaunches()
        {
            app.Screenshot("First screen.");
            app.EnterText("InstanceEntry", "");
            app.EnterText("TokenEntry", "");
            app.Tap("ContinueButton");
        }
    }
}

