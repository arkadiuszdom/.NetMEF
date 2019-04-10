using AppInterfaces;
using Microsoft.Win32;
using Reflection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml.Serialization;
using ViewModel;

namespace WindowApp
{
    public class BrowserView : INotifyPropertyChanged
    {
        private ILogger log;
        private Reflector _reflector;
        private AssemblyViewModel _currentAssembly;
        private ObservableCollection<AssemblyViewModel> _assemblies;
        private AssemblyViewModel _assembly;
        private string dllPath = "Reflection.dll";

        public ICommand SerializeCommand { get; set; }
        public ICommand DeserializeCommand { get; set; }
        public ICommand OpenFileCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public BrowserView()
        {
            log = (Application.Current as WindowApp.App).logger;
            log.Log("Using Window mode.");

            AssemblyViewModel assemblyVM = new AssemblyViewModel((Application.Current as WindowApp.App).assemblyData);

            _assemblies = new ObservableCollection<AssemblyViewModel>
            {
                assemblyVM
            };
            _assembly = new AssemblyViewModel();
            _assembly = assemblyVM;

            _reflector = new Reflector();

            SerializeCommand = new RelayCommand(CommandParameter => Serialize());
            DeserializeCommand = new RelayCommand(CommandParameter => Deserialize());
            OpenFileCommand = new RelayCommand(CommandParameter => OpenFile());
        }

        // -----PROPERTIES-----
        [XmlIgnore]
        public AssemblyViewModel CurrentAssembly
        {
            get { return _currentAssembly; }
            set
            {
                _currentAssembly = value;
                OnPropertyChanged("CurrentAssembly");
            }
        }
        [DataMember()]
        public ObservableCollection<AssemblyViewModel> Assemblies
        {
            get { return _assemblies; }
            set
            {
                if (value != null)
                    _assemblies = new ObservableCollection<AssemblyViewModel>(value);
                else
                    _assemblies = new ObservableCollection<AssemblyViewModel>();
            }
        }

        private void OpenFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Dynamic Library File(*.dll)| *.dll|"
                                   + "Executable File(*.exe)| *.exe|"
                                   + "XML File(*.xml)| *.xml",
                RestoreDirectory = true
            };
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName.Length == 0)
            {
                MessageBox.Show("No files selected");
            }
            else
            {
                _reflector.Reflect(openFileDialog.FileName, log);
                AssemblyViewModel assemblyVM = new AssemblyViewModel(_reflector._AssemblyModel);
                _assemblies.Add(assemblyVM);
            }
        }

        private void Serialize()
        {
            ISerializer serializer = null;
            string fileName = "assembly";
            string defaultExt = "";
            string filter = "";

            serializer = (Application.Current as WindowApp.App).serializer; 
            defaultExt = ".xml";
            filter = "Xml files (.xml)|*.xml";

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                FileName = fileName,
                DefaultExt = defaultExt,
                Filter = filter
            };

            bool? result = saveFileDialog.ShowDialog();
            if (result == true)
                fileName = saveFileDialog.FileName;

            serializer.Serialize(this._assemblies, fileName, log);

            string messageBoxText = null;

            if (File.Exists(fileName))
                messageBoxText = "File created";
            else
                messageBoxText = "Could not create file.";

            MessageBox.Show(messageBoxText);
        }

        private void Deserialize()
        {
            ISerializer serializer = null;
            string fileName = "";
            string defaultExt = "";
            string filter = "";

            serializer = (Application.Current as WindowApp.App).serializer;
            defaultExt = ".xml";
            filter = "Xml files (.xml)|*.xml";

            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog
            {
                DefaultExt = defaultExt,
                Filter = filter
            };

            bool? result = openFileDialog.ShowDialog();
            if (result == true)
                fileName = openFileDialog.FileName;

            ObservableCollection<AssemblyViewModel> deserializedAssemblies = serializer.Deserialize<ObservableCollection<AssemblyViewModel>>(fileName, log);

            foreach (AssemblyViewModel assembly in deserializedAssemblies)
                _assemblies.Add(assembly);

            MessageBox.Show("Deserialized");
        }
    }
}
