namespace csharp.Strategies
{
    public class BackstagePassStrategy : QualityUpdateStrategy
    {
        public BackstagePassStrategy(Item item) : base(item)
        {
        }

        public override void PerformPostSellByUpdate()
        {
            Item.Quality = 0;
        }

        public override void PerformPreSellByUpdate()
        {
            IncreaseQuality();

            if (Item.SellIn < 11)
                IncreaseQuality();

            if (Item.SellIn < 6)
                IncreaseQuality();
        }
    }
}