using Reflection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ViewModel
{
    public class MethodViewModel
    {
        public MethodViewModel()
        {
            _returnTypeName = null;
            _parametersVM = new ObservableCollection<ParameterViewModel>();
        }

        private string _methodName;
        private MethodData _methodData;
        private ObservableCollection<ParameterViewModel> _parametersVM;
        private string _returnTypeName;

        // -----PROPERTIES-----
        [XmlIgnore]
        public MethodData MethodData
        {
            get { return _methodData; }
            set { _methodData = value; }
        }
        [DataMember]
        public string MethodName
        {
            get { return _methodName; }
            set { _methodName = value; }
        }
        [DataMember]
        public string ReturnTypeName
        {
            get { return _returnTypeName; }
            set { _returnTypeName = value; }
        }
        [DataMember()]
        public ObservableCollection<ParameterViewModel> Parameters
        {
            get { return _parametersVM; }
            set
            {
                if (value != null)
                    _parametersVM = new ObservableCollection<ParameterViewModel>(value);
                else
                    _parametersVM = new ObservableCollection<ParameterViewModel>();
            }
        }

        // -----METHODS-----
        public void CreateReturnType()
        {
            if(_methodData.ReturnType != null)
            {
                _returnTypeName = _methodData.ReturnType.Name.ToLower();
            }
            else
            {
                _returnTypeName = "void";
            }
        }

        public void CreateParameters()
        {
            foreach (ParameterData pm in _methodData.Parameters)
            {
                _parametersVM.Add(new ParameterViewModel
                {
                    ParameterData = pm,
                    ParameterName = pm.Name,
                    ParameterTypeName = pm.TypeData.Name
                });
            }
        }
    }
}
