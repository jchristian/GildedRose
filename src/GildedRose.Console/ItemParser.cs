namespace GildedRose.Console
{
    public class ItemParser : IParseItems
    {
        IFindItemFactories _itemFactoryRegistry;

        public ItemParser(IFindItemFactories itemFactoryRegistry)
        {
            _itemFactoryRegistry = itemFactoryRegistry;
        }

        public IUpdateAnItem Parse(Item item)
        {
            return _itemFactoryRegistry.Find(item)(item);
        }
    }
}