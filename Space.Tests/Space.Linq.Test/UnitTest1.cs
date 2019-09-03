using NUnit.Framework;
using System.Collections.Generic;
using Space.Linq;
using System;

namespace Tests
{
    class TestPlayer
    {
        public string Name{ get; set;}
        public Int32 Age {get; set;}
    }
    
    public class Tests
    {
        [Test]
        public void TestLoliWantToSelect()
        {
            TestPlayer[] items = { new TestPlayer { Name="Test-chan", Age = 1 }, new TestPlayer { Name = "NotTest-chan", Age = 2 }};
            var yay = items.LoliNeedWhere<TestPlayer>(i => i.Age % 2 == 0);
            var pl = yay.LoliNeedsInYou(0);
            Assert.AreEqual(2, pl.Age);
        }
    }
}
