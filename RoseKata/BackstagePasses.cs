namespace RoseKata
{
    public class BackstagePasses : BaseItemWrapper
    {
        public BackstagePasses(Item item) : base(item)
        {
        }

        public override void Update()
        {
            if (Item.SellIn <= 0)
            {
                Item.Quality = 0;
            }
            else if (Item.SellIn <= 5)
            {
                Item.Quality += 3;
            }
            else if (Item.SellIn <= 10)
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