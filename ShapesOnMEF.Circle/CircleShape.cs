using System;
using System.Runtime.Serialization;
using System.ComponentModel.Composition;
using ShapesOnMEF.Contract;

namespace ShapesOnMEF
{
	[DataContract]
	[Export(typeof(IShape))]
	public class CircleShape : ShapeBase
	{
		[DataMember]
		public int R { get; set; }

		public CircleShape()
		{
		}

		public override void Expose()
		{
			Console.WriteLine("Circle[{0}](X:{1}, Y:{2}, R:{3})", Name, X, Y, R);
		}
	}
}
