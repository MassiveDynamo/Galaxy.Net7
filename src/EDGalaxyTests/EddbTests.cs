using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EDGalaxy.Tests
{
    [TestClass()]
    public class EddbTests
    {
        [TestMethod()]
        public void GetSystem()
        {
            Assert.IsNotNull(Eddb.GetSystem("Sol"));
            Assert.IsNull(Eddb.GetSystem("SolNotFound"));
        }

        [TestMethod()]
        public void GetCubeSystemsTest()
        {
            // Invoke-RestMethod -Uri "https://www.edsm.net/api-v1/cube-systems?systemName=Sol&size=10"
            /* -------- --------- ----
                5,95     16 Barnard's Star
                0        40 Sol 
                4,38      9  Alpha Centauri
            */

            var systems = Eddb.GetCubeSystems("Sol", 10);
            Assert.IsNotNull(systems);
            Assert.AreEqual<int>(3, systems.Count());
            Assert.IsTrue(systems.Max(item => item.Distance <= 10));
        }

        [TestMethod()]
        public void GetSphereSystemsTest()
        {
            // Invoke-RestMethod -Uri "https://www.edsm.net/api-v1/sphere-systems?systemName=Bob&radius=20"
            var systems = Eddb.GetSphereSystems("Bob", 20);
            Assert.IsNotNull(systems);
            Assert.AreEqual<int>(50, systems.Count());
            Assert.IsTrue(systems.Max(item => item.Distance <= 20));
        }
    }
}