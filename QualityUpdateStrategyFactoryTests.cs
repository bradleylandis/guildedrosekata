using System;
using csharp.Strategies;
using NUnit.Framework;

namespace csharp
{
    [TestFixture]
    public class QualityUpdateStrategyFactoryTests
    {
        [TestCase("Sulfuras, Hand of Ragnaros", typeof(NoQualityChangeStrategy))]
        [TestCase("Aged Brie", typeof(IncreaseQualityBeforeAndAfterSellByStrategy))]
        [TestCase("Backstage passes to a TAFKAL80ETC concert", typeof(BackstagePassStrategy))]
        [TestCase("Other", typeof(DecreaseQualityTwiceAsFastAfterSellByStrategy))]
        public void Create_ReturnsNoQualityUpdate_WhenItemNameIsSulfuras(string itemName, Type expectedType)
        {
            var item = new Item {Name = itemName};
            var subject = new QualityUpdateStrategyFactory();
            
            var result = subject.Create(item);
            
            Assert.That(result, Is.TypeOf(expectedType));
        }
    }
}