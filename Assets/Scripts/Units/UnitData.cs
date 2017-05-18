using LitJson;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class UnitData : MonoBehaviour
{
    static JsonData unitStats = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/UnitData.json"));
    
    public static JsonData GetUnitStats() { return unitStats; }
}