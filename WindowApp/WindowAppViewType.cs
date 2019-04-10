using AppInterfaces;
using Reflection;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewTypeInterface;

namespace WindowApp
{
    [Export(typeof(IViewType))]
    class WindowAppViewType : IViewType
    {
        public void StartView(AssemblyData assemblyData, ILogger logger, ISerializer serializer)
        {
            var application = new App();
            application.logger = logger;
            application.serializer = serializer;
            application.assemblyData = assemblyData;
            application.Run(new MainWindow());
        }
    }
}
