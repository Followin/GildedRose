namespace RoseKata
{
    public class AgedBrieWrapper : BaseItemWrapper
    {
        public AgedBrieWrapper(Item item) : base(item)
        {
        }

        public override void Update()
        {
            if (Item.SellIn <= 0)
            {
                Item.Quality += 2;
            }
            else
            {
                Item.Quality++;
            }

            Item.SellIn--;

            base.Update();
        }
    }
}