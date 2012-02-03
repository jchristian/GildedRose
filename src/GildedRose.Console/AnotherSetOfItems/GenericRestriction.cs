using System;

namespace GildedRose.Console.AnotherSetOfItems
{
    public abstract class GenericRestriction<RestrictionType> : Default, IRestrictAnItemProperty where RestrictionType : IComparable
    {
        protected IRestrictTheNextCommand<RestrictionType> _itemWrapper;
        RestrictionType _valueToReturnTo;

        public GenericRestriction(IRestrictTheNextCommand<RestrictionType> itemWrapper, RestrictionType valueToReturnTo)
            : base(itemWrapper.ItemWrapper)
        {
            _itemWrapper = itemWrapper;
            _valueToReturnTo = valueToReturnTo;
        }

        public override void UpdateQuality()
        {
            base.UpdateQuality();
            ApplyRestrict();
        }

        public override void UpdateSellIn()
        {
            base.UpdateQuality();
            ApplyRestrict();
        }

        public void ApplyRestrict()
        {
            if (ShouldRestrict())
                _itemWrapper.PropertySelector.SetPropertyValue(_itemWrapper.ItemWrapper, _valueToReturnTo);
        }

        public abstract bool ShouldRestrict();
    }
}