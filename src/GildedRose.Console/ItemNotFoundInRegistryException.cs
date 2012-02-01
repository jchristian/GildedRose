using System;

namespace GildedRose.Console
{
    public class ItemNotFoundInRegistryException : Exception
    {
        public Item ItemNotFound { get; private set; }

        public ItemNotFoundInRegistryException(Item itemNotFound) : base(string.Format("The item <{0}> was not matched in the registry", itemNotFound))
        {
            ItemNotFound = itemNotFound;
        }
    }
}