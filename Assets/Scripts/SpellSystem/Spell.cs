using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    [SerializeField]
    protected string spellName;

    protected bool casted;
    protected Unit caster;

    public bool GetCasted() { return casted; }

    public virtual void Cast(Unit _caster)
    {
        gameObject.SetActive(true);
        casted = true;
        caster = _caster;
        transform.position = _caster.transform.position;
        transform.LookAt(_caster.transform.position + (_caster.transform.forward * Mathf.Infinity));
        transform.parent = null;
    }
}