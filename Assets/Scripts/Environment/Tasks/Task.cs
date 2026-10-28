using UnityEngine;

namespace Environment.Tasks {
    public abstract class Task : ScriptableObject {
        public abstract object ExecuteTask(object input = null);
    }

    public abstract class Task<TOutput> : Task {
        public abstract TOutput Execute();

        public override object ExecuteTask(object input = null) {
            return Execute();
        }

    }
}
