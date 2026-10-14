using UnityEngine;

namespace Environment.Tasks {
    [CreateAssetMenu(
        fileName = "TestTask",
        menuName = "Computer/Tasks/Test Task")]
    public class TestTask : Task {
        public override void Execute() {
            Debug.Log($"Task executed: {name}");
        }
    }
}
