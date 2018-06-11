using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuUtil.DataBase
{
    public class OsuCollectionDb : CollectionDb
    {
        public Dictionary<string, List<string>> CollectionSet { get; }

        public OsuCollectionDb(Dictionary<string, List<string>> collectionSet)
        {
            CollectionSet = collectionSet;
        }

        public bool HasCollection(string name)
        {
            return CollectionSet.ContainsKey(name);
        }
    }
}
