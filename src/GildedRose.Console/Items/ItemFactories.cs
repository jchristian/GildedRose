using System.Collections;
using System.Collections.Generic;

namespace GildedRose.Console.Items
{
    public class ItemFactories : IContainTheItemFactories
    {
        public IEnumerator<IMatchAnItem> GetEnumerator()
        {
            yield return new GenericItemMatch(item => item.Name.StartsWith("Conjured"), item => new ConjuredItem(item));
            yield return new GenericItemMatch(item => item.Name == "Aged Brie", item => new AgedBrieItem(item));
            yield return new GenericItemMatch(item => item.Name == "Backstage passes to a TAFKAL80ETC concert", item => new BackstagePassesItem(item));
            yield return new GenericItemMatch(item => item.Name == "Sulfuras, Hand of Ragnaros", item => new SulfurasItem(item));
            yield return new GenericItemMatch(item => true, item => new NormalItem(item));
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}