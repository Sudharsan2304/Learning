using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedProject.Extensions
{
    public static class PriorityQueueExtensions
    {
        public static bool IsNotEmpty<TElement, TPriority>(this PriorityQueue<TElement, TPriority> priorityQueue) => priorityQueue.Count > 0;
    }
}
