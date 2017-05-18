using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    [SerializeField]
    int playerNo;
    [SerializeField]
    GameObject targeter;

    float targeterSpeed;

    public int GetPlayerNo() { return playerNo; }
    public float GetTargeterSpeed() { return targeterSpeed; }
    public GameObject GetTargeter() { return targeter; }

    protected override void Start()
    {
        base.Start();

        moveSpeed = (float)(double)UnitData.GetUnitStats()[unitType][0][1];
        targeterSpeed = (float)(double)UnitData.GetUnitStats()[unitType][0][2];
    }
}