using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Runtime.Serialization;
using ShapesOnMEF.Contract;

namespace ShapesOnMEF
{
	public class ShapeBinder
	{
		
		void Set(string name, object value)
		{

		}

		object Get(string name)
		{

		}
	}

	public class ShapeComposition : SerializationBinder
	{
		private CompositionContainer _container;
		private AggregateCatalog _catalog;

		[ImportMany]
		public Lazy<IShape, Dictionary<string, object>>[] Shapes { get; set; }

		public ShapeComposition()
		{
			_catalog = new AggregateCatalog();

			_catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
			_catalog.Catalogs.Add(new DirectoryCatalog(
				Path.Combine(
					Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
					"Components"),
				"*.dll"));

			_container = new CompositionContainer(_catalog);
			_container.ComposeParts(this);
		}

		public void Save(string path, IShape shape)
		{
			using (var f = File.OpenWrite(path))
			{
				var s = new NetDataContractSerializer();
				s.WriteObject(f, shape);
			}
		}

		public IShape Load(string path)
		{
			using (var f = File.OpenRead(path))
			{
				var s = new NetDataContractSerializer();
				s.Binder = this;
				return s.ReadObject(f) as IShape;
			}
		}

		public override Type BindToType(string assemblyName, string typeName)
		{
			Type typeToDeserialize = null;

			try
			{
				string ToAssemblyName = assemblyName.Split(',')[0];
				List<Assembly> Assemblies = new List<Assembly>();

				Assemblies.AddRange(AppDomain.CurrentDomain.GetAssemblies());

				foreach (var s in Shapes)
				{
					Assemblies.Add(s.Value.GetType().Assembly);
				}

				foreach (Assembly asm in Assemblies)
				{
					if (asm.FullName.Split(',')[0] == ToAssemblyName)
					{
						typeToDeserialize = asm.GetType(typeName);
						break;
					}
				}
			}
			catch (Exception exception)
			{
				throw exception;
			}

			return typeToDeserialize;
		}
	}
}
