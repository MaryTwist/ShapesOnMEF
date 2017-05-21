using System;
using System.Runtime.Serialization;
using System.ComponentModel.Composition;
using ShapesOnMEF.Contract;

namespace ShapesOnMEF
{
	[DataContract]
	[Export(typeof(IShape))]
	public class LineShape : ShapeBase
	{
		[DataMember]
		public int X2 { get; set; }

		[DataMember]
		public int Y2 { get; set; }

		public LineShape()
		{
		}

		public override void Expose()
		{
			Console.WriteLine("Line[{0}](X1:{1}, Y1:{2}, X2:{3}, Y2:{4})",
			                  Name, X, Y, X2, Y2);
		}
	}
}
