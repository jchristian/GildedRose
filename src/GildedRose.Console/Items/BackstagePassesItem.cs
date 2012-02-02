namespace GildedRose.Console.Items
{
    public class BackstagePassesItem : NormalItem
    {
        public BackstagePassesItem(Item item) : base(item) { }

        protected override void UpdateQuality()
        {
            if (_item.SellIn < 10)
                _item.Quality += 2;
            else if (_item.SellIn < 5)
                _item.Quality += 3;
            else
                _item.Quality += 1;

            if (_item.Quality > 50)
                _item.Quality = 50;

            if (_item.Quality < 0)
                _item.Quality = 0;
        }
    }
}