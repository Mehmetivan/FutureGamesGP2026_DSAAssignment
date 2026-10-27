using UnityEngine;

namespace Environment.Tasks {
    [CreateAssetMenu(menuName = "Tasks/Print Employees")]
    public class PrintTask : Task {
        public override object ExecuteTask(object input) {
            if(input is not Employee[] employees) {
                Debug.LogError("PrintEmployeesTask received no employee array!");
                return null;
            }

            Debug.Log("Number of employees: " + employees.Length);

            foreach(Employee employee in employees) {
                Debug.Log(
                    "Name: " + employee.name +
                    ", ID: " + employee.employeeId +
                    ", Clearance: " + employee.hasEngineRoomClearance
                );
            }

            return null;
        }
    }
}
