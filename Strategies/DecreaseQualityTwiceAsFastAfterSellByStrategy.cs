namespace csharp.Strategies
{
    public class DecreaseQualityTwiceAsFastAfterSellByStrategy : QualityUpdateStrategy
    {
        public DecreaseQualityTwiceAsFastAfterSellByStrategy(Item item) : base(item)
        {
        }

        public override void PerformPostSellByUpdate()
        {
            DecreaseQuality();
        }

        public override void PerformPreSellByUpdate()
        {
            DecreaseQuality();
        }
    }
}