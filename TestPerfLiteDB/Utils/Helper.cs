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
    class Helper
    {
        public static void Write(string msg, Stopwatch sw)
        {
            Console.WriteLine(msg + 
                sw.ElapsedMilliseconds + " ms - " + 
                Math.Round(Program.N / sw.Elapsed.TotalSeconds) + " records/second");
        }

        public static IEnumerable<BsonDocument> GetDocs()
        {
            for(var i = 0; i < Program.N; i++)
            {
                yield return new BsonDocument
                {
                    { "_id", i },
                    { "name", Guid.NewGuid().ToString() },
                    { "lorem", LoremIpsum(3, 5, 2, 3, 3) }
                };
            }
        }

        public static string LoremIpsum(int minWords, int maxWords,
            int minSentences, int maxSentences,
            int numParagraphs)
        {
            var words = new[] { "lorem", "ipsum", "dolor", "sit", "amet", "consectetuer",
                "adipiscing", "elit", "sed", "diam", "nonummy", "nibh", "euismod",
                "tincidunt", "ut", "laoreet", "dolore", "magna", "aliquam", "erat" };

            var rand = new Random(DateTime.Now.Millisecond);
            var numSentences = rand.Next(maxSentences - minSentences) + minSentences + 1;
            var numWords = rand.Next(maxWords - minWords) + minWords + 1;

            var result = new StringBuilder();

            for (int p = 0; p < numParagraphs; p++)
            {
                for (int s = 0; s < numSentences; s++)
                {
                    for (int w = 0; w < numWords; w++)
                    {
                        if (w > 0) { result.Append(" "); }
                        result.Append(words[rand.Next(words.Length)]);
                    }
                    result.Append(". ");
                }
                result.AppendLine();
            }

            return result.ToString();
        }
    }
}
