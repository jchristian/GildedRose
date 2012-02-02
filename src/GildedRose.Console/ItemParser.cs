namespace GildedRose.Console
{
    public class ItemParser : IParseItems
    {
        IFindItemFactories _itemFactoryRegistry;

        public ItemParser(IFindItemFactories itemFactoryRegistry)
        {
            _itemFactoryRegistry = itemFactoryRegistry;
        }

        public IUpdateMyself Parse(Item item)
        {
            return _itemFactoryRegistry.Find(item)(item);
        }
    }
}