using LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class SpellDataBase : ScriptableObject
{
    static JsonData spellData;
    static SpellDataBase instance;
    
    [SerializeField]
    List<Spell> incomplete, complete;

    public SpellDataBase()
    {
        instance = this;
        incomplete = new List<Spell>();
        complete = new List<Spell>();
    }

    public static SpellDataBase GetSpellDB() { return instance; }
    public List<Spell> GetIncomplete() { return incomplete; }

    public void SetSpellData()
    {
        spellData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/SpellData.json"));
    }

    public void SaveSpell()
    {
        for (int i = 0; i < incomplete.Count; i++)
        {
            if (i >= spellData[0].Count)
            {
                spellData[0].Add(JsonMapper.ToJson(incomplete[i]));
            }

            spellData[0][i][0] = JsonMapper.ToJson(incomplete[i]);
        }
    }
}