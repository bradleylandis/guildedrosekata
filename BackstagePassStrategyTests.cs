using csharp.Strategies;
using NUnit.Framework;

namespace csharp
{
    [TestFixture]
    public class BackstagePassStrategyTests
    {
        [Test]
        public void DecreaseSellIn_DecreasesSellInByOne()
        {
            var item = new Item{SellIn = 1};
            var subject = new BackstagePassStrategy(item);
            subject.DecreaseSellIn();
            
            Assert.That(item.SellIn, Is.EqualTo(0));
        }
        
        [Test]
        public void PerformPostSellByUpdate_SetsQualityToZero()
        {
            var item = new Item{Quality = 10};
            var subject = new BackstagePassStrategy(item);
            subject.PerformPostSellByUpdate();
            
            Assert.That(item.Quality, Is.EqualTo(0));
        }
        
        [TestCase(11)]
        [TestCase(100)]
        public void PerformPreSellByUpdate_IncreasesQualityByOne_WhenSellInIsGreaterThanTen(int sellIn)
        {
            var item = new Item{Quality = 1, SellIn = sellIn};
            var subject = new BackstagePassStrategy(item);
            subject.PerformPreSellByUpdate();
            
            Assert.That(item.Quality, Is.EqualTo(2));
        }
        
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        [TestCase(9)]
        [TestCase(10)]
        public void PerformPreSellByUpdate_IncreasesQualityByTwo_WhenSellInIsBetweenSixAndTen(int sellIn)
        {
            var item = new Item{Quality = 1, SellIn = sellIn};
            var subject = new BackstagePassStrategy(item);
            subject.PerformPreSellByUpdate();
            
            Assert.That(item.Quality, Is.EqualTo(3));
        }
         
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void PerformPreSellByUpdate_IncreasesQualityByThree_WhenSellInIsBetweenFiveAndOne(int sellIn)
        {
            var item = new Item{Quality = 1, SellIn = sellIn};
            var subject = new BackstagePassStrategy(item);
            subject.PerformPreSellByUpdate();
            
            Assert.That(item.Quality, Is.EqualTo(4));
        }
    }
}