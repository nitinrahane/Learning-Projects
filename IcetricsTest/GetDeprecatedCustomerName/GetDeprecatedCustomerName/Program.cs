using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/* Don't change anything here.
 * Do not add any other imports. You need to write
 * this program using only these libraries 
 */

namespace ProgramNamespace
{
    /* You may add helper classes here if necessary */

    public class Program
    {
        public static List<String> processData(IEnumerable<string> lines)
        {
            List<String> retVal = new List<String>();
            try
            {

                Dictionary<string, int> curLatestAPIVersion = new Dictionary<string, int>();
                Dictionary<string, bool> custData = new Dictionary<string, bool>();
                List<string[]> lineSplits = new List<string[]>();

                if (lines != null && lines.Count() > 0)
                {
                    foreach (var line in lines)
                    {
                        var splits = line.Split(',');
                        lineSplits.Add(splits);
                        if (splits != null && splits.Length == 4)
                        {
                            var apiVersionArray = splits[3].Trim().Split(' ');
                            if (apiVersionArray != null && apiVersionArray.Length == 2)
                            {
                                var apiName = splits[2].Trim();
                                var currentApiVersion = Convert.ToInt32(apiVersionArray[1].Trim());
                                if (!string.IsNullOrEmpty(apiName))
                                {
                                    if (!curLatestAPIVersion.ContainsKey(apiName))
                                    {
                                        curLatestAPIVersion.Add(apiName, currentApiVersion);
                                    }
                                    else
                                    {
                                        if (curLatestAPIVersion[apiName] < currentApiVersion)
                                        {
                                            curLatestAPIVersion[apiName] = currentApiVersion;
                                        }
                                    }
                                }
                            }

                        }

                    }

                    foreach (var splittedLine in lineSplits)
                    {
                        var apiVersionArray = splittedLine[3].Trim().Split(' ');
                        var apiName = splittedLine[2].Trim();
                        var currentApiVersion = Convert.ToInt32(apiVersionArray[1].Trim());
                        var customerName = splittedLine[0].Trim();
                        if (!string.IsNullOrEmpty(apiName) && curLatestAPIVersion.ContainsKey(apiName))
                        {
                            if (!custData.ContainsKey(customerName))
                            {
                                custData.Add(customerName, currentApiVersion >= curLatestAPIVersion[apiName]);
                            }
                            else
                            {
                                if (!custData[customerName])
                                {
                                    custData[customerName] = currentApiVersion >= curLatestAPIVersion[apiName];
                                }
                            }

                        }
                    }

                    if (custData != null && custData.Count() > 0) {
                        retVal = custData.Where(x => x.Value == false).Select(x => x.Key).ToList();
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            return retVal;

        }

        static void Main(string[] args)
        {
            try
            {
                String line;
                var inputLines = new List<String>();
                while ((line = Console.ReadLine()) != null)
                {
                    line = line.Trim();
                    if (line != "")
                        inputLines.Add(line);
                }
                var retVal = processData(inputLines);
                foreach (var res in retVal)
                    Console.WriteLine(res);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
