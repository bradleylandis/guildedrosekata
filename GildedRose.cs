using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        private readonly IList<Item> items;

        public GildedRose(IList<Item> items)
        {
            this.items = items;
        }

        public void UpdateQuality()
        {
            var qualityUpdateStrategyFactory = new QualityUpdateStrategyFactory();
            foreach (var item in items)
                qualityUpdateStrategyFactory.Create(item).UpdateQuality();
        }
    }
}