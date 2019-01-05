using HtmlAgilityPack;
using System;
using System.Linq;

namespace AgilityPackTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var oldHtml = @"https://www.centracare.com/providers/profile/sarah-abdul-jabbar";
            HtmlWeb oldWeb = new HtmlWeb();
            var oldHtmlDoc = oldWeb.Load(oldHtml);

            //var newHtml = @"http://centracare.scorpionwebsite.com/doctors/sarah-abdul-jabbar-mbbs/";
            var newHtml = @"http://centracare.scorpionwebsite.com/doctors/oluyemi-a-ajayi-mbbs/";
            HtmlWeb newWeb = new HtmlWeb();
            var newHtmlDoc = newWeb.Load(newHtml);

            int score = 0;

            //var node = oldHtmlDoc.DocumentNode.SelectSingleNode("//body/main");
            var oldNode = oldHtmlDoc.DocumentNode.SelectSingleNode("//h1").InnerText;
            var newNode = newHtmlDoc.DocumentNode.SelectSingleNode("//h1").InnerText;

            var oldText = getText(oldNode);
            var newText = getText(newNode);

            Console.WriteLine(oldText== newText);
            if (oldText == newText)
                score++;
            else
                score--;

            Console.WriteLine($"score: {score}");
            Console.WriteLine("Hello World!");
        }

        static string getText(string node)
        {
            return System.Text.RegularExpressions.Regex.Replace((node.Trim()), @"\s+", " ");
        }
    }
}