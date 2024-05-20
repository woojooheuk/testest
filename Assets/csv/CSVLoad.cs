using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSVLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    List<Dictionary<string, object>> data = CSVReader.Read("test_list");
    for (int i =0;i<data.Count;i++){
        UnityEngine.Debug.Log(data[i]["image"].ToString());
    }
    }
}
