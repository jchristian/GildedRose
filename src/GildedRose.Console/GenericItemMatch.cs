using System;
using GildedRose.Console;

public class GenericItemMatch : IMatchAnItem
{
    Func<Item, bool> _match;
    Func<Item, IUpdateAnItem> _factory;

    public GenericItemMatch(Func<Item, bool> match, Func<Item, IUpdateAnItem> factory)
    {
        _match = match;
        _factory = factory;
    }

    public bool CanCreateFrom(Item item)
    {
        return _match(item);
    }

    public IUpdateAnItem Factory(Item item)
    {
        return _factory(item);
    }
}