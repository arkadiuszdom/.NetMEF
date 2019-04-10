using Reflection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ViewModel
{
    public class AssemblyViewModel : INotifyPropertyChanged
    {
        public AssemblyViewModel() {
        }
        public AssemblyViewModel(AssemblyData assemblyData)
        {
            _assemblyData = assemblyData;
            _assemblyName = assemblyData.Name;

            _namespaces = new ObservableCollection<NamespaceViewModel>();
            CreateNamespaces();
        }

        private AssemblyData _assemblyData;
        private string _assemblyName;
        private ObservableCollection<NamespaceViewModel> _namespaces;
        private NamespaceViewModel _currentNamespace;

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string AssemblyToString()
        {
            string result = null;

            result += String.Format("-->{0}{1}", this._assemblyName, Environment.NewLine);

            foreach (NamespaceViewModel nd in this._namespaces)
            {
                result += String.Format("---->{0}{1}", nd.NamespaceName, Environment.NewLine);

                foreach (TypeViewModel td in nd.TypesVM)
                {
                    result += String.Format("------>{0}{1}", td.TypeName, Environment.NewLine);
                    
                    foreach (MethodViewModel methodData in td.Methods)
                    {
                        int paramtersNumber = methodData.Parameters.Count();
                        string paramtersStringJoined = "";
                        if (paramtersNumber!=0)
                        {
                            String[] paramtersStrings = new String[paramtersNumber];
                            int counter = 0;
                            foreach (ParameterViewModel paramterData in methodData.Parameters)
                            {
                                paramtersStrings[counter]= String.Format("{0} {1}", paramterData.ParameterTypeName, paramterData.ParameterName);
                                counter++;
                            }
                            paramtersStringJoined = string.Join(", ", paramtersStrings);
                        }
                        result += String.Format("-------->{0} ( {1} ) : {2}{3}", methodData.MethodName, paramtersStringJoined, methodData.ReturnTypeName, Environment.NewLine);

                    }

                    foreach (PropertyViewModel propertyData in td.Properties)
                    {
                        result += String.Format("-------->{0}{1}", propertyData.PropertyName, Environment.NewLine);
                    }
                }
            }
            return result;
        }

        public AssemblyData getAssembly()
        {
            return _assemblyData;
        }
        // -----PROPERTIES-----
        [XmlIgnore]
        public NamespaceViewModel CurrentNamespace
        {
            get { return _currentNamespace; }
            set
            {
                _currentNamespace = value;
                OnPropertyChanged("CurrentNamespace");
            }
        }

        [DataMember]
        public string AssemblyName
        {
            get { return _assemblyName; }
            set { _assemblyName = value; }
        }

        [DataMember()]
        public ObservableCollection<NamespaceViewModel> Namespaces
        {
            get { return _namespaces; }
            set
            {
                if (value != null)
                    _namespaces = new ObservableCollection<NamespaceViewModel>(value);
                else
                    _namespaces = new ObservableCollection<NamespaceViewModel>();
            }
        }

        // -----METHODS-----
        private void CreateNamespaces()
        {
            foreach (NamespaceData ns in _assemblyData.Namespaces)
            {
                NamespaceViewModel nvm = new NamespaceViewModel();
                nvm.NamespaceData = ns;
                nvm.NamespaceName = ns.Name;
                nvm.CreateTypes();
                _namespaces.Add(nvm);
            }
        }
    }
}
