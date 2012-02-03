namespace GildedRose.Console.AnotherSetOfItems
{
    public interface IContainAnItem : IUpdateAnItem
    {
        string Name { get; set; }
        int Quality { get; set; }
        int SellIn { get; set; }

        void UpdateQuality();
        void UpdateSellIn();
    }
}