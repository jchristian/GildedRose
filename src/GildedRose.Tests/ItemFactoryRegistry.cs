using System;
using System.Linq;
using GildedRose.Console;

namespace GildedRose.Tests
{
    public class ItemFactoryRegistry : IFindItemFactories
    {
        IContainTheItemFactories _itemFactoryMatches;

        public ItemFactoryRegistry(IContainTheItemFactories itemFactoryMatches)
        {
            _itemFactoryMatches = itemFactoryMatches;
        }

        public Func<Item, Item> Find(Item item)
        {
            var matchedFactory = _itemFactoryMatches.FirstOrDefault(x => x.CanCreateFrom(item));

            if(matchedFactory == null)
                throw new ItemNotFoundInRegistryException(item);

            return matchedFactory.Factory;
        }
    }
}