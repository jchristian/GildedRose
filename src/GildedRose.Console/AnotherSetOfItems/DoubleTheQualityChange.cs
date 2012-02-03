namespace GildedRose.Console.AnotherSetOfItems
{
    public class DoubleTheQualityChange : Default
    {
        IContainAnItem _itemWrapper;

        public DoubleTheQualityChange(IContainAnItem itemWrapper)
            : base(itemWrapper)
        {
            _itemWrapper = itemWrapper;
        }

        public override void UpdateQuality()
        {
            _itemWrapper.UpdateQuality();
            _itemWrapper.UpdateQuality();
        }
    }
}