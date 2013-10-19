using System;
using System.Collections.Generic;
using Batch1Work.Models;

namespace Batch1Work.Helpers
{
    public class SampleDataHelper
    {
        private static readonly Random Rnd = new Random();

        public static IList<ActionGridItem> GenerateActionGridItems(int numberOfItemsToCreate)
        {
            var dictionary = new SortedDictionary<string, ActionGridItem>();
            int index = 1;
            for (int i = 1; i <= numberOfItemsToCreate; i++)
            {
                var actionGridItem = CreateActionGridItem();
                dictionary.Add(actionGridItem.Key + index, actionGridItem);
                index++;
            }
            return new List<ActionGridItem>(dictionary.Values);
        }

        private static ActionGridItem CreateActionGridItem()
        {
            var actionGridItem = new ActionGridItem
            {
                Building = "Building " + Rnd.Next(1, 5),
                Floor = "Floor " + Rnd.Next(1, 10),
                Area = "Area " + Rnd.Next(1, 10),
                Item = "Item " + Rnd.Next(1, 10),
                ProductType = "ProductType " + Rnd.Next(1, 5),
                AsbestosType = "AsbestosType " + Rnd.Next(1, 5),
                Quantity = "Quantity " + Rnd.Next(1, 5),
                MaScore = Rnd.Next(0, 3),
                PaScore = Rnd.Next(0, 9)
            };
            actionGridItem.RiskScore = actionGridItem.MaScore + actionGridItem.PaScore;
            actionGridItem.RiskCategory = "RiskCategory " + actionGridItem.RiskScore;
            actionGridItem.RecAction = "RecAction " + Rnd.Next(1, 5);
            return actionGridItem;
        }


    }
}