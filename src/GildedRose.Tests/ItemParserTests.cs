using System;
using GildedRose.Console;
using NSubstitute;
using NUnit.Framework;

namespace GildedRose.Tests
{
    [TestFixture]
    public class ItemParserTests
    {
        [Test]
        public void when_the_item_is_in_the_registry_should_return_the_item_created_from_the_factory()
        {
            //Arrange
            var itemFactoryRegistry = Substitute.For<IFindItemFactories>();
            IParseItems itemParser = new ItemParser(itemFactoryRegistry);
            var item = new Item { Name = "Normal Item", Quality = 10, SellIn = 5 };

            var testItem = new TestItem();
            itemFactoryRegistry.Find(item).Returns((Func<Item, Item>)(i => testItem));

            //Act
            var parsedItem = itemParser.Parse(item);

            //Assert
            Assert.That(parsedItem, Is.EqualTo(testItem));
        }

        class TestItem : Item { }
    }
}