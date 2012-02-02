namespace GildedRose.Console.Items
{
    public class NormalItem : IUpdateMyself
    {
        protected Item _item;

        public NormalItem(Item item)
        {
            _item = item;
        }

        public virtual void Update()
        {
            UpdateSellIn();
            UpdateQuality();
        }

        protected virtual void UpdateSellIn()
        {
            _item.SellIn -= 1;
        }

        protected virtual void UpdateQuality()
        {
            if (_item.SellIn < 0)
                _item.Quality -= 2;
            else
                _item.Quality -= 1;

            if (_item.Quality > 50)
                _item.Quality = 50;

            if (_item.Quality < 0)
                _item.Quality = 0;
        }
    }
}