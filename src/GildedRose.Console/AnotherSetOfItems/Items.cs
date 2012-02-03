namespace GildedRose.Console.AnotherSetOfItems
{
    public class Items
    {
        public static IContainAnItem Wrap(Item item)
        {
            return new ItemAdapter(item);
        }
    }
}