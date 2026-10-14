using System;
using Environment.Tasks;

namespace Environment.Tasks {
    public class MinHeap {
        private class HeapEntry {
            public Task Task;
            public int Priority;

            public HeapEntry(Task task, int priority) {
                Task = task;
                Priority = priority;
            }
        }

        private HeapEntry[] heapArray;

        public int capacity { get; private set; }
        public int current_heap_size { get; private set; }

        public MinHeap(int capacity) {
            if(capacity <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(capacity));

            this.capacity = capacity;
            heapArray = new HeapEntry[capacity];
            current_heap_size = 0;
        }

        public int Parent(int index) => (index - 1) / 2;
        public int Left(int index) => 2 * index + 1;
        public int Right(int index) => 2 * index + 2;

        public bool Insert(Task task, int priority) {
            if(task == null)
                throw new ArgumentNullException(nameof(task));

            if(current_heap_size == capacity)
                return false;

            int i = current_heap_size;
            heapArray[i] = new HeapEntry(task, priority);
            current_heap_size++;

            while(i > 0 &&
                   heapArray[i].Priority <
                   heapArray[Parent(i)].Priority) {
                Swap(i, Parent(i));
                i = Parent(i);
            }

            return true;
        }

        public Task GetMin() {
            if(current_heap_size == 0)
                throw new InvalidOperationException(
                    "The heap is empty.");

            return heapArray[0].Task;
        }

        public Task ExtractMin() {
            if(current_heap_size == 0)
                throw new InvalidOperationException(
                    "The heap is empty.");

            Task result = heapArray[0].Task;

            current_heap_size--;

            if(current_heap_size > 0) {
                heapArray[0] = heapArray[current_heap_size];
                heapArray[current_heap_size] = null;
                MinHeapify(0);
            }
            else {
                heapArray[0] = null;
            }

            return result;
        }

        public void MinHeapify(int index) {
            int left = Left(index);
            int right = Right(index);
            int smallest = index;

            if(left < current_heap_size &&
                heapArray[left].Priority <
                heapArray[smallest].Priority) {
                smallest = left;
            }

            if(right < current_heap_size &&
                heapArray[right].Priority <
                heapArray[smallest].Priority) {
                smallest = right;
            }

            if(smallest != index) {
                Swap(index, smallest);
                MinHeapify(smallest);
            }
        }

        private void Swap(int a, int b) {
            HeapEntry temp = heapArray[a];
            heapArray[a] = heapArray[b];
            heapArray[b] = temp;
        }
    }
}
