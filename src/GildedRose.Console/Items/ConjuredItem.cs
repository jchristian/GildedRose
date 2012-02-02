namespace GildedRose.Console.Items
{
    public class ConjuredItem : NormalItem
    {
        public ConjuredItem(Item item) : base(item) { }

        protected override void UpdateQuality()
        {
            base.UpdateQuality();
            base.UpdateQuality();

            if (_item.Quality > 50)
                _item.Quality = 50;

            if (_item.Quality < 0)
                _item.Quality = 0;
        }
    }
}