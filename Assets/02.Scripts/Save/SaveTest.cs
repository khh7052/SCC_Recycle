using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class SaveTest : MonoBehaviour
{
    public TestData testData = new();
    void Start()
    {
        SaveManager.Save(testData);
        // string data = JsonUtility.ToJson(testData);
    }

}
