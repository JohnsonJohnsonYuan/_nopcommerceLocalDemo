﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;

using System.Text.RegularExpressions;
using System.Collections;

namespace Nop.Core.Tests
{// Create a class having six properties.
    public class PropertyClass
    {
        public String Property1
        {
            get { return "hello"; }
        }
        public static String PropertyStatic
        {
            get { return "HelloI"; }
        }
        public String Property2
        {
            get { return "hello"; }
        }

        protected String Property3
        {
            get { return "hello"; }
        }

        private Int32 Property4
        {
            get { return 32; }
        }

        internal String Property5
        {
            get { return "value"; }
        }

        protected internal String Property6
        {
            get { return "value"; }
        }
    }

    class BaseEntity1 : BaseEntity
    {
    }
    class BaseEntity2 : BaseEntity
    {
    }// Define a class with a property.
    public class TestClass
    {
        private string caption = "A Default caption";
        public string Caption
        {
            get { return caption; }
            set
            {
                if (caption != value)
                {
                    caption = value;
                }
            }
        }
    }

    public interface IFinder
    { void Log(string value); }

    public class AppFinder : IFinder
    { public void Log(string value) { Console.WriteLine(value); } }
    public class AppFinder2 : IFinder
    { public void Log(string value) { Console.WriteLine(value); } }

    public interface IRepo<T>
    { void Init(); }

    public class EfRepo<T> : IRepo<T>
    { public void Init() { Console.WriteLine("Ef repo"); } }

    class Program
    {
        public static int GenerateRandomInteger(int min = 0, int max = int.MaxValue)
        {
            var randomNumberBuffer = new byte[10];
            new RNGCryptoServiceProvider().GetBytes(randomNumberBuffer);
            return new Random(BitConverter.ToInt32(randomNumberBuffer, 0)).Next(min, max);
        }

        public static void Demo1(int x)
        {
            Console.WriteLine(x) ;
        }

        public static void Demo1<T>(int x)
        {
            Console.WriteLine("Generic");
            Console.WriteLine(x);
        }
        public static void mymethod(
              int int1m, out string str2m, ref string str3m)
        {
            str2m = "in mymethod";
        }

        public class DemoValue
        {
            public int MyProperty { get; set; }

            public override string ToString()
            {
                return MyProperty.ToString();
            }
        }

        public class DemoClass
        {
            private DemoValue _value;

            public DemoClass(DemoValue value)
            {
                this._value = value;
            }

            public DemoValue MyProperty { get { return _value; } set { _value = value; } }
        }

