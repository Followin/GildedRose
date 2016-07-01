using System.Collections.Generic;
using System.Linq;

namespace RoseKata
{
    class GildedRose
    {
        readonly IList<Item> Items;

        public GildedRose(IList<Item> items)
        {
            this.Items = items;
        }

        public void UpdateQuality()
        {
            var itemWrappers = Items.Select(x => new ItemWrapperFactory().GetWrapper(x));

            foreach (var baseItemWrapper in itemWrappers)
            {
                baseItemWrapper.Update();
            }
        }
    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }
}