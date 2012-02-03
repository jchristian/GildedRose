using System;
using System.Linq;
using GildedRose.Console;
using NSubstitute;
using NUnit.Framework;

namespace GildedRose.Tests
{
    [TestFixture]
    public class ItemFactoryRegistryTests
    {
        [Test]
        public void when_the_item_has_a_match_in_the_registry_should_return_the_factory_from_the_match()
        {
            //Arrange
            var itemFactoryRegistry = Substitute.For<IContainTheItemFactories>();
            IFindItemFactories itemRegistryFactory = new ItemFactoryRegistry(itemFactoryRegistry);
            var testItem = new TestItem();

            var nonMatches = Enumerable.Range(1, 100).Select(x => Substitute.For<IMatchAnItem>()).ToList();
            var match = Substitute.For<IMatchAnItem>();
            match.CanCreateFrom(testItem).Returns(true);

            itemFactoryRegistry.GetEnumerator().Returns(nonMatches.Concat(new[] { match }).GetEnumerator());

            //Act
            var theReturnedFactory = itemRegistryFactory.Find(testItem);

            //Assert
            Assert.That(theReturnedFactory, Is.EqualTo((Func<Item, IUpdateAnItem>)match.Factory));
        }

        [Test]
        public void when_the_does_not_have_a_match_should_throw_an_item_not_found_in_registry_exception()
        {
            //Arrange
            var itemFactoryRegistry = Substitute.For<IContainTheItemFactories>();
            IFindItemFactories itemRegistryFactory = new ItemFactoryRegistry(itemFactoryRegistry);
            var testItem = new TestItem();

            var nonMatches = Enumerable.Range(1, 100).Select(x => Substitute.For<IMatchAnItem>()).ToList();

            itemFactoryRegistry.GetEnumerator().Returns(nonMatches.GetEnumerator());

            //Act
            ItemNotFoundInRegistryException expectedException = null;
            try
            {
                itemRegistryFactory.Find(testItem);
            }
            catch (ItemNotFoundInRegistryException e)
            {
                expectedException = e;
            }

            //Assert
            Assert.That(expectedException.ItemNotFound, Is.EqualTo(testItem));
        }

        class TestItem : Item { }
    }
}