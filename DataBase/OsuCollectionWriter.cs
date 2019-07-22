using OsuUtil.Collection;
using OsuUtil.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuUtil.DataBase
{
    public class OsuCollectionWriter
    {
        public bool WriteToStream(OsuCollectionDb collectionDb, Stream stream)
        {
            if (collectionDb == null)
                return false;

            using (OsuBinaryWriter writer = new OsuBinaryWriter(stream))
            {
                writer.Write(collectionDb.Version);

                int count = collectionDb.CollectionList.Count;
                writer.Write(count);

                foreach (OsuCollection collection in collectionDb.CollectionList)
                {
                    writer.WriteString(collection.Name);

                    int collectionCount = collection.BeatmapHashList.Count;
                    writer.Write(collectionCount);

                    foreach (string hash in collection.BeatmapHashList)
                    {
                        writer.WriteString(hash);
                    }
                }
            }

            return true;
        }
    }
}
