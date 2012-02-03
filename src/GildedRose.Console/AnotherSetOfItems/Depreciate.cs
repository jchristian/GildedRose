namespace GildedRose.Console.AnotherSetOfItems
{
    public class Depreciate : Default
    {
        IContainAnItem _itemWrapper;

        public Depreciate(IContainAnItem itemWrapper)
            : base(itemWrapper)
        {
            _itemWrapper = itemWrapper;
        }

        public override void UpdateQuality()
        {
            _itemWrapper.UpdateQuality();
            _itemWrapper.Quality -= 1;
        }
    }
}