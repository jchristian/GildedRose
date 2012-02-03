namespace GildedRose.Console.AnotherSetOfItems
{
    public class Default : Item, IContainAnItem
    {
        IContainAnItem _itemWrapper;

        public string Name { get { return _itemWrapper.Name; } set { _itemWrapper.Name = value; } }
        public int Quality { get { return _itemWrapper.Quality; } set { _itemWrapper.Quality = value; } }
        public int SellIn { get { return _itemWrapper.SellIn; } set { _itemWrapper.SellIn = value; } }

        public Default(IContainAnItem itemWrapper)
        {
            _itemWrapper = itemWrapper;
        }

        public virtual void UpdateQuality()
        {
            _itemWrapper.UpdateQuality();
        }

        public virtual void UpdateSellIn()
        {
            _itemWrapper.UpdateSellIn();
        }

        public void Update()
        {
            UpdateSellIn();
            UpdateQuality();
        }
    }
}