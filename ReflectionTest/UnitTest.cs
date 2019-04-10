using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppInterfaces;
using System.Reflection;
using Reflection;
using System.Collections.Generic;
using System.Collections;
using FileLoggerProject;

namespace ReflectionTest
{
    [TestClass]
    public class ReflectionTests
    {
        private static string dllTestPath = "../../../TestLib.dll";

        ILogger log = new FileLogger();

        [TestMethod]
        public void TestAssemblyDataName()
        {
            string expected = "TestLib.dll";
            Assembly assembly = Assembly.LoadFrom(dllTestPath);
            AssemblyData actual = new AssemblyData(assembly, log);
            Assert.AreEqual(expected, actual.Name);
        }
        [TestMethod]
        public void TestAssemblyDataNamespaces()
        {
            string expected = "Reflection";
            Assembly assembly = Assembly.LoadFrom(dllTestPath);
            AssemblyData m_AssemblyModel = new AssemblyData(assembly, log);
            IEnumerable<NamespaceData> m_Meta = m_AssemblyModel.Namespaces;
            IEnumerator enumerator = m_Meta.GetEnumerator();
            enumerator.MoveNext();
            NamespaceData actual = (NamespaceData)enumerator.Current;
            Assert.AreEqual(expected, actual.Name);
        }
        [TestMethod]
        public void TestAssemblyDataTypes()
        {
            string expected = "AssemblyData";
            Assembly assembly = Assembly.LoadFrom(dllTestPath);
            AssemblyData m_AssemblyModel = new AssemblyData(assembly, log);
            IEnumerable<NamespaceData> m_Meta = m_AssemblyModel.Namespaces;
            IEnumerator namespaces = m_Meta.GetEnumerator();
            namespaces.MoveNext();
            NamespaceData firstNamespace = (NamespaceData)namespaces.Current;
            IEnumerable<TypeData> m_Meta2 = firstNamespace.Types;
            IEnumerator types = m_Meta2.GetEnumerator();
            types.MoveNext();
            TypeData actual = (TypeData)types.Current;
            Assert.AreEqual(expected, actual.Name);
        }
        [TestMethod]
        public void TestAssemblyDataMethods()
        {
            string expected = "get_Name";
            Assembly assembly = Assembly.LoadFrom(dllTestPath);
            AssemblyData m_AssemblyModel = new AssemblyData(assembly, log);
            IEnumerable<NamespaceData> m_Meta = m_AssemblyModel.Namespaces;
            IEnumerator namespaces = m_Meta.GetEnumerator();
            namespaces.MoveNext();
            NamespaceData firstNamespace = (NamespaceData)namespaces.Current;
            IEnumerable<TypeData> m_Meta2 = firstNamespace.Types;
            IEnumerator types = m_Meta2.GetEnumerator();
            types.MoveNext();
            TypeData firstType = (TypeData)types.Current;
            IEnumerable<MethodData> methodsEnumberable = firstType.Methods;
            IEnumerator methods = methodsEnumberable.GetEnumerator();
            methods.MoveNext();
            MethodData actual = (MethodData)methods.Current;
            Assert.AreEqual(expected, actual.Name);
        }
        [TestMethod]
        public void TestAssemblyDataProperties()
        {
            string expected = "Name";
            Assembly assembly = Assembly.LoadFrom(dllTestPath);
            AssemblyData m_AssemblyModel = new AssemblyData(assembly, log);
            IEnumerable<NamespaceData> m_Meta = m_AssemblyModel.Namespaces;
            IEnumerator namespaces = m_Meta.GetEnumerator();
            namespaces.MoveNext();
            NamespaceData firstNamespace = (NamespaceData)namespaces.Current;
            IEnumerable<TypeData> m_Meta2 = firstNamespace.Types;
            IEnumerator types = m_Meta2.GetEnumerator();
            types.MoveNext();
            TypeData firstType = (TypeData)types.Current;
            IEnumerable<PropertyData> propertiesEnumberable = firstType.Properties;
            IEnumerator properties = propertiesEnumberable.GetEnumerator();
            properties.MoveNext();
            PropertyData actual = (PropertyData)properties.Current;
            Assert.AreEqual(expected, actual.Name);
        }

    }
}