        static void Main(string[] args)
        {
            Hashtable ht = new Hashtable();
            BaseEntity search111 = new BaseEntity() { Id = 111 };
            BaseEntity search222 = new BaseEntity() { Id = 222 };

            Console.WriteLine(search111.GetHashCode());
            Console.WriteLine(search222.GetHashCode());
            ht.Add(search111, 100);
            ht.Add(search222, 200);


            if (ht.ContainsKey(new BaseEntity() { Id = 111 }))
            {
                Console.WriteLine("contains");
            }
            else
            {
                Console.WriteLine("not contains");
            }
            return;
            Console.WriteLine(System.Web.Mvc.HttpVerbs.Get);
            return;
            string path_ = @"E:\Source\Repos\nopCommerce_3.80_Beta_Source\Libraries\Nop.Core\Html\1.txt";

            File.WriteAllText(path_, "1231\n123\n12\r1123" + Environment.NewLine + "helo\r\n");
            string value_ = File.ReadAllText(path_);

            return;

            string text = @"<b>Hellosdf>>>>sdfsdf</b>123";
            var result = Regex.Replace(text, "(<[^>]*>)([^<]*)", "$2");
            Console.WriteLine("result: " + result);

            foreach (Match item in Regex.Matches(text, "(<[^>]*>)([^<]*)"))
            {
                Console.WriteLine("group1: " + item.Groups[1].Value);
                Console.WriteLine("group2: " + item.Groups[2].Value);
            }
            return;

            DemoValue value = new DemoValue();
            value.MyProperty = 123;

            DemoClass classV = new DemoClass(value);
            Console.WriteLine(classV.MyProperty);


            return;

            //Console.WriteLine("\nReflection.Parameterinfo");
            //Type Mytype = Type.GetType("Nop.Core.Tests.Program");
            //Console.WriteLine(Mytype);

            ////Get and display the method.
            //MethodBase Mymethodbase = Mytype.GetMethod("mymethod");
            //Console.Write("\nMymethodbase = " + Mymethodbase);

            ////Get the ParameterInfo array.
            //ParameterInfo[] Myarray = Mymethodbase.GetParameters();

            ////Get and display the ParameterInfo of each parameter.
            //foreach (ParameterInfo Myparam in Myarray)
            //{
            //    Console.Write("\nFor param eter # " + Myparam.Position
            //       + ", the ParameterType is - " + Myparam.ParameterType + ", " + Myparam.GetType());
            //}
            //return;

            //Demo1(22);
            //Demo1<string>(22);
            //Console.WriteLine();
            //return;
            string an2 = @"C:\Users\Administrator\Source\Repos\_nopcommerceLocalDemo\Tests\Nop.Core.Tests\bin\Debug\Nop.Core.dll";
            string an1 = @"E:\Source\Repos\nopCommerce_3.80_Beta_Source\Libraries\Nop.Core\bin\Debug\Autofac.dll";
            Console.WriteLine(AppDomain.CurrentDomain.GetAssemblies().Count());
            AssemblyName an = AssemblyName.GetAssemblyName(an1);
            Assembly.Load(an);
            Console.WriteLine(AppDomain.CurrentDomain.GetAssemblies().Count());
            Console.WriteLine(an);
            Console.WriteLine(an.FullName);
            return;
            foreach (var item in AppDomain.CurrentDomain.GetAssemblies())
            {
                Console.WriteLine(item.FullName);
            }
            Console.WriteLine("================");
            System.Web.Compilation.BuildManager.AddReferencedAssembly(Assembly.Load(an));


            Console.WriteLine(Guid.NewGuid().ToString("N"));
            Console.WriteLine(Guid.NewGuid().ToString());
            var path = AppDomain.CurrentDomain.BaseDirectory + ("\\global.asax");
            var path2 = AppDomain.CurrentDomain.BaseDirectory + ("\\global2.asax");

            File.Copy(path, path2, true);

            var shadowCopiedPlug = new FileInfo(path);
            Console.WriteLine(shadowCopiedPlug.CreationTime);
            shadowCopiedPlug = new FileInfo(path2);
            Console.WriteLine(shadowCopiedPlug.CreationTime);

            return;

            foreach (var item in Environment.NewLine)
            {
                Console.WriteLine((int)item);
            }

            Nop.Core.Data.DataSettings setting = new Data.DataSettings();
            Console.WriteLine(setting.DataProvider == null);
            return;
            long x = 123123;
            Console.WriteLine((x is int) ? "is int" : "not int");

            Console.WriteLine(System.ComponentModel.TypeDescriptor.GetConverter(typeof(int)));
            string[] arr2 = new string[1];
            Console.WriteLine(arr2.Any());
            return;

            TestClass t = new TestClass();

            // Get the type and PropertyInfo.
            Type myType = t.GetType();
            PropertyInfo pinfo = myType.GetProperty("Caption");

            pinfo.SetValue(t, "HEllo WORK", new object[1]);
            Console.WriteLine(pinfo.GetValue(t));
            return;

            string str = "\"Helo&quot;";
            using (var sw = new StringWriter())
            using (var xwr = new XmlTextWriter(sw))
            {
                xwr.WriteString(str);
                Console.WriteLine(sw.ToString());
            }

            return;
             

            BaseEntity1 be1 = new BaseEntity1();
            BaseEntity1 be11 = new BaseEntity1();
            Console.WriteLine(be1.GetHashCode());
            Console.WriteLine(be11.GetHashCode());
            return;
            BaseEntity2 be2 = new BaseEntity2();
            Dictionary<BaseEntity1, int> dic = new Dictionary<BaseEntity1, int>();
            dic.Add(be1, 1);
            dic.Add(be11, 2);
        }
    }
}
