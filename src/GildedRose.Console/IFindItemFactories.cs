using System;

namespace GildedRose.Console
{
    public interface IFindItemFactories
    {
        Func<Item, IUpdateMyself> Find(Item item);
    }
}