using csharp.Strategies;

namespace csharp
{
    public class QualityUpdateStrategyFactory
    {
        public QualityUpdateStrategy Create(Item item)
        {
            switch (item.Name)
            {
                case "Aged Brie":
                    return new IncreaseQualityBeforeAndAfterSellByStrategy(item);
                case "Backstage passes to a TAFKAL80ETC concert":
                    return new BackstagePassStrategy(item);
                case "Sulfuras, Hand of Ragnaros":
                    return new NoQualityChangeStrategy(item);
                default:
                    return new DecreaseQualityTwiceAsFastAfterSellByStrategy(item);
            }
        }
    }
}