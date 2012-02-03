namespace GildedRose.Console.AnotherSetOfItems
{
    public class Combine : Default
    {
        IContainAnItem _firstItem;
        IContainAnItem _secondItem;

        public Combine(IContainAnItem firstItem, IContainAnItem secondItem) : base(firstItem)
        {
            _firstItem = firstItem;
            _secondItem = secondItem;
        }

        public override void UpdateQuality()
        {
            _firstItem.UpdateQuality();
            _secondItem.UpdateQuality();
        }

        public override void UpdateSellIn()
        {
            _firstItem.UpdateSellIn();
            _secondItem.UpdateSellIn();
        }
    }
}