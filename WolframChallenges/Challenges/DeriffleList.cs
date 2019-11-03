using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WolframChallenges.Shared;

namespace WolframChallenges
{
    public class DeriffleList
    {
        private readonly IUtilities _utilities;

        public DeriffleList(IUtilities utilities)
        {
            _utilities = utilities;
        }

        public List<object> Riffle(List<List<object>> lists)
        {
            List<object> combinedList = new List<object>();

            int listNum = 0;
            int arrayIndex = 0;
            for(int i = 0; i < lists.Sum(c => c.Count); i++)
            {
                combinedList.Add(lists[listNum][arrayIndex]);


                listNum++;
                if (listNum == lists.Count)
                {
                    listNum = 0;
                    arrayIndex++;
                }

            }

            return combinedList;
        }
        public List<object> Riffle(object[] lists)
        {
            List<object> combinedList = new List<object>();
            List<List<object>> list = (List<List<object>>) lists[0];
            int listNum = 0;
            int arrayIndex = 0;
            for (int i = 0; i < list.Sum(c => c.Count); i++)
            {
                combinedList.Add(list[listNum][arrayIndex]);


                listNum++;
                if (listNum == list.Count)
                {
                    listNum = 0;
                    arrayIndex++;
                }

            }
            return combinedList;
        }

        public List<List<object>> DeRiffle(List<object> list, int amountOfLists)
        {
            List<List<object>> newList = new List<List<object>>();

            int round = 1;
            for (int i = 0; i < amountOfLists; i++)
            {
                List<object> loopList = new List<object>();
                for (int j = 0 + i; j < list.Count; j = j + amountOfLists)
                {
                    loopList.Add(list[j]);
                }
                newList.Add(loopList);
            }

            return newList;
        }

    }
}
