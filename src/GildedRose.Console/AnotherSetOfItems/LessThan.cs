using System;

namespace GildedRose.Console.AnotherSetOfItems
{
    public class LessThan<RestrictionType> : GenericRestriction<RestrictionType> where RestrictionType : IComparable
    {
        RestrictionType _restrictedValue;

        public LessThan(IRestrictTheNextCommand<RestrictionType> itemWrapper, RestrictionType restrictedValue)
            : base(itemWrapper, restrictedValue)
        {
            _restrictedValue = restrictedValue;
        }

        public override bool ShouldRestrict()
        {
            return _itemWrapper.PropertySelector.Compile()(this).CompareTo(_restrictedValue) < 0;
        }
    }
}