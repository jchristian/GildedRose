namespace GildedRose.Console.AnotherSetOfItems
{
    public class DecrementSellIn : Default
    {
        IContainAnItem _itemWrapper;

        public DecrementSellIn(IContainAnItem itemWrapper)
            : base(itemWrapper)
        {
            _itemWrapper = itemWrapper;
        }

        public override void UpdateSellIn()
        {
            _itemWrapper.UpdateSellIn();
            _itemWrapper.SellIn -= 1;
        }
    }
}