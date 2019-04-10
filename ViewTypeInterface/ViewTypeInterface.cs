using AppInterfaces;
using Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewTypeInterface
{
    public interface IViewType
    {
        void StartView(AssemblyData assemblyData, ILogger logger, ISerializer serialize);
    }
}
