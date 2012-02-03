namespace GildedRose.Console.AnotherSetOfItems
{
    public class Appreciate : Default
    {
        IContainAnItem _itemWrapper;

        public Appreciate(IContainAnItem itemWrapper)
            : base(itemWrapper)
        {
            _itemWrapper = itemWrapper;
        }

        public override void UpdateQuality()
        {
            _itemWrapper.UpdateQuality();
            _itemWrapper.Quality += 1;
        }
    }
}