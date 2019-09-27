using csharp.Strategies;
using NUnit.Framework;

namespace csharp
{
    [TestFixture]
    public class QualityUpdateStrategyTests
    {
        [TestCase(1)]
        [TestCase(0)]
        [TestCase(-1)]
        public void UpdateQuality_AlwaysCallsPerformPreSellByUpdate(int sellIn)
        {
            var item = new Item {SellIn = sellIn};
            var subject = new FakeQualityUpdateStrategy(item);
            subject.UpdateQuality();
            
            Assert.That(subject.PerformedPreSellByUpdate, Is.True);
        }
        
        [Test]
        public void UpdateQuality_CallsPerformPostSellByUpdate_WhenSellByIsPast()
        {
            var item = new Item {SellIn = 0};
            var subject = new FakeQualityUpdateStrategy(item);
            subject.UpdateQuality();
            
            Assert.That(subject.PerformedPostSellByUpdate, Is.True);
        }
        
        [Test]
        public void UpdateQuality_DoesNotCallPerformPostSellByUpdate_WhenSellByIsFuture()
        {
            var item = new Item {SellIn = 1};
            var subject = new FakeQualityUpdateStrategy(item);
            subject.UpdateQuality();
            
            Assert.That(subject.PerformedPostSellByUpdate, Is.False);
        }

        [Test]
        public void IncreaseQuality_WhenQualityBelowMaximum()
        {
            var item = new Item {Quality = 1};
            var subject = new FakeQualityUpdateStrategy(item);
            subject.IncreaseQuality();
            
            Assert.That(item.Quality, Is.EqualTo(2));
        }
        
        [Test]
        public void IncreaseQuality_WhenQualityAtMaximum()
        {
            var item = new Item {Quality = 50};
            var subject = new FakeQualityUpdateStrategy(item);
            subject.IncreaseQuality();
            
            Assert.That(item.Quality, Is.EqualTo(50));
        }
        
        [Test]
        public void DecreaseQuality_WhenQualityAboveMinimum()
        {
            var item = new Item {Quality = 1};
            var subject = new FakeQualityUpdateStrategy(item);
            subject.DecreaseQuality();
            
            Assert.That(item.Quality, Is.EqualTo(0));
        }  
        
        [Test]
        public void DecreaseQuality_WhenQualityAtMinimum()
        {
            var item = new Item {Quality = 0};
            var subject = new FakeQualityUpdateStrategy(item);
            subject.DecreaseQuality();
            
            Assert.That(item.Quality, Is.EqualTo(0));
        }
        
        [Test]
        public void DecreaseSellIn()
        {
            var item = new Item {SellIn = 1};
            var subject = new FakeQualityUpdateStrategy(item);
            subject.DecreaseSellIn();
            
            Assert.That(item.SellIn, Is.EqualTo(0));
        }
        
        [TestCase(0)]
        [TestCase(1)]
        public void IsPassedSellBy_WhenSellInZeroOrMore(int sellIn)
        {
            var item = new Item {SellIn = sellIn};
            var subject = new FakeQualityUpdateStrategy(item);
            var result = subject.IsPassedSellBy();
            
            Assert.That(result, Is.False);
        }
        
        [Test]
        public void IsPassedSellBy_WhenSellInLessThanZero()
        {
            var item = new Item {SellIn = -1};
            var subject = new FakeQualityUpdateStrategy(item);
            var result = subject.IsPassedSellBy();
            
            Assert.That(result, Is.True);
        }

        private class FakeQualityUpdateStrategy : QualityUpdateStrategy
        {
            public bool PerformedPostSellByUpdate { get; set; }
            public bool PerformedPreSellByUpdate { get; set; }

            public FakeQualityUpdateStrategy(Item item) : base(item)
            {
            }

            public override void PerformPostSellByUpdate()
            {
                PerformedPostSellByUpdate = true;
            }

            public override void PerformPreSellByUpdate()
            {
                PerformedPreSellByUpdate = true;
            }
        }
    }
}