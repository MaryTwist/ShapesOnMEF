using System;
using System.Runtime.Serialization;

namespace ShapesOnMEF.Contract
{
	[DataContract]
	public abstract class ShapeBase : IShape
	{
		[DataMember]
		public string Name { get; set; }

		[DataMember]
		public string Description { get; set; }

		[DataMember]
		public int X { get; set; }

		[DataMember]
		public int Y { get; set; }

		[DataMember]
		public int Color1 { get; set; }

		[DataMember]
		public int Color2 { get; set; }

		public abstract void Expose();
	}
}
