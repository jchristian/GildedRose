using System;

namespace GildedRose.Console.AnotherSetOfItems
{
    public class GreaterThan<RestrictionType> : GenericRestriction<RestrictionType> where RestrictionType : IComparable
    {
        RestrictionType _restrictedValue;

        public GreaterThan(IRestrictTheNextCommand<RestrictionType> itemWrapper, RestrictionType restrictedValue)
            : base(itemWrapper, restrictedValue)
        {
            _restrictedValue = restrictedValue;
        }

        public override bool ShouldRestrict()
        {
            return _itemWrapper.PropertySelector.Compile()(this).CompareTo(_restrictedValue) > 0;
        }
    }
}