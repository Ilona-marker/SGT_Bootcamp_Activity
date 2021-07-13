using CSharp.Activity.Collections;
using CSharp.Activity.CoreUtilities;
using System;
using System.Diagnostics;
using System.Text;

namespace Activity8.Tests
{
    public class Activity8_Tests
    {
        private static int statusCode = 0;

        private static readonly FileHandling fh = new("test_results.txt");

        private static void Test(Action testCase, string testName, Type exceptionType = null)
        {
            Test(() =>
            {
                testCase.Invoke();
                return true;
            }, testName, exceptionType);
        }

        private static void Test(Func<bool> testCase, string testName, Type exceptionType = null)
        {
            Stopwatch watch = new();

            watch.Start();

            // we assume success to be true, if exception type is not set.
            // however, if exception type is selected, then failure is the default,
            // as we want to actually catch that expected exception!

            bool success = exceptionType == null;
            try
            {
                if (!testCase.Invoke())
                {
                    success = false;
                }
            }
            catch (Exception e)
            {
                if (exceptionType != null && (e.GetType().Equals(exceptionType) || e.GetType().IsSubclassOf(exceptionType)))
                {
                    success = true;
                }
                else
                {
                    success = false;

                    // we want to include the exception in the output.
                    // 'temporary solutions' are the most permanent.
                    StringBuilder builder = new(testName);
                    foreach (string line in e.ToString().Split("\n"))
                    {
                        builder.Append("\n    ");
                        builder.Append(line);
                    }
                    testName = builder.ToString();
                }
            }
            watch.Stop();

            long millis = watch.ElapsedMilliseconds;
            string status = success ? "PASS" : "FAIL";
            fh.WriteToDisk($"{status} ({millis}ms): {testName}\n");

            if (!success)
            {
                statusCode = 1;
            }
        }

        public static int Main()
        {
            try
            {
                Stopwatch watch = new();

                watch.Start();
                CustomerInfoCollection collection = new();
                CustomerInfo[] infos = new CustomerInfo[] {
                    new CustomerInfo(0, "Jane Doe", "Baker Street 1001", "jane.doe@email.com"),
                    new CustomerInfo(1, "John Doe", "Baker Street 1003", "john.doe@email.com"),
                    new CustomerInfo(2, "Sarah Green", "W Smith Street 2009", "sgreen@example.com"),
                    new CustomerInfo(3, "Peter Woods", "Apple Ave 7013", "peter@woods.org")
                };
                watch.Stop();
                fh.WriteToDisk($"PASS ({watch.ElapsedMilliseconds}ms): Initialization\n");
                watch.Reset();

                for (int i = 0; i < 3; i++)
                {
                    Test(() => collection.Add(infos[i]) == i, $"Add(i={i})");
                }

                for (int i = 0; i < 3; i++)
                {
                    Test(() => collection[i].Equals(infos[i]), $"Indexer[{i}] get");
                }

                Test(() => collection.Add(infos[0]) == -1, $"Add(i=0)");

                Test(() => collection.Insert(2, infos[3]), $"Insert(i=2)");
                Test(() => collection[2].Equals(infos[3]), $"Indexer[2] get");
                Test(() => collection[3].Equals(infos[2]), $"Indexer[3] get");

                Test(() => collection.IndexOf(infos[2]) == 3, $"IndexOf(i=3)");
                Test(() => collection.Contains(infos[2]), $"Contains(i=3)");
                Test(() => collection.Remove(infos[2]), $"Remove(i=3)");
                Test(() => collection.IndexOf(infos[2]) == -1, $"IndexOf(i=-1)");
                Test(() => !collection.Contains(infos[2]), $"Contains(i=-1)");

                Test(() => collection[2] = infos[2], $"Indexer[2] set");
                Test(() => collection[2].Equals(infos[2]), $"Indexer[2] get");
                Test(() => !collection.Contains(infos[3]), $"Contains(i=-1)");

                Test(() => collection.Insert(10, infos[3]), "Insert(10)", typeof(ArgumentOutOfRangeException));

                Test(() => collection.Add(null), "Add(null)", typeof(ArgumentNullException));
                Test(() => collection.Insert(-1, infos[0]), "Insert(-1)", typeof(ArgumentOutOfRangeException));
                Test(() => collection.Insert(0, null), "Insert(0, null)", typeof(ArgumentNullException));
                Test(() => collection.Remove(null), "Remove(null)", typeof(ArgumentNullException));
                Test(() => collection.Contains(null), "Contains(null)", typeof(ArgumentNullException));
                Test(() => collection.IndexOf(null), "IndexOf(null)", typeof(ArgumentNullException));
            }
            catch (Exception e)
            {
                statusCode = 1;

                StringBuilder builder = new("FAIL:");
                foreach (string line in e.ToString().Split("\n"))
                {
                    builder.Append("\n    ");
                    builder.Append(line);
                }
                builder.Append('\n');
                fh.WriteToDisk(builder.ToString());
            }

            Console.WriteLine(fh.ReadFromDisk());
            return statusCode;
        }
    }
}

