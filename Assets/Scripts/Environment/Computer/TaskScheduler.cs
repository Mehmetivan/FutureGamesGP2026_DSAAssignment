using Environment.Tasks;
using UnityEngine;

public class TaskScheduler : MonoBehaviour {
    private MinHeap queue;

    [SerializeField] private Task testTask1;
    [SerializeField] private Task testTask2;
    [SerializeField] private Task testTask3;

    private void Awake() {

        queue = new MinHeap(100);
        queue.Insert(testTask1, 3);
        queue.Insert(testTask2, 1);
        queue.Insert(testTask3, 2);

    }

    public bool AddTask(Task task, int priority) {
        return queue.Insert(task, priority);
    }

    public void ExecuteNextTask() {
        if(queue.current_heap_size == 0) {
            Debug.Log("No tasks in queue.");
            return;
        }

        Task task = queue.ExtractMin();
        task.Execute();
    }
}
