namespace GildedRose.Console.AnotherSetOfItems
{
    public class ItemAdapter : IContainAnItem
    {
        Item _item;

        public string Name { get { return _item.Name; } set { _item.Name = value; } }
        public int Quality { get { return _item.Quality; } set { _item.Quality = value; } }
        public int SellIn { get { return _item.SellIn; } set { _item.SellIn = value; } }

        public ItemAdapter(Item item)
        {
            _item = item;
        }

        public void UpdateQuality()
        { }

        public void UpdateSellIn()
        { }

        public void Update()
        { }
    }
}