using UnityEngine;
using System;
using System.IO;
using LitJson;



using UnityEngine;

namespace Environment.Tasks {

    [CreateAssetMenu(menuName = "Tasks/Read Employees")]


    public class ReadTask : Task<Employee[]> {

        [SerializeField] private string fileName = "employees.json";
        public override Employee[] Execute() {


            string filePath = Path.Combine(
                Application.streamingAssetsPath,
                fileName
            );
            string json = File.ReadAllText(filePath);

            JsonData data = JsonMapper.ToObject(json);
            JsonData employeeList = data["employees"];


            Employee[] employees = new Employee[employeeList.Count];


            for(int i = 0; i < employeeList.Count; i++) {
                JsonData item = employeeList[i];

                employees[i] = new Employee {
                    name = (string)item["name"],
                    employeeId = (int)item["employeeId"],
                    hasEngineRoomClearance =
                        (bool)item["hasEngineRoomClearance"],

                    lastEntranceInEngineRoom = DateTime.Parse(
                        (string)item["lastEntranceInEngineRoom"]
                    ),

                    lastExitFromEngineRoom = DateTime.Parse(
                        (string)item["lastExitFromEngineRoom"]
                    )
                };

            }


                return employees;


        }
    }
}

