using System;
using AstroAnts.Services;
using NUnit.Framework;

namespace Tests.Services
{
    [TestFixture]
    public class ArrayServicesTests
    {
        [Test]
        public void TestInitializationArrayValue()
        {
            int[] values = new int[4];
            ArrayServices.InitializeArrayValue<int>(values, 0);
            Assert.AreEqual(values, new int[] { 0, 0, 0, 0 });
        }

        [Test]
        public void TestInitializationArrayNull()
        {
            Assert.Throws<NullReferenceException>(delegate
            {
                ArrayServices.InitializeArrayValue<int>(null, 0);
            });
        }
    }
}
