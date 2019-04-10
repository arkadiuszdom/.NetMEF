using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using AppInterfaces;
using System.Reflection;
using Reflection;
using ViewTypeInterface;

namespace AppManager
{
    class Program
    {
        private CompositionContainer _container;

        [Import(typeof(IViewType))]
        public IViewType viewType;

        [Import(typeof(ILogger))]
        public ILogger logger;

        [Import(typeof(ISerializer))]
        public ISerializer serializer;

        public AssemblyData assemblyData;

        private String viewTypeName;
        private String loggerName;
        private String serializerName;
        private String viewTypeExtension;

        private void GetNames(char modeRepository, char modeView)
        {
            if(modeView == 'w')
            {
                this.viewTypeName = "../../../WindowApp/bin/Debug";
                this.viewTypeExtension = "exe";
            }
            else if (modeView == 'c')
            {
                this.viewTypeName = "../../../ConsoleApp/bin/Debug";
                this.viewTypeExtension = "dll";
            }
            else
            {
                throw new System.ArgumentException("Wrong input");
            }
            if (modeRepository == 'd')
            {
                this.loggerName = "../../../DBLoggerProject/bin/Debug";
                this.serializerName = "../../../DBSerializer/bin/Debug";
            }
            else if (modeRepository == 'f')
            {
                this.loggerName = "../../../FileLoggerProject/bin/Debug";
                this.serializerName = "../../../XMLSerializerProject/bin/Debug";
            }
            else
            {
                throw new System.ArgumentException("Wrong input");
            }
        }
        private Program()
        {
            Console.WriteLine("Press d to run DatabaseRepository or f to run FileRepository");
            char modeRepository = Char.Parse(Console.ReadLine());
            Console.WriteLine("Press w to run WindowMode or c to run ConsoleMode");
            char modeView = Char.Parse(Console.ReadLine());
            GetNames(modeRepository, modeView);

            var catalog = new AggregateCatalog();
            

            catalog.Catalogs.Add(new DirectoryCatalog(this.viewTypeName, "*."+ this.viewTypeExtension));
            catalog.Catalogs.Add(new DirectoryCatalog(this.loggerName, "*.dll"));
            catalog.Catalogs.Add(new DirectoryCatalog(this.serializerName, "*.dll"));
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));

            _container = new CompositionContainer(catalog);

            try
            {
                this._container.ComposeParts(this);
            }
            catch (CompositionException compositionException)
            {
                Console.WriteLine(compositionException.ToString());
            }
            string pathToDll = "../../../Reflection/bin/Debug/Reflection.dll";
            Reflector reflector = new Reflector();
            reflector.Reflect(pathToDll, this.logger);
            this.assemblyData = reflector._AssemblyModel;

        }

        [STAThread]
        static void Main(string[] args)
        {
            Program application = new Program();
            application.viewType.StartView(application.assemblyData, application.logger, application.serializer);

            Console.Read();
        }
    }
}
