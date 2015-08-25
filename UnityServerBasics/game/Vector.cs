using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityServerBasics.game
{
	class Vector
	{
		private double X { get; set; }
		private double Y { get; set; }
		private double Z { get; set; }

		public Vector(double x, double y, double z)
		{
			X = x;
			Y = y;
			Z = z;
		}

		/// <summary>
		/// Add the two vectors together.
		/// </summary>
		/// <param name="_left"></param>
		/// <param name="_right"></param>
		/// <returns></returns>
		public static Vector operator +(Vector _left, Vector _right)
		{
			return new Vector(_left.X + _right.X, _left.Y + _right.Y, _left.Z + _left.Z);
		}
	}
}
