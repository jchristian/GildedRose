namespace GildedRose.Console.Items
{
    public class AgedBrieItem : NormalItem
    {
        public AgedBrieItem(Item item) : base(item) { }

        protected override void UpdateQuality()
        {
            if (_item.SellIn < 0)
                _item.Quality += 2;
            else
                _item.Quality += 1;

            if (_item.Quality > 50)
                _item.Quality = 50;

            if (_item.Quality < 0)
                _item.Quality = 0;
        }
    }
}