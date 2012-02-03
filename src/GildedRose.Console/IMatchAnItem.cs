namespace GildedRose.Console
{
    public interface IMatchAnItem
    {
        bool CanCreateFrom(Item item);
        IUpdateAnItem Factory(Item item);
    }
}