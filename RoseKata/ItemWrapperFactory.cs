using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace RoseKata
{
    public class ItemWrapperFactory
    {
        public BaseItemWrapper GetWrapper(Item item)
        {
            switch (item.Name)
            {
                case "Aged Brie":
                    return new AgedBrieWrapper(item);
                case "Sulfuras, Hand of Ragnaros":
                    return new SulfurasItemWrapper(item);
                case "Backstage passes to a TAFKAL80ETC concert":
                    return new BackstagePasses(item);

                default:
                    return new NormalItemWrapper(item);
            }
        }
    }
}