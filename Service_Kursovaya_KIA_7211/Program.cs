﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Service_Kursovaya_KIA_7211.Properties;

namespace Service_Kursovaya_KIA_7211
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new Protection_service()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
