using GildedRose.Console;
using GildedRose.Console.Items;
using NUnit.Framework;

namespace GildedRose.Tests
{
    [TestFixture]
    public class ProgramTests
    {
        [Test]
        public void when_updating_a_normal_item_should_degrade_one_quality()
        {
            var item = new Item { Name = "Item", Quality = 10, SellIn = 5 };

            var program = CreateProgram(item);
            program.UpdateQuality();

            Assert.That(item.Quality, Is.EqualTo(9));
        }

        [Test]
        public void when_updating_a_normal_item_should_update_its_sellin()
        {
            var item = new Item { Name = "Item", Quality = 10, SellIn = 5 };

            var program = CreateProgram(item);
            program.UpdateQuality();

            Assert.That(item.SellIn, Is.EqualTo(4));
        }

        [Test]
        public void when_updating_a_normal_item_past_its_sellby_date_should_degrade_two_quality()
        {
            var item = new Item { Name = "Item", Quality = 10, SellIn = 0 };

            var program = CreateProgram(item);
            program.UpdateQuality();

            Assert.That(item.Quality, Is.EqualTo(8));
        }

        [Test]
        public void when_updating_a_normal_item_with_no_quality_should_stay_at_no_quality()
        {
            var item = new Item { Name = "Item", Quality = 0, SellIn = 5 };

            var program = CreateProgram(item);
            program.UpdateQuality();

            Assert.That(item.Quality, Is.EqualTo(0));
        }

        [Test]
        public void when_updating_a_normal_item_with_no_quality_and_past_its_sellby_date_should_stay_at_no_quality()
        {
            var item = new Item { Name = "Item", Quality = 0, SellIn = 0 };

            var program = CreateProgram(item);
            program.UpdateQuality();

            Assert.That(item.Quality, Is.EqualTo(0));
        }

        [Test]
        public void when_updating_aged_brie_should_appreciate_one_quality()
        {
            var item = new Item { Name = "Aged Brie", Quality = 10, SellIn = 10 };

            var program = CreateProgram(item);
            program.UpdateQuality();

            Assert.That(item.Quality, Is.EqualTo(11));
        }

        [Test]
        public void when_updating_aged_brie_past_its_sellby_date_should_appreciate_two_quality()
        {
            var item = new Item { Name = "Aged Brie", Quality = 10, SellIn = 0 };

            var program = CreateProgram(item);
            program.UpdateQuality();

            Assert.That(item.Quality, Is.EqualTo(12));
        }

        [Test]
        public void when_updating_aged_brie_with_50_quality_should_stay_at_50_quality()
        {
            var item = new Item { Name = "Aged Brie", Quality = 50, SellIn = 5 };

            var program = CreateProgram(item);
            program.UpdateQuality();

            Assert.That(item.Quality, Is.EqualTo(50));
        }

        [Test]
        public void when_updating_aged_brie_with_50_quality_and_past_its_sellby_date_should_stay_at_50_quality()
        {
            var item = new Item { Name = "Aged Brie", Quality = 50, SellIn = 0 };

            var program = CreateProgram(item);
            program.UpdateQuality();

            Assert.That(item.Quality, Is.EqualTo(50));
        }

        [Test]
        public void when_updating_concert_tickets_more_than_10_days_before_its_sellby_should_appreciate_one_quality()
        {
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 10, SellIn = 15 };

            var program = CreateProgram(item);
            program.UpdateQuality();

            Assert.That(item.Quality, Is.EqualTo(11));
        }

        [Test]
        public void when_updating_concert_tickets_between_5_and_10_days_before_its_sellby_should_appreciate_two_quality()
        {
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 10, SellIn = 7 };

            var program = CreateProgram(item);
            program.UpdateQuality();

            Assert.That(item.Quality, Is.EqualTo(12));
        }

        [Test]
        public void when_updating_concert_tickets_between_0_and_5_days_before_its_sellby_should_appreciate_three_quality()
        {
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 10, SellIn = 2 };

            var program = CreateProgram(item);
            program.UpdateQuality();

            Assert.That(item.Quality, Is.EqualTo(13));
        }

        [Test]
        public void when_updating_concert_tickets_after_its_sellby_should_have_a_quality_of_0()
        {
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 10, SellIn = 0 };

            var program = CreateProgram(item);
            program.UpdateQuality();

            Assert.That(item.Quality, Is.EqualTo(0));
        }

        [Test]
        public void when_updating_sulfuras_should_not_update_its_quality()
        {
            var item = new Item { Name = "Sulfuras, Hand of Ragnaros", Quality = 80, SellIn = 0 };

            var program = CreateProgram(item);
            program.UpdateQuality();

            Assert.That(item.Quality, Is.EqualTo(80));
        }

        [Test]
        public void when_updating_sulfuras_should_not_update_its_sellby_date()
        {
            var item = new Item { Name = "Sulfuras, Hand of Ragnaros", Quality = 80, SellIn = 0 };

            var program = CreateProgram(item);
            program.UpdateQuality();

            Assert.That(item.SellIn, Is.EqualTo(0));
        }

        [Test]
        public void when_updating_a_conjured_item_should_degrade_the_quality_twice_as_fast()
        {
            var item = new Item { Name = "Conjured Cloak", Quality = 30, SellIn = 5 };

            var program = CreateProgram(item);
            program.UpdateQuality();

            Assert.That(item.Quality, Is.EqualTo(28));
        }

        [Test]
        public void when_updating_a_conjured_item_and_its_sellby_date_is_past_should_degrade_the_quality_twice_as_fast()
        {
            var item = new Item { Name = "Conjured Cloak", Quality = 30, SellIn = 0 };

            var program = CreateProgram(item);
            program.UpdateQuality();

            Assert.That(item.Quality, Is.EqualTo(26));
        }

        [Test]
        public void when_updating_multiple_items_should_update_all_the_items()
        {
            var item1 = new Item { Name = "Item", Quality = 10, SellIn = 5 };
            var item2 = new Item { Name = "Item", Quality = 20, SellIn = 10 };

            var program = CreateProgram(item1, item2);
            program.UpdateQuality();

            Assert.That(item1.Quality, Is.EqualTo(9));
            Assert.That(item1.SellIn, Is.EqualTo(4));

            Assert.That(item2.Quality, Is.EqualTo(19));
            Assert.That(item2.SellIn, Is.EqualTo(9));
        }

        Program CreateProgram(params Item[] items)
        {
            return new Program(new ItemParser(new ItemFactoryRegistry(new ItemFactories())), items);
        }
    }
}