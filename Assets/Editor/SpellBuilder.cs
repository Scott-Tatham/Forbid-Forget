using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

public class SpellBuilder : EditorWindow
{
    static SpellBuilder instance;

    Vector2 scrollPos;
    Rect incompArea, compArea;
    GUIStyle guiStyle;
    SpellDataBase spellDB;
    SerializedObject serObjSpellDB;
    SerializedProperty incompProp, compProp;
    ReorderableList incompSpells, compSpells;

    [MenuItem("Tools/Spell Builder")]
    static void CreateWindow()
    {
        instance = GetWindow<SpellBuilder>();
    }

    void OnEnable()
    {
        if (instance == null)
        {
            instance = this;
        }

        else
        {
            Destroy(this);
        }

        if (SpellDataBase.GetSpellDB() == null)
        {
            Debug.Log("Hi");
            spellDB = new SpellDataBase();
        }

        else
        {
            spellDB = SpellDataBase.GetSpellDB();
        }

        minSize = new Vector2(500, 100);
        guiStyle = new GUIStyle();
        guiStyle.richText = true;
        spellDB.SetSpellData();
        serObjSpellDB = new SerializedObject(spellDB as object as Object);
        incompProp = serObjSpellDB.FindProperty("incomplete");
        incompSpells = new ReorderableList(serObjSpellDB, incompProp, true, true, true, true);
        incompSpells.drawHeaderCallback = (rect) => EditorGUI.LabelField(new Rect(5, 10, 100, 20), "<size=12><color=orange><b>In Progress</b></color></size>", guiStyle);
        incompSpells.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) =>
        {
            rect.y += 2;
            SerializedProperty spell = incompSpells.serializedProperty.GetArrayElementAtIndex(index);
            EditorGUI.PropertyField(new Rect(rect.x, rect.y, 100, EditorGUIUtility.singleLineHeight), spell.FindPropertyRelative("spellName"), GUIContent.none);
        };
    }

    void OnGUI()
    {
        incompArea = new Rect(position.width - 450, 0, 300, position.height);
        //compArea = new Rect(position.width - 130, 0, 130, position.height);
        
        scrollPos = GUI.BeginScrollView(incompArea, scrollPos, new Rect(0, 0, 0, position.height));
        GUI.BeginGroup(new Rect(0, 0, 300, position.height));
        incompSpells.DoList(new Rect(0, 10, 250, position.height - 40));

        if (GUI.Button(new Rect(0, position.height - 20, 100, 20), "Save"))
        {
            spellDB.SaveSpell();
        }

        GUI.EndGroup();
        GUI.EndScrollView();

        //GUI.BeginGroup(compArea);
        //EditorGUI.LabelField(new Rect(5, 5, 100, 20), "<size=12><color=green><b>Complete /Spells<//b></color></size>", guiStyle);
        //compScroll = GUI.BeginScrollView(compScRect, compScroll, new Rect(0, 20, 100, (25 * //complete.Count)));
        //
        //for (int i = 0; i < complete.Count; i++)
        //{
        //    GUI.Box(compNRect[i], complete[i]);
        //}
        //
        //GUI.EndScrollView();
        //GUI.EndGroup();
    }
}