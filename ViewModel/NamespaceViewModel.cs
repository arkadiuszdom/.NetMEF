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
    public class NamespaceViewModel : INotifyPropertyChanged
    {
        public NamespaceViewModel()
        {
            _typesVM = new ObservableCollection<TypeViewModel>();
        }

        private string _namespaceName;
        private NamespaceData _namespaceData;
        private ObservableCollection<TypeViewModel> _typesVM;
        private TypeViewModel _currentType;

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // -----PROPERTIES-----
        [XmlIgnore]
        public TypeViewModel CurrentType
        {
            get { return _currentType; }
            set
            {
                _currentType = value;
                OnPropertyChanged("CurrentType");
            }
        }
        [XmlIgnore]
        public NamespaceData NamespaceData
        {
            get { return _namespaceData; }
            set { _namespaceData = value; }
        }
        [DataMember]
        public string NamespaceName
        {
            get { return _namespaceName; }
            set { _namespaceName = value; }
        }
        [DataMember()]
        public ObservableCollection<TypeViewModel> TypesVM
        {
            get { return _typesVM; }
            set
            {
                if (value != null)
                    _typesVM = new ObservableCollection<TypeViewModel>(value);
                else
                    _typesVM = new ObservableCollection<TypeViewModel>();
            }
        }

        // -----METHODS-----
        public void CreateTypes()
        {
            foreach (TypeData t in _namespaceData.Types)
            {
                TypeViewModel tvm = new TypeViewModel();
                tvm.TypeData = t;
                tvm.TypeName = t.Name;
                tvm.BaseTypeName = t.BaseType.ToString();
                tvm.CreateMethods();
                tvm.CreateProperties();
                _typesVM.Add(tvm);
            }
        }
    }
}
