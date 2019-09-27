namespace csharp.Strategies
{
    public class IncreaseQualityBeforeAndAfterSellByStrategy : QualityUpdateStrategy
    {
        public IncreaseQualityBeforeAndAfterSellByStrategy(Item item) : base(item)
        {
        }

        public override void PerformPostSellByUpdate()
        {
            IncreaseQuality();
        }

        public override void PerformPreSellByUpdate()
        {
            IncreaseQuality();
        }
    }
}