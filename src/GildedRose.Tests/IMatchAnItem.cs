using GildedRose.Console;

namespace GildedRose.Tests
{
    public interface IMatchAnItem
    {
        bool CanCreateFrom(Item item);
        Item Factory(Item item);
    }
}