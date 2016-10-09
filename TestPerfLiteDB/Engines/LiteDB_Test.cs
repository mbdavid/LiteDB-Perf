using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;

namespace TestPerfLiteDB
{
    public class LiteDB_Test
    {
        public static Stopwatch Insert(bool journal)
        {
            var sw = new Stopwatch();

            using (var db = PrepareDB(journal))
            {
                sw.Start();

                foreach (var doc in Helper.GetDocs())
                {
                    db.Insert("demo", doc);
                }

                sw.Stop();
            }

            return sw;
        }

        public static Stopwatch Bulk(bool journal)
        {
            var sw = new Stopwatch();

            using (var db = PrepareDB(journal))
            {
                sw.Start();

                db.Insert("demo", Helper.GetDocs());

                sw.Stop();
            }

            return sw;
        }

        private static LiteEngine PrepareDB(bool journal)
        {
            var file = "litedb_" + Guid.NewGuid() + ".db";

            return new LiteEngine(file, journal);
        }
    }
}
