using System;

namespace ShapesOnMEF.Contract
{
	public interface IShape
	{
		string Name { get; set; }
		string Description { get; set; }
		int X { get; set; }
		int Y { get; set; }
		int Color1 { get; set; }
		int Color2 { get; set; }

		void Expose();
	}
}
