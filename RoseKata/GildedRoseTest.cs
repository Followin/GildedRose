using System.Collections.Generic;
using NUnit.Framework;

namespace RoseKata
{
    [TestFixture()]
    public class GildedRoseTest
    {
        [Test()]
        public void Foo()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            RoseKata.GildedRose app = new RoseKata.GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("foo", Items[0].Name);
        }

        [Test]
        public void ShouldLowerQualityValue()
        {
            var firstItem = new Item {Name = "Test", Quality = 5, SellIn = 3};
            var secondItem = new Item {Name = "Test2", Quality = 10, SellIn = 2};
            var items = new[] {firstItem, secondItem};
            var target = new GildedRose(items);

            target.UpdateQuality();

            Assert.AreEqual(4, firstItem.Quality);
            Assert.AreEqual(9, secondItem.Quality);
        }

        [Test]
        public void ShouldLowerSellInValue()
        {
            var firstItem = new Item {Name = "Test", Quality = 5, SellIn = 3};
            var secondItem = new Item {Name = "Test2", Quality = 10, SellIn = 0};
            var items = new[] {firstItem, secondItem};
            var target = new GildedRose(items);

            target.UpdateQuality();

            Assert.AreEqual(2, firstItem.SellIn);
            Assert.AreEqual(-1, secondItem.SellIn);
        }

        [Test]
        public void ShouldLowerQualityTwiceWhenSellInValueIsLowerThanZero()
        {
            var firstItem = new Item { Name = "Test", Quality = 5, SellIn = -1 };
            var secondItem = new Item { Name = "Test2", Quality = 10, SellIn = 0 };
            var items = new[] { firstItem, secondItem };
            var target = new GildedRose(items);

            target.UpdateQuality();

            Assert.AreEqual(3, firstItem.Quality);
            Assert.AreEqual(8, secondItem.Quality);
        }

        [Test]
        public void ShouldNeverDropQualityLessThanZero()
        {
            var firstItem = new Item { Name = "Test", Quality = 0, SellIn = 0 };
            var secondItem = new Item { Name = "Test2", Quality = 1, SellIn = 0 };
            var items = new[] { firstItem, secondItem };
            var target = new GildedRose(items);

            target.UpdateQuality();

            Assert.AreEqual(0, firstItem.Quality);
            Assert.AreEqual(0, secondItem.Quality);
        }

        [Test]
        public void ShouldIncreaseQualityOnSellInDecreaseWhenItemNameEqualsToAgedBrie()
        {
            var firstItem = new Item { Name = "Aged Brie", Quality = 12, SellIn = 3 };
            var secondItem = new Item { Name = "Aged Brie", Quality = 10, SellIn = 0 };
            var items = new[] { firstItem, secondItem };
            var target = new GildedRose(items);

            target.UpdateQuality();

            Assert.AreEqual(13, firstItem.Quality);
            Assert.AreEqual(12, secondItem.Quality);
        }

        [Test]
        public void ShouldNeverIncreaseQualityToMoreThan50()
        {
            var firstItem = new Item { Name = "Aged Brie", Quality = 50, SellIn = 3 };
            var items = new[] { firstItem };
            var target = new GildedRose(items);

            target.UpdateQuality();

            Assert.AreEqual(50, firstItem.Quality);
        }

        [Test]
        public void ShouldNeverChangeQualityOfItemWithNameSulfurus()
        {
            var firstItem = new Item { Name = "Sulfuras, Hand of Ragnaros", Quality = 80, SellIn = 3 };
            var items = new[] { firstItem };
            var target = new GildedRose(items);

            target.UpdateQuality();

            Assert.AreEqual(80, firstItem.Quality);
        }

        [Test]
        public void ShouldNeverChangeSellInOfItemWithNameSulfurus()
        {
            var firstItem = new Item { Name = "Sulfuras, Hand of Ragnaros", Quality = 80, SellIn = 3 };
            var items = new[] { firstItem };
            var target = new GildedRose(items);

            target.UpdateQuality();

            Assert.AreEqual(3, firstItem.SellIn);
        }

        [Test]
        public void ShouldIncreaseQualityBy3WhenItemNameIsBackstagePassesAndSellInLessThen6()
        {
            var firstItem = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 40, SellIn = 5 };
            var items = new[] { firstItem };
            var target = new GildedRose(items);

            target.UpdateQuality();

            Assert.AreEqual(43, firstItem.Quality);
        }

        [Test]
        public void ShouldIncreaseQualityBy2WhenItemNameIsBackstagePassesAndSellInLessThen11()
        {
            var firstItem = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 40, SellIn = 10 };
            var items = new[] { firstItem };
            var target = new GildedRose(items);

            target.UpdateQuality();

            Assert.AreEqual(42, firstItem.Quality);
        }

        [Test]
        public void ShouldIncreaseQualityBy1WhenItemNameIsBackstagePassesAndSellInGreaterThan10()
        {
            var firstItem = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 40, SellIn = 11 };
            var items = new[] { firstItem };
            var target = new GildedRose(items);

            target.UpdateQuality();

            Assert.AreEqual(41, firstItem.Quality);
        }

        [Test]
        public void ShouldSetQualityToZeroWhenItemNameIsBackstagePassesAndSellInValueWentLessThan1()
        {
            var firstItem = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 40, SellIn = 0 };
            var items = new[] { firstItem };
            var target = new GildedRose(items);

            target.UpdateQuality();

            Assert.AreEqual(0, firstItem.Quality);
        }

    }
}

