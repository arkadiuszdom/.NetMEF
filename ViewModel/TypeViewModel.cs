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
    public class TypeViewModel : INotifyPropertyChanged
    {
        public TypeViewModel()
        {
            _methodsVM = new ObservableCollection<MethodViewModel>();
            _constructorsVM = new ObservableCollection<MethodViewModel>();
            _propertiesVM = new ObservableCollection<PropertyViewModel>();
        }

        private string _typeName;
        private string _baseTypeName;
        private TypeData _typeData;
        private ObservableCollection<MethodViewModel> _methodsVM;
        private ObservableCollection<MethodViewModel> _constructorsVM;
        private ObservableCollection<PropertyViewModel> _propertiesVM;
        private MethodViewModel _currentMethod;
        private PropertyViewModel _currentProperty;

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // -----PROPERTIES-----
        [XmlIgnore]
        public MethodViewModel CurrentMethod
        {
            get { return _currentMethod; }
            set
            {
                _currentMethod = value;
                OnPropertyChanged("CurrentMethod");
            }
        }
        [XmlIgnore]
        public PropertyViewModel CurrentProperty
        {
            get { return _currentProperty; }
            set
            {
                _currentProperty = value;
                OnPropertyChanged("CurrentProperty");
            }
        }
        [XmlIgnore]
        public TypeData TypeData
        {
            get { return _typeData; }
            set { _typeData = value; }
        }
        [DataMember]
        public string TypeName
        {
            get { return _typeName; }
            set { _typeName = value; }
        }
        [DataMember]
        public string BaseTypeName
        {
            get { return _baseTypeName; }
            set { _baseTypeName = value; }
        }
        [DataMember()]
        public ObservableCollection<MethodViewModel> Methods
        {
            get { return _methodsVM; }
            set
            {
                if (value != null)
                    _methodsVM = new ObservableCollection<MethodViewModel>(value);
                else
                    _methodsVM = new ObservableCollection<MethodViewModel>();
            }
        }
        [DataMember()]
        public ObservableCollection<MethodViewModel> Constructors
        {
            get { return _constructorsVM; }
            set
            {
                if (value != null)
                    _constructorsVM = new ObservableCollection<MethodViewModel>(value);
                else
                    _constructorsVM = new ObservableCollection<MethodViewModel>();
            }
        }
        [DataMember()]
        public ObservableCollection<PropertyViewModel> Properties
        {
            get { return _propertiesVM; }
            set
            {
                if (value != null)
                    _propertiesVM = new ObservableCollection<PropertyViewModel>(value);
                else
                    _propertiesVM = new ObservableCollection<PropertyViewModel>();
            }
        }

        // -----METHODS-----
        public void CreateProperties()
        {
            foreach (PropertyData pm in _typeData.Properties)
            {
                _propertiesVM.Add(new PropertyViewModel
                {
                    PropertyData = pm,
                    PropertyName = pm.Name,
                    PropertyTypeName = pm.TypeData.Name
                });
            }
        }

        public void CreateMethods()
        {
            foreach (MethodData mm in _typeData.Methods)
            {
                MethodViewModel mvm = new MethodViewModel();
                mvm.MethodData = mm;
                mvm.MethodName = mm.Name;
                mvm.CreateReturnType();
                mvm.CreateParameters();
                _methodsVM.Add(mvm);
            }
            foreach (MethodData mm in _typeData.Constructors)
            {
                MethodViewModel mvm = new MethodViewModel();
                mvm.MethodData = mm;
                mvm.MethodName = mm.Name;
                mvm.CreateReturnType();
                mvm.CreateParameters();
                _methodsVM.Add(mvm);
            }

        }
    }
}
