using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDummy : Unit
{
    protected override void Start()
    {
        unitType = 1;
        health = (float)(double)UnitData.GetUnitStats()[unitType][0][0];
        maxHealth = health;
        resistOff = 1;
        //resistances = new float[SpellDataTypes.GetSpellData()[0].Count];
        //SetResistances();
    }
}