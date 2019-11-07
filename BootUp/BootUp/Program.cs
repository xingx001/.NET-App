using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceProcess;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Threading;
using System.IO;

namespace BootUp
{
    class Program
    {
        #region 常量
        /// <summary>
        /// 分隔符
        /// </summary>
        private const char SPLIT = '|';
        /// <summary>
        /// 定时间隔
        /// </summary>
        private const int INTERVAL = 30000;
        /// <summary>
        /// 延迟值
        /// </summary>
        private const int DELAY = 60000;
        /// <summary>
        /// 等待值
        /// </summary>
        private const int SLEEP = 5000;
        /// <summary>
        /// 启动中
        /// </summary>
        private const string START_MSG = "{0} DELAY: {1} MILLISECONDS;\r\n{0} TIMER: {2} MILLISECONDS;\r\n{0} STARTING...";
        /// <summary>
        /// 条件准备通过
        /// </summary>
        private const string READY_MSG = "{0} {1} TICK IS READY;STARTUP PROGRAM...";
        /// <summary>
        /// 条件准备未通过
        /// </summary>
        private const string READY_ERR_MSG = "{0} {1} TICK IS NOT READY;";
        /// <summary>
        /// 启动成功
        /// </summary>
        private const string START_SUCCESS_MSG = "{0} PROCESS STARTING SUCCESS;SYSTEM IS ABOUT TO SHUT DOWN!";
        /// <summary>
        /// 等待下次TICK
        /// </summary>
        private const string WATING_MSG = "{0} WAITING NEXT TICK...";
        /// <summary>
        /// 程序路径错误
        /// </summary>
        private const string FILE_ERR_MSG = "{0} PROCESS IS NOT EXIST;SYSTEM IS ABOUT TO SHUT DOWN!";
        /// <summary>
        /// 启动错误
        /// </summary>
        private const string START_ERR_MSG = "{0} PROCESS STARTING ERR;\r\n{1}";
        #endregion

        /// <summary>
        /// 服务集合
        /// </summary>
        private static string[] services;
        /// <summary>
        /// 程序集合
        /// </summary>
        private static string[] processes;
        /// <summary>
        /// 启动程序路径
        /// </summary>
        private static string path;
        /// <summary>
        /// 定时次数
        /// </summary>
        private static int tick = 0;
        /// <summary>
        /// 重入标记
        /// </summary>
        private static int inTimer = 0;

        #region Main
        static void Main(string[] args)
        {
            InitPath();

            services = GetVals("services");
            processes = GetVals("processes");

            int interval = GetVal("interval");
            if (interval <= 0)
                interval = INTERVAL;

            int delay = GetVal("delay");
            if (delay <= 0)
                delay = DELAY;

            System.Threading.Timer timer = new System.Threading.Timer(Timer_Tick, null, delay, interval);//开启定时器
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(START_MSG, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), delay, interval);
            Console.ReadKey();
        }
        #endregion

        #region 初始化路径
        private static void InitPath()
        {
            bool isExsit = false;
            string file = ConfigurationManager.AppSettings["file"];
            if (!string.IsNullOrEmpty(file))
            {
                path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, file);
                isExsit = File.Exists(path);
            }

            if (!isExsit)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(FILE_ERR_MSG, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                Thread.Sleep(SLEEP);
                Environment.Exit(0);
            }
        }
        #endregion

        #region 获取配置值字符串集合
        private static string[] GetVals(string key)
        {
            string vals = ConfigurationManager.AppSettings[key];
            if (string.IsNullOrEmpty(vals))
                return null;
            return vals.Split(SPLIT);
        }
        #endregion

        #region 获取配置值整数值
        private static int GetVal(string key)
        {
            string val = ConfigurationManager.AppSettings[key];
            if (string.IsNullOrEmpty(val))
                return 0;
            if (Regex.IsMatch(val, @"^[+-]?\d*[.]?\d*$"))
                return int.Parse(val);
            return 0;
        }
        #endregion

        #region 程序是否已启动
        private static bool IsProcessStart(string processName)
        {
            if (string.IsNullOrEmpty(processName))
                return false;
            processName = processName.ToLower();

            Process[] processes = Process.GetProcesses();
            if (processes == null)
                return false;
            foreach (var process in processes)
            {
                if (process != null &&
                    !string.IsNullOrEmpty(process.ProcessName) &&
                    process.ProcessName.ToLower().Contains(processName))
                    return true;
            }
            return false;
        }
        #endregion

        #region 服务是否已启动
        private static bool IsServiceStart(string serviceName)
        {
            if (string.IsNullOrEmpty(serviceName))
                return false;
            serviceName = serviceName.ToLower();

            ServiceController[] serviceControllers = ServiceController.GetServices();
            if (serviceControllers == null)
                return false;
            foreach (var controller in serviceControllers)
            {
                if (controller != null &&
                    !string.IsNullOrEmpty(controller.ServiceName) &&
                    controller.ServiceName.ToLower().Contains(serviceName) &&
                    controller.Status == ServiceControllerStatus.Running)
                    return true;
            }
            return false;
        }
        #endregion

        #region 是否满足启动条件
        private static bool IsReady()
        {
            if (services != null)
            {
                foreach (var s in services)
                {
                    bool isStart = IsServiceStart(s);
                    if (!isStart)
                        return isStart;
                }
            }
            if (processes != null)
            {
                foreach (var p in processes)
                {
                    bool isStart = IsProcessStart(p);
                    if (!isStart)
                        return isStart;
                }
            }
            return true;
        }
        #endregion

        #region 定时方法
        /// <summary>
        /// 定时方法
        /// </summary>
        /// <param name="state"></param>
        private static void Timer_Tick(object state)
        {
            if (Interlocked.Exchange(ref inTimer, 1) == 0)
            {
                tick++;
                bool isReady = IsReady();
                if (isReady)
                {
                    Console.WriteLine(READY_MSG, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), tick);
                    try
                    {

                        Process proc = new Process();
                        proc.StartInfo.FileName = path;
                        proc.Start();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(START_SUCCESS_MSG, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        Thread.Sleep(SLEEP);
                        Environment.Exit(0);
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(START_ERR_MSG, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), ex.StackTrace);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(WATING_MSG, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    }
                }
                else
                {
                    Console.WriteLine(READY_ERR_MSG, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), tick);
                    Console.WriteLine(WATING_MSG, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                }
            }
        }
        #endregion
    }
}
