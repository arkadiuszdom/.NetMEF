﻿using AppInterfaces;
using Reflection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WindowApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public ILogger logger;
        public ISerializer serializer;
        public AssemblyData assemblyData;
    }
}