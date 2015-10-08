using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityServerBasics.Utilities
{
	class EventList<T> : List<T>
	{

		#region Events and delegates
		public delegate void Added(T element);

		private event Added OnAdd;

		private delegate void Removed(T element);

		private event Removed OnRemoved;
		#endregion

		/// <summary>
		/// Standard constructor
		/// </summary>
		public EventList() { }

		/// <summary>
		/// Add new <see cref="T"/> to the list.
		/// </summary>
		/// <param name="element"></param>
		public new void Add(T element)
		{
			OnAdd(element);
			base.Add(element);
		}

		/// <summary>
		/// Remove first T where T is the type of the element. from the list.
		/// </summary>
		/// <returns></returns>
		public new void Remove(T element)
		{
			base.Remove(element);
			OnRemoved(element);
		}

		/// <summary>
		/// External subscription 
		/// </summary>
		/// <param name="_method"></param>
		public void SubscribeToAdd(Added _method)
		{
			OnAdd += _method;
		}
	}
}
