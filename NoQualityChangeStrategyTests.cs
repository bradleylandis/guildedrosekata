using NUnit.Framework;
using csharp.Strategies;

namespace csharp
{
    [TestFixture]
    public class NoQualityChangeStrategyTests
    {
        [Test]
        public void DecreaseSellIn_MakesNoChange()
        {
            var item = new Item{SellIn = 1};
            var subject = new NoQualityChangeStrategy(item);
            subject.DecreaseSellIn();
            
            Assert.That(item.SellIn, Is.EqualTo(1));
        }
        
        [Test]
        public void PerformPostSellByUpdate_MakesNoChange()
        {
            var item = new Item{Quality = 1};
            var subject = new NoQualityChangeStrategy(item);
            subject.PerformPostSellByUpdate();
            
            Assert.That(item.Quality, Is.EqualTo(1));
        }
        
        [Test]
        public void PerformPreSellByUpdate_MakesNoChange()
        {
            var item = new Item{Quality = 1};
            var subject = new NoQualityChangeStrategy(item);
            subject.PerformPreSellByUpdate();
            
            Assert.That(item.Quality, Is.EqualTo(1));
        }
    }
}
