using System;

namespace GildedRose.Console
{
    public interface IFindItemFactories
    {
        Func<Item, IUpdateAnItem> Find(Item item);
    }
}