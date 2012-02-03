using System;

namespace GildedRose.Console.AnotherSetOfItems
{
    public class ConditionallyUse : Default
    {
        Func<IContainAnItem, bool> _condition;
        IContainAnItem _ifTrue;
        IContainAnItem _ifFalse;

        public ConditionallyUse(Func<IContainAnItem, bool> condition, IContainAnItem ifTrue, IContainAnItem ifFalse)
            : base(ifTrue)
        {
            _condition = condition;
            _ifTrue = ifTrue;
            _ifFalse = ifFalse;
        }

        public override void UpdateQuality()
        {
            if(_condition(_ifTrue))
                _ifTrue.UpdateQuality();
            else
                _ifFalse.UpdateQuality();
        }

        public override void UpdateSellIn()
        {
            if (_condition(_ifTrue))
                _ifTrue.UpdateSellIn();
            else
                _ifFalse.UpdateSellIn();
        }
    }
}