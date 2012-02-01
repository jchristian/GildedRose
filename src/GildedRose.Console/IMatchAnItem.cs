namespace GildedRose.Console
{
    public interface IMatchAnItem
    {
        bool CanCreateFrom(Item item);
        Item Factory(Item item);
    }
}