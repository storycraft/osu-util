using System;
using System.Collections.Generic;

namespace OsuUtil.DataBase
{
    public interface CollectionDb
    {
        Dictionary<String, List<String>> CollectionSet { get; }

        bool HasCollection(String name);
    }
}
