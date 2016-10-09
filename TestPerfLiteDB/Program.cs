using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;

namespace TestPerfLiteDB
{
    class Program
    {
        public const int N = 1000;

        static void Main(string[] args)
        {
            Console.WriteLine("Total records: " + N);
            Console.WriteLine();

            Console.WriteLine("Journal Enabled");
            Helper.Write("SQLite - Insert: ", SQLite_Test.Insert(true));
            Helper.Write("LiteDB - Insert: ", LiteDB_Test.Insert(true));
            Helper.Write("SQLite - Bulk  : ", SQLite_Test.Bulk(true));
            Helper.Write("LiteDB - Bulk  : ", LiteDB_Test.Bulk(true));

            Console.WriteLine();
            Console.WriteLine("Journal Disabled");

            Helper.Write("SQLite - Insert: ", SQLite_Test.Insert(false));
            Helper.Write("LiteDB - Insert: ", LiteDB_Test.Insert(false));
            Helper.Write("SQLite - Bulk  : ", SQLite_Test.Bulk(false));
            Helper.Write("LiteDB - Bulk  : ", LiteDB_Test.Bulk(false));

            Console.ReadKey();
        }
    }
}
