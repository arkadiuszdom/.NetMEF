using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppInterfaces;
using Reflection;
using System.Collections.ObjectModel;
using ViewModel;
using System.ComponentModel.Composition;
using ViewTypeInterface;

namespace ConsoleApp
{
    [Export(typeof(IViewType))]
    class Program : IViewType
    {
        static string serializationPath = "../../../assemblyXml.xml";
        private Reflector _reflector;
        private ObjectBrowser _browser;
        public void StartView(AssemblyData assemblyData, ILogger logger, ISerializer serialize)
        {
            this.RunConsoleApp(assemblyData, logger, serialize);
        }

        private void RunConsoleApp(AssemblyData assemblyData, ILogger logger, ISerializer serializer)
        {
            _reflector = new Reflector();

            logger.Log("");

            logger.Log("Using Console mode.");

            AsyncSerializer caller = new AsyncSerializer(serializer.Serialize);

            AssemblyViewModel assemblyVM = new AssemblyViewModel(assemblyData);
            Console.WriteLine(assemblyVM.AssemblyToString());
            _browser = new ObjectBrowser(logger, assemblyVM);
            


            Console.WriteLine("");
            Console.WriteLine("1 - serializacja");
            Console.WriteLine("2 - deserializacja");
            Console.WriteLine("3 - otworz");
            int choice = Int32.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        caller.BeginInvoke(_browser, serializationPath, logger, null, null);
                        break;
                    case 2:
                        _browser = serializer.Deserialize<ObjectBrowser>(serializationPath, logger);
                        Console.WriteLine(_browser.GetLatestAssemblyViewModel().AssemblyToString());
                        break;
                    case 3:
                        string path = Console.ReadLine();
                        _reflector.Reflect(path, logger);
                        _browser.AddAssemblyViewModel(logger, new AssemblyViewModel(_reflector._AssemblyModel));
                        Console.WriteLine(_browser.GetLatestAssemblyViewModel().AssemblyToString());
                        break;
                    default:
                        break;
                }


            Console.Read();
        }
        /*
        private static Reflector Reflect(ILogger log, string path)
        {
            Reflector reflector = new Reflector();
            reflector.Reflect(path, log);
            Console.WriteLine(reflector.AssemblyToString());
            return reflector;
        }*/


        private delegate void AsyncSerializer(ObservableCollection<AssemblyViewModel> assembly, string name, ILogger log);
    }
}
