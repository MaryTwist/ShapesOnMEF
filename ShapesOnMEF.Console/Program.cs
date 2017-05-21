using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using System.Linq;

using ShapesOnMEF.Contract;
using ShapesOnMEF;
using InConsoleExperiments.Common;

namespace ShapesOnMEF
{
	class MainClass
	{
		private static ShapeComposition composition;

		public static void Main(string[] args)
		{
			composition = new ShapeComposition();

			composition.Shapes.Map(s =>
			{
				Console.WriteLine("----------( {0} )----------", s.Value.GetType());
				GetProperties(s.Value)
					.Map(p => Console.WriteLine("{0} = {1}", p.Key, p.Value));
			});
		}

		private static Dictionary<string, object> GetProperties(IShape shape)
		{
			var result = new Dictionary<string, object>();

			shape.GetType()
			     .GetProperties()
			     .Where(p => p.GetCustomAttributes(typeof(DataMemberAttribute), false)
						      .OfType<DataMemberAttribute>()
						      .Any())
			     .Map(m => result.Add(m.Name, m.GetValue(shape)));

			return result;
		}
	}
}
