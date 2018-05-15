using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace NetSpider.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Title = System.Configuration.ConfigurationManager.AppSettings["Title"].ToString();
                Console.WriteLine("Process is running！");
                
                string url = System.Configuration.ConfigurationManager.AppSettings["URL"].ToString();
                UrlQueue.GetInstance().Enqueue(url);
                ThreadManager thread = new ThreadManager();
                thread.Start();
            }
            catch (Exception ex)
            {
            }
            Console.ReadLine();
        }

    }
}
