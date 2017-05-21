using System;
using System.Runtime.Serialization;
using System.ComponentModel.Composition;
using ShapesOnMEF.Contract;

namespace ShapesOnMEF
{
	[DataContract]
	[Export(typeof(IShape))]
	public class PointShape : ShapeBase
	{
		public PointShape()
		{
		}

		public override void Expose()
		{
			Console.WriteLine("Point[{0}](X:{1}, Y:{2})", Name, X, Y);
		}
	}
}
