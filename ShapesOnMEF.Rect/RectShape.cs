using System;
using System.Runtime.Serialization;
using System.ComponentModel.Composition;
using ShapesOnMEF.Contract;

namespace ShapesOnMEF
{
	[DataContract]
	[Export(typeof(IShape))]
	public class RectShape : ShapeBase
	{
		[DataMember]
		public int H { get; set; }

		[DataMember]
		public int W { get; set; }

		public RectShape()
		{
		}

		public override void Expose()
		{
			Console.WriteLine("Rect[{0}](X:{1}, Y:{2}, H:{3}, W:{4})", Name, X, Y, H, W);
		}
	}
}
