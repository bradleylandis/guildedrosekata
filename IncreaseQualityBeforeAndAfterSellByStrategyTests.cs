using csharp.Strategies;
using NUnit.Framework;

namespace csharp
{
    [TestFixture]
    public class IncreaseQualityBeforeAndAfterSellByStrategyTests
    {
        [Test]
        public void DecreaseSellIn_DecreasesSellInByOne()
        {
            var item = new Item{SellIn = 1};
            var subject = new IncreaseQualityBeforeAndAfterSellByStrategy(item);
            subject.DecreaseSellIn();
            
            Assert.That(item.SellIn, Is.EqualTo(0));
        }
        
        [Test]
        public void PerformPostSellByUpdate_IncreasesQualityByOne()
        {
            var item = new Item{Quality = 1};
            var subject = new IncreaseQualityBeforeAndAfterSellByStrategy(item);
            subject.PerformPostSellByUpdate();
            
            Assert.That(item.Quality, Is.EqualTo(2));
        }
        
        [Test]
        public void PerformPreSellByUpdate_IncreasesQualityByOne()
        {
            var item = new Item{Quality = 1};
            var subject = new IncreaseQualityBeforeAndAfterSellByStrategy(item);
            subject.PerformPreSellByUpdate();
            
            Assert.That(item.Quality, Is.EqualTo(2));
        }
    }
}