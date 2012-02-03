using System;

namespace GildedRose.Console.AnotherSetOfItems
{
    public class When : Default, IConditionallyApply
    {
        public Func<IContainAnItem, bool> Condition { get; private set; }

        public When(IContainAnItem itemWrapper, Func<bool> condition)
            : this(itemWrapper, x => condition())
        {}

        public When(IContainAnItem itemWrapper, Func<IContainAnItem, bool> condition)
            : base(itemWrapper)
        {
            Condition = condition;
        }
    }
}