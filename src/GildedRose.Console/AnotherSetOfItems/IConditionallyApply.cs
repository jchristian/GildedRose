using System;

namespace GildedRose.Console.AnotherSetOfItems
{
    public interface IConditionallyApply : IContainAnItem
    {
        Func<IContainAnItem, bool> Condition { get; }
    }
}