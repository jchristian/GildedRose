using System;

namespace GildedRose.Console.AnotherSetOfItems
{
    public class EqualTo<RestrictionType> : GenericRestriction<RestrictionType> where RestrictionType : IComparable
    {
        RestrictionType _restrictedValue;

        public EqualTo(IRestrictTheNextCommand<RestrictionType> itemWrapper, RestrictionType restrictedValue)
            : base(itemWrapper, restrictedValue)
        {
            _restrictedValue = restrictedValue;
        }

        public override bool ShouldRestrict()
        {
            return _itemWrapper.PropertySelector.Compile()(this).CompareTo(_restrictedValue) != 0;
        }
    }
}