using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;

namespace TestPerfLiteDB
{
    class Program
    {
        static void Main(string[] args)
        {
            RunTest("LiteDB: default", new LiteDB_Test(5000, null, new FileOptions { Journal = true, FileMode = FileOpenMode.Shared }));
            RunTest("LiteDB: encrypted", new LiteDB_Test(5000, "mypass", new FileOptions { Journal = true, FileMode = FileOpenMode.Shared }));
            RunTest("LiteDB: exclusive no journal", new LiteDB_Test(5000, null, new FileOptions { Journal = false, FileMode = FileOpenMode.Exclusive }));

            RunTest("SQLite: default", new SQLite_Test(5000, null, true));
            RunTest("SQLite: encrypted", new SQLite_Test(5000, "mypass", true));
            RunTest("SQLite: no journal", new SQLite_Test(5000, null, false));

            Console.ReadKey();
        }

        static void RunTest(string name, ITest test)
        {
            var title = name + " - " + test.Count + " records";
            Console.WriteLine(title);
            Console.WriteLine("=".PadLeft(title.Length, '='));

            test.Prepare();

            test.Run("Insert", test.Insert);
            test.Run("Bulk", test.Bulk);
            test.Run("Update", test.Update);
            test.Run("CreateIndex", test.CreateIndex);
            test.Run("Query", test.Query);
            test.Run("Delete", test.Delete);
            test.Run("Drop", test.Drop);

            Console.WriteLine("FileLength     : " + Math.Round((double)test.FileLength / (double)1024, 2).ToString().PadLeft(5, ' ') + " kb");

            test.Dispose();

            Console.WriteLine();

        }
    }
}
