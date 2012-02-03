using System.Collections;
using System.Collections.Generic;
using GildedRose.Console.AnotherSetOfItems;

namespace GildedRose.Console.Items
{
    public class ItemFactories : IContainTheItemFactories
    {
        public IEnumerator<IMatchAnItem> GetEnumerator()
        {
            yield return new GenericItemMatch(item => item.Name.StartsWith("Conjured"), item => AnotherSetOfItems.Items.Wrap(item)
                                                                                                                       .DecrementSellIn()
                                                                                                                       .Depreciate()
                                                                                                                       .DoubleQualityChangeWhenSellByDateIsPast()
                                                                                                                       .DoubleTheQualityChange()
                                                                                                                       .Restrict(x => x.Quality).ToLessThanOrEqualTo(50)
                                                                                                                       .Restrict(x => x.Quality).ToGreaterThanOrEqualTo(0));
            yield return new GenericItemMatch(item => item.Name == "Aged Brie", item => AnotherSetOfItems.Items.Wrap(item)
                                                                                                               .DecrementSellIn()
                                                                                                               .Appreciate()
                                                                                                               .DoubleQualityChangeWhenSellByDateIsPast()
                                                                                                               .Restrict(x => x.Quality).ToLessThanOrEqualTo(50)
                                                                                                               .Restrict(x => x.Quality).ToGreaterThanOrEqualTo(0));
            yield return new GenericItemMatch(item => item.Name == "Backstage passes to a TAFKAL80ETC concert", item => AnotherSetOfItems.Items.Wrap(item)
                                                                                                               .DecrementSellIn()
                                                                                                               .Appreciate()
                                                                                                               .When(x => x.SellIn < 10).Use(x => x.Appreciate())
                                                                                                               .When(x => x.SellIn < 5).Use(x => x.Appreciate())
                                                                                                               .Restrict(x => x.Quality).ToLessThanOrEqualTo(50)
                                                                                                               .Restrict(x => x.Quality).ToGreaterThanOrEqualTo(0)
                                                                                                               .When(x => x.SellIn < 0).Use(x => x.Restrict(y => y.Quality).ToEqual(0)));
            yield return new GenericItemMatch(item => item.Name == "Sulfuras, Hand of Ragnaros", item => AnotherSetOfItems.Items.Wrap(item).Default());
            yield return new GenericItemMatch(item => true, item => AnotherSetOfItems.Items.Wrap(item)
                                                                                           .DecrementSellIn()
                                                                                           .Depreciate()
                                                                                           .DoubleQualityChangeWhenSellByDateIsPast()
                                                                                           .Restrict(x => x.Quality).ToLessThanOrEqualTo(50)
                                                                                           .Restrict(x => x.Quality).ToGreaterThanOrEqualTo(0));
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}