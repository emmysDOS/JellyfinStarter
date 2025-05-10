

using System;
using System.Diagnostics;
using System.IO;

class Program
{
    static string ip;
    static void StartBrowser()
    {
            string userName = Environment.UserName;
            string browserPath = "C:\\Users\\" + userName + "\\AppData\\Local\\Chromium\\Application\\chrome.exe";
            using Process fileOpener = new Process();
            Process.Start(browserPath,ip);
    }
    static void WriteToFile()
    {
            //Asks for jellifin ip
            Console.WriteLine("Enter your Jellyfin IP: ");
            string ip = Console.ReadLine();

            //sets a path for the ip save file 
            string userName = Environment.UserName;
            string path = "C:\\Users\\" + userName + "\\Documents\\userIp.txt";

            //Wirites the ip save file
            System.IO.File.WriteAllText(path, ip);
            File.ReadAllText(path);
    }
    static void CreateFile()
    {
        //Sets a path for the ip save file 
        string userName = Environment.UserName;
        string path = "C:\\Users\\" + userName + "\\Documents\\userIp.txt";

        //Create 
        var ipFile = File.Create(path);
        Console.WriteLine("URL file created");
        Console.WriteLine("Please, run the program another time to proceed");
        System.Threading.Thread.Sleep(2000);
    }
    static void ReadFile()
    {
        using StreamReader reader = new("C:\\Users\\Subawoo\\Documents\\userIp.txt");
        ip = reader.ReadToEnd();
    }
    static void Main(string[] args)
    {
        try
        {
            ReadFile();
            if (ip == "")
            {
                WriteToFile();
                ReadFile();
                StartBrowser();
            }
            else
                StartBrowser();
        }
        catch
        {
            CreateFile();
        }
    }
    
}