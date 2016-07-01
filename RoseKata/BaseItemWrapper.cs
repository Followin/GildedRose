namespace RoseKata
{
    public abstract class BaseItemWrapper
    {
        protected Item Item { get; }

        protected BaseItemWrapper(Item item)
        {
            Item = item;
        }

        public virtual void Update()
        {
            if (Item.Quality > 50)
            {
                Item.Quality = 50;
            }

            if (Item.Quality < 0)
            {
                Item.Quality = 0;
            }
        }
    }
}