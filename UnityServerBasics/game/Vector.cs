using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityServerBasics.game
{

	/// <summary>
	/// A basic Vector object.
	/// </summary>
	class Vector
	{
		private double X { get; set; }
		private double Y { get; set; }
		private double Z { get; set; }


		/// <summary>
		/// instantiate a new Vector
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="z"></param>
		public Vector(double x, double y, double z)
		{
			X = x;
			Y = y;
			Z = z;
		}

		/// <summary>
		/// add the _right Vector to the _left Vector
		/// </summary>
		/// <param name="_left"></param>
		/// <param name="_right"></param>
		/// <returns></returns>
		public static Vector operator +(Vector _left, Vector _right)
		{
			return new Vector(_left.X + _right.X, _left.Y + _right.Y, _left.Z + _left.Z);
		}

		/// <summary>
		/// substract the _left Vector with the _right Vector
		/// </summary>
		/// <param name="_left"></param>
		/// <param name="_right"></param>
		/// <returns></returns>
		public static Vector operator -(Vector _left, Vector _right)
		{
			return new Vector(_left.X - _right.X, _left.Y - _right.Y, _left.Z - _left.Z);
		}

		/// <summary>
		/// divide the _left vector by the _right vector.
		/// </summary>
		/// <param name="_left"></param>
		/// <param name="_right"></param>
		/// <returns></returns>
		public static Vector operator /(Vector _left, Vector _right)
		{
			return new Vector(_left.X / _right.X, _left.Y / _right.Y, _left.Z / _left.Z);
		}

		/// <summary>
		/// multiply the _left Vector by the _right Vector
		/// </summary>
		/// <param name="_left"></param>
		/// <param name="_right"></param>
		/// <returns></returns>
		public static Vector operator *(Vector _left, Vector _right)
		{
			return new Vector(_left.X * _right.X, _left.Y * _right.Y, _left.Z * _left.Z);
		}

	}
}
