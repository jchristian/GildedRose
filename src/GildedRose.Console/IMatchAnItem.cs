namespace GildedRose.Console
{
    public interface IMatchAnItem
    {
        bool CanCreateFrom(Item item);
        IUpdateMyself Factory(Item item);
    }
}