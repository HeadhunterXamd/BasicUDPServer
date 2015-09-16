using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityServerBasics.Utilities
{
	class EventQueue<T> : Queue<T>
	{
		private delegate void Added(T element);

		private event Added OnAdd;
		
		private delegate void Removed(T element);

		private event Removed OnRemoved;

		/// <summary>
		/// Standard constructor
		/// </summary>
		public EventQueue(){}

		/// <summary>
		/// Add new <see cref="T"/> to the queue.
		/// </summary>
		/// <param name="element"></param>
		public new void Enqueue(T element)
		{
			OnAdd(element);
			base.Enqueue(element);
		}

		/// <summary>
		/// Remove first T where T is the type of the element. from the queue.
		/// </summary>
		/// <returns></returns>
		public new T Dequeue()
		{
			T t = base.Dequeue();
			OnRemoved(t);
			return t;
		}


	}
}
