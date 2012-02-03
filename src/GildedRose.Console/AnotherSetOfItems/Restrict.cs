using System;
using System.Linq.Expressions;

namespace GildedRose.Console.AnotherSetOfItems
{
    public class Restrict<RestrictionType> : IRestrictTheNextCommand<RestrictionType>
    {
        public IContainAnItem ItemWrapper { get; private set; }
        public Expression<Func<IContainAnItem, RestrictionType>> PropertySelector { get; private set; }

        public Restrict(IContainAnItem itemWrapper, Expression<Func<IContainAnItem, RestrictionType>> propertySelector)
        {
            ItemWrapper = itemWrapper;
            PropertySelector = propertySelector;
        }
    }
}