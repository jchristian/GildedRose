using GildedRose.Console;

namespace GildedRose.Tests
{
    public class ItemParser : IParseItems
    {
        IFindItemFactories _itemFactoryRegistry;

        public ItemParser(IFindItemFactories itemFactoryRegistry)
        {
            _itemFactoryRegistry = itemFactoryRegistry;
        }

        public Item Parse(Item item)
        {
            return _itemFactoryRegistry.Find(item)(item);
        }
    }
}