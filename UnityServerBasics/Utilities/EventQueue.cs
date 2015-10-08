using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityServerBasics.Utilities
{
	class EventQueue<T> : Queue<T>
	{
		private delegate void Added(T _element);

		private event Added OnAdd;
		
		private delegate void Removed(T _element);

		private event Removed OnRemoved;

		/// <summary>
		/// Standard constructor
		/// </summary>
		public EventQueue(){}

		/// <summary>
		/// Add new <see cref="T"/> to the queue.
		/// </summary>
		/// <param name="_element"></param>
		public new void Enqueue(T _element)
		{
			OnAdd?.Invoke(_element);
			base.Enqueue(_element);
		}

		/// <summary>
		/// Remove first T where T is the type of the element. from the queue.
		/// </summary>
		/// <returns></returns>
		public new T Dequeue()
		{
			T t = base.Dequeue();
			OnRemoved?.Invoke(t);
			return t;
		}


	}
}
