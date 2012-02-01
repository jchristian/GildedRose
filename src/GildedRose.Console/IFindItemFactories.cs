using System;

namespace GildedRose.Console
{
    public interface IFindItemFactories
    {
        Func<Item, Item> Find(Item item);
    }
}