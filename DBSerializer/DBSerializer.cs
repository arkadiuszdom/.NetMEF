using AppInterfaces;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.ComponentModel.Composition;
using DBProject;
using ViewModel;
using System.Collections.ObjectModel;
using System.Data.Entity;

namespace DBSerializerProject
{
    [Export(typeof(ISerializer))]
    public class DBSerializerProject : ISerializer
    {
        public Type Deserialize<Type>(string name, ILogger log)
        {
            log.Log("Deserialize to DB...");
            var db = new TPAEntities();
            DbSet<Model> models = db.Model;
            ObservableCollection<AssemblyViewModel> assemblies = new ObservableCollection<AssemblyViewModel>();
            foreach (Model model in models)
            {
                AssemblyViewModel assembly = new AssemblyViewModel();
                ObservableCollection<NamespaceViewModel> assemblyNamespaces = new ObservableCollection<NamespaceViewModel>();
                foreach (Namespace modelNamespace in model.Namespace)
                {
                    NamespaceViewModel assemblyNamespace = new NamespaceViewModel
                    {
                        NamespaceName = modelNamespace.Name
                    };
                  //  assemblyNamespaces.Add()
                }
                assembly.Namespaces = assemblyNamespaces;
                assemblies.Add(assembly);
            }
            return default(Type);           
        }

        public void Serialize<Type>(Type type, string name, ILogger log)
        {
            log.Log("Serialize to DB...");
            ObservableCollection<AssemblyViewModel> assemblies = type as ObservableCollection<AssemblyViewModel>;

            foreach (AssemblyViewModel assembly in assemblies)
            {
                var db = new TPAEntities();
                var model = new Model { Name = assembly.AssemblyName };
                db.Model.Add(model);
                db.SaveChanges();

                string assemblyName = assembly.AssemblyName;

                foreach (NamespaceViewModel mspaces in assembly.Namespaces)
                {
                    var serializedNamespace = new Namespace { Model = model, Name = mspaces.NamespaceName };
                    db.Namespace.Add(serializedNamespace);
                    db.SaveChanges();

                    foreach (TypeViewModel types in mspaces.TypesVM)
                    {
                        var astype = new DBProject.Type { Namespace = serializedNamespace, Name = types.TypeName };
                        db.Type.Add(astype);
                        db.SaveChanges();

                        foreach (MethodViewModel constructors in types.Constructors)
                        {
                            var constructor = new Constructor
                            {
                                Type = astype,
                                Name = constructors.MethodName
                            };
                            db.Constructor.Add(constructor);
                            db.SaveChanges();
                        }

                        foreach (MethodViewModel methods in types.Methods)
                        {
                            var method = new Method
                            {
                                Type = astype,
                                Name = methods.MethodName
                            };
                            db.Method.Add(method);
                            db.SaveChanges();
                            foreach (ParameterViewModel parameters in methods.Parameters)
                            {
                                var parameter = new MethodParameter
                                {
                                    Type = astype,
                                    Name = methods.MethodName
                                };
                                db.MethodParameter.Add(parameter);
                                db.SaveChanges();

                            }
                        }

                        foreach (PropertyViewModel properties in types.Properties)
                        {
                            var property = new Property
                            {
                                Type = astype,
                                Name = properties.PropertyName
                            };
                            db.Property.Add(property);
                            db.SaveChanges();
                        }
                    }
                }
            }
        }
    }
}
