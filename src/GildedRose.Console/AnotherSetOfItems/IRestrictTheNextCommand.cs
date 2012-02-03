using System;
using System.Linq.Expressions;

namespace GildedRose.Console.AnotherSetOfItems
{
    public interface IRestrictTheNextCommand<RestrictionType>
    {
        IContainAnItem ItemWrapper { get; }
        Expression<Func<IContainAnItem, RestrictionType>> PropertySelector { get; }
    }
}