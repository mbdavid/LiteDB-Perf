using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPerfLiteDB
{
    public class SQLite_Test
    {
        public static Stopwatch Insert(bool journal)
        {
            var sw = new Stopwatch();

            using (var db = PrepareDB(journal))
            {
                var cmd = GetInsert(db);

                sw.Start();

                foreach (var doc in Helper.GetDocs())
                {
                    cmd.Parameters["id"].Value = doc["_id"].AsInt32;
                    cmd.Parameters["name"].Value = doc["name"].AsString;
                    cmd.Parameters["lorem"].Value = doc["lorem"].AsString;
                    
                    cmd.ExecuteNonQuery();
                }

                db.Dispose();

                sw.Stop();
            }

            return sw;
        }

        public static Stopwatch Bulk(bool journal)
        {
            var sw = new Stopwatch();

            using (var cn = PrepareDB(journal))
            {
                using (var trans = cn.BeginTransaction())
                {
                    var cmd = GetInsert(cn);

                    sw.Start();

                    foreach (var doc in Helper.GetDocs())
                    {
                        cmd.Parameters["id"].Value = doc["_id"].AsInt32;
                        cmd.Parameters["name"].Value = doc["name"].AsString;
                        cmd.Parameters["lorem"].Value = doc["lorem"].AsString;

                        cmd.ExecuteNonQuery();
                    }

                    trans.Commit();

                    sw.Stop();
                }
            }

            return sw;
        }


        private static SQLiteConnection PrepareDB(bool journal)
        {
            var file = "sqlite_" + Guid.NewGuid() + ".db";

            if (journal == false) file += "; Journal Mode=Off;";

            var db = new SQLiteConnection("Data Source=" + file);
            db.Open();

            var table = new SQLiteCommand("CREATE TABLE demo (id INTEGER NOT NULL PRIMARY KEY, name TEXT, lorem TEXT)", db);
            table.ExecuteNonQuery();

            return db;
        }

        private static SQLiteCommand GetInsert(SQLiteConnection db)
        {
            var cm = new SQLiteCommand("INSERT INTO demo (id, name, lorem) VALUES (@id, @name, @lorem)", db);

            cm.Parameters.Add(new SQLiteParameter("id", DbType.Int32));
            cm.Parameters.Add(new SQLiteParameter("name", DbType.String));
            cm.Parameters.Add(new SQLiteParameter("lorem", DbType.String));

            return cm;
        }
    }
}
