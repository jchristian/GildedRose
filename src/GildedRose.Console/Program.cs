﻿using System.Collections.Generic;
using GildedRose.Console.AnotherSetOfItems;

namespace GildedRose.Console
{
    public class Program
    {
        IParseItems _itemParser;
        IList<Item> Items;

        public Program(IParseItems itemParser, params Item[] items)
        {
            _itemParser = itemParser;
            Items = items;
        }

        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program(new ItemParser(new ItemFactoryRegistry(new ItemFactories())),
                                  new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
                                  new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 },
                                  new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 },
                                  new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
                                  new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 },
                                  new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 });
            

            app.UpdateQuality();

            System.Console.ReadKey();
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                _itemParser.Parse(item).Update();
            }
        }
    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }

}
