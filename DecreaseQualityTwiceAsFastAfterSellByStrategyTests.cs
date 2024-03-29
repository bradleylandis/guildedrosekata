using csharp.Strategies;
using NUnit.Framework;

namespace csharp
{
    [TestFixture]
    public class DecreaseQualityTwiceAsFastAfterSellByStrategyTests
    {
        [Test]
        public void DecreaseSellIn_DecreasesSellInByOne()
        {
            var item = new Item{SellIn = 1};
            var subject = new DecreaseQualityTwiceAsFastAfterSellByStrategy(item);
            subject.DecreaseSellIn();
            
            Assert.That(item.SellIn, Is.EqualTo(0));
        }
        
        [Test]
        public void PerformPostSellByUpdate_DecreasesQualityByOne()
        {
            var item = new Item{Quality = 1};
            var subject = new DecreaseQualityTwiceAsFastAfterSellByStrategy(item);
            subject.PerformPostSellByUpdate();
            
            Assert.That(item.Quality, Is.EqualTo(0));
        }
        
        [Test]
        public void PerformPreSellByUpdate_DecreasesQualityByOne()
        {
            var item = new Item{Quality = 1};
            var subject = new DecreaseQualityTwiceAsFastAfterSellByStrategy(item);
            subject.PerformPreSellByUpdate();
            
            Assert.That(item.Quality, Is.EqualTo(0));
        }
    }
}