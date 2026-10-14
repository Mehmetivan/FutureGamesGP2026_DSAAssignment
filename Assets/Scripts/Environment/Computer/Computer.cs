using Environment.Tasks;
using System.Threading.Tasks;
using UnityEngine;

namespace Environment {
    public class Computer : MonoBehaviour, IInteractable {
        [SerializeField]
        private TaskScheduler scheduler;
        //private Task testTask = null; // Put your stack/queue here :)

        public void OnInteract() {
            scheduler.ExecuteNextTask();
        }
    }
}
