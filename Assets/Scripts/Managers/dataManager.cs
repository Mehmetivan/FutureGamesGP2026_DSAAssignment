using LitJson;
using UnityEngine;
using System.IO;

public class dataManager : MonoBehaviour {

    private JsonData data;

    private void Start() {
        data = LoadJsonFromFile();

    }

    public JsonData LoadJsonFromFile() {

        string jsonAsString = Resources.Load<TextAsset>("son/myJson").text;
        return JsonMapper.ToObject(jsonAsString);
    }
    public int GetData(string level, string task) {
        return (int)data[level][task];

    }
    public void SetData(string level, string task, int value) {

        int curVal = (int)data[level][task];
    }

}
