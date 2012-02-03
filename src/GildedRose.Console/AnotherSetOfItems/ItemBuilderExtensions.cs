using System;
using System.Linq.Expressions;

namespace GildedRose.Console.AnotherSetOfItems
{
    public static class ItemBuilderExtensions
    {
        public static IContainAnItem Default(this IContainAnItem item)
        {
            return new Default(item);
        }

        public static IContainAnItem Appreciate(this IContainAnItem item)
        {
            return new Appreciate(item);
        }

        public static IContainAnItem Depreciate(this IContainAnItem item)
        {
            return new Depreciate(item);
        }

        public static IContainAnItem DoubleQualityChangeWhenSellByDateIsPast(this IContainAnItem item)
        {
            return item.When(x => x.SellIn < 0).Use(x => x.DoubleTheQualityChange());
        }

        public static IContainAnItem DoubleTheQualityChange(this IContainAnItem item)
        {
            return new DoubleTheQualityChange(item);
        }

        public static IContainAnItem DecrementSellIn(this IContainAnItem item)
        {
            return new DecrementSellIn(item);
        }

        public static IConditionallyApply When(this IContainAnItem item, Func<IContainAnItem, bool> condition)
        {
            return new When(item, condition);
        }

        public static IConditionallyApply When(this IContainAnItem item, Func<bool> condition)
        {
            return new When(item, condition);
        }

        public static IContainAnItem Use<ReturnType>(this IConditionallyApply item, ReturnType use) where ReturnType : IContainAnItem
        {
            return new ConditionallyUse(item.Condition, use, item);
        }

        public static IContainAnItem Use<ReturnType>(this IConditionallyApply item, Func<IContainAnItem, ReturnType> @do) where ReturnType : IContainAnItem
        {
            return new ConditionallyUse(item.Condition, @do(item), item);
        }

        public static IRestrictTheNextCommand<RestrictionType> Restrict<RestrictionType>(this IContainAnItem item, Expression<Func<IContainAnItem, RestrictionType>> propertySelector)
        {
            return new Restrict<RestrictionType>(item, propertySelector);
        }

        public static IContainAnItem ToLessThanOrEqualTo<RestrictionType>(this IRestrictTheNextCommand<RestrictionType> item, RestrictionType restrictedValue) where RestrictionType : IComparable
        {
            var lessThan = new LessThan<RestrictionType>(item, restrictedValue);
            var equalTo = new EqualTo<RestrictionType>(item, restrictedValue);

            //ShouldRestrict() is asking if the item is *not* less than the boundary
            return item.ItemWrapper.When(() => !(lessThan.ShouldRestrict() || equalTo.ShouldRestrict())).Use(new Combine(lessThan, equalTo));
        }

        public static IContainAnItem ToGreaterThanOrEqualTo<RestrictionType>(this IRestrictTheNextCommand<RestrictionType> item, RestrictionType restrictedValue) where RestrictionType : IComparable
        {
            var greaterThan = new GreaterThan<RestrictionType>(item, restrictedValue);
            var equalTo = new EqualTo<RestrictionType>(item, restrictedValue);

            //Confusing logic
            return item.ItemWrapper.When(() => !(greaterThan.ShouldRestrict() || equalTo.ShouldRestrict())).Use(new Combine(greaterThan, equalTo));
        }

        public static IContainAnItem ToEqual<RestrictionType>(this IRestrictTheNextCommand<RestrictionType> item, RestrictionType restrictedValue) where RestrictionType : IComparable
        {
            return new EqualTo<RestrictionType>(item, restrictedValue);
        }
    }
}