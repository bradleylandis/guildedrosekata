namespace csharp.Strategies
{
    public class NoQualityChangeStrategy : QualityUpdateStrategy
    {
        public NoQualityChangeStrategy(Item item) : base(item)
        {
        }

        public override void DecreaseSellIn()
        {
        }

        public override void PerformPostSellByUpdate()
        {
        }

        public override void PerformPreSellByUpdate()
        {
        }
    }
}