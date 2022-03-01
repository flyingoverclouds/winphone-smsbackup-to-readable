using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace WPSmsBkpConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            string testFile = "d:\\smsBackup640XL-for-dev.xml"; // replace with the XML backup file you want to use
            var xmlMsg = File.ReadAllText(testFile);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlMsg);


            HashSet<string> numbers =  new HashSet<string>();
            numbers.Add("+330600000000"); // the 3rd party phone number you want to retrieve

            var converter = new SingleFileConverter(numbers);
            converter.Convert(doc,"+33611111111");  // your OWN phone numver as it appear in the XML file
        }


        static void ParseArgs(string[] args)
        {
            for(int n=0;n<args.Length;n++)
            {
                switch (args[n])
                {
                    case "-f":
                        PrintHelp();
                        Environment.Exit(0);
                        break;
                }
            }
        }

        static void PrintHelp()
        {
            Console.WriteLine("TODO :)");
        }
    }
}

