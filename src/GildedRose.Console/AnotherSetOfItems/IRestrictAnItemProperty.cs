
namespace GildedRose.Console.AnotherSetOfItems
{
    public interface IRestrictAnItemProperty : IContainAnItem
    {
        bool ShouldRestrict();
    }
}