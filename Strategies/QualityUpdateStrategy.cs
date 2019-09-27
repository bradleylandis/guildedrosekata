namespace csharp.Strategies
{
    public abstract class QualityUpdateStrategy
    {
        protected readonly Item Item;
        protected virtual int MinimumQuality => 0;
        protected virtual int MaximumQuality => 50;

        protected QualityUpdateStrategy(Item item)
        {
            Item = item;
        }

        public void IncreaseQuality()
        {
            if (Item.Quality < MaximumQuality)
            {
                Item.Quality += 1;
            }
        }

        public void DecreaseQuality()
        {
            if (Item.Quality > MinimumQuality)
            {
                Item.Quality -= 1;
            }
        }

        public virtual void DecreaseSellIn()
        {
            Item.SellIn -= 1;
        }

        public bool IsPassedSellBy()
        {
            return Item.SellIn < 0;
        }

        public void UpdateQuality()
        {
            PerformPreSellByUpdate();
            DecreaseSellIn();
            if(IsPassedSellBy())
                PerformPostSellByUpdate();
        }

        public abstract void PerformPostSellByUpdate();
        public abstract void PerformPreSellByUpdate();
    }
}