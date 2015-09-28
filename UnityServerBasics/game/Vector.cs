using System;
using System.Xml.Serialization;
using UnityServerBasics.Network.Exceptions;
using UnityServerBasics.Network.Serialization;

namespace UnityServerBasics.game
{

	/// <summary>
	/// A basic Vector object.
	/// </summary>
	[Serializable]
	class Vector : INetworkSerializer
	{
		/// <summary>
		/// The x value of this vector.
		/// </summary>
		[XmlElement("X")]
		private double X { get; set; }

		/// <summary>
		/// The y vanlue of this vector.
		/// </summary>
		[XmlElement("Y")]
		private double Y { get; set; }

		/// <summary>
		/// The z value of this vector.
		/// </summary>
		[XmlElement("Z")]
		private double Z { get; set; }


		/// <summary>
		/// instantiate a new Vector
		/// </summary>
		/// <param name="x">the new X value for this vector</param>
		/// <param name="y">the new Y value for this vector</param>
		/// <param name="z">the new Z value for this vector</param>
		public Vector(double x, double y, double z)
		{
			X = x;
			Y = y;
			Z = z;
		}

		/// <summary>
		/// add the _right Vector to the _left Vector
		/// </summary>
		/// <param name="_left">"This" Vector</param>
		/// <param name="_right">The second Vector</param>
		/// <returns></returns>
		public static Vector operator +(Vector _left, Vector _right)
		{
			return new Vector(_left.X + _right.X, _left.Y + _right.Y, _left.Z + _left.Z);
		}

		/// <summary>
		/// substract the _left Vector with the _right Vector
		/// </summary>
		/// <param name="_left">"This" Vector</param>
		/// <param name="_right">The second Vector</param>
		/// <returns></returns>
		public static Vector operator -(Vector _left, Vector _right)
		{
			return new Vector(_left.X - _right.X, _left.Y - _right.Y, _left.Z - _left.Z);
		}

		/// <summary>
		/// divide the _left vector by the _right vector.
		/// </summary>
		/// <param name="_left">"This" Vector</param>
		/// <param name="_right">The second Vector</param>
		/// <returns></returns>
		public static Vector operator /(Vector _left, Vector _right)
		{
			return new Vector(_left.X / _right.X, _left.Y / _right.Y, _left.Z / _left.Z);
		}

		/// <summary>
		/// multiply the _left Vector by the _right Vector
		/// </summary>
		/// <param name="_left">"This" Vector</param>
		/// <param name="_right">The second Vector</param>
		/// <returns></returns>
		public static Vector operator *(Vector _left, Vector _right)
		{
			return new Vector(_left.X * _right.X, _left.Y * _right.Y, _left.Z * _left.Z);
		}

		/// <summary>
		/// Get the element from the index.<para />
		/// 0 - X <para/>
		/// 1 - Y <para/>
		/// 2 - Z <para/>
		/// </summary>
		/// <param name="index">the index to get</param>
		/// <returns>the element selected</returns>
		public double this[int index]
		{
			get
			{
				if(index == 0)
				{
					return X;
				}
				else if(index == 1)
				{
					return Y;
				}
				else if(index == 2)
				{
					return Z;
				}
				else
				{
					throw new IndexOutOfBoundsException("A vector only contains 3 items, with 0 indexing");
				}
			}
			set
			{
				if (index == 0)
				{
					X = value;
				}
				else if (index == 1)
				{
					Y = value;
				}
				else if (index == 2)
				{
					Z = value;
				}
				else
				{
					throw new IndexOutOfBoundsException("A vector only contains 3 items, with 0 indexing");
				}
			}
		}

		
	}
}
