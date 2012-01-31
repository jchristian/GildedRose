using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Program
    {
        IList<Item> Items;

        public Program(params Item[] items)
        {
            Items = items;
        }

        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program
                      {
                          Items = new List<Item>
                                  {
                                      new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
                                      new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 },
                                      new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 },
                                      new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
                                      new Item
                                      {
                                          Name = "Backstage passes to a TAFKAL80ETC concert",
                                          SellIn = 15,
                                          Quality = 20
                                      },
                                      new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 }
                                  }
                      };
            

            app.UpdateQuality();

            System.Console.ReadKey();
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                UpdateSellIn(item);

                if (item.Name == "Aged Brie")
                {
                    UpdateQualityOfAgedBrie(item);
                }
                else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    UpdateQualityOfBackstagePasses(item);
                }
                else if (item.Name != "Sulfuras, Hand of Ragnaros")
                {
                    UpdateQualityOfNormalItem(item);
                }
            }
        }

        void UpdateQualityOfAgedBrie(Item item)
        {
            AppreciateQuality(item);

            if(item.SellIn < 0)
                AppreciateQuality(item);
        }

        static void AppreciateQuality(Item item)
        {
            if (item.Quality < 50)
                item.Quality = item.Quality + 1;
        }

        static void UpdateSellIn(Item item)
        {
            if (item.Name != "Sulfuras, Hand of Ragnaros")
                item.SellIn = item.SellIn - 1;
        }

        static void UpdateQualityOfBackstagePasses(Item item)
        {
            if (item.SellIn < 0)
                item.Quality = 0;
            else
            {
                if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (item.Quality < 50)
                    {
                        if (item.SellIn < 11)
                            AppreciateQuality(item);

                        if (item.SellIn < 6)
                            AppreciateQuality(item);
                    }
                }
            }
        }

        static void UpdateQualityOfNormalItem(Item item)
        {
            DepreciateQuality(item);

            if(item.SellIn < 0)
                DepreciateQuality(item);
        }

        static void DepreciateQuality(Item item)
        {
            if (item.Quality > 0)
                item.Quality = item.Quality - 1;
        }
    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }

}
