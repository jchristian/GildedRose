using System;
using GildedRose.Console;

namespace GildedRose.Tests
{
    public interface IFindItemFactories
    {
        Func<Item, Item> Find(Item item);
    }
}