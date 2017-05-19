using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    [SerializeField]
    protected float spellLife;
    [SerializeField]
    protected string spellName;

    protected bool casted;
    protected Coroutine lifeTime;
    protected Unit caster;

    public bool GetCasted() { return casted; }

    void Awake()
    {
        gameObject.SetActive(false);
    }

    public virtual void Cast(Unit _caster)
    {
        gameObject.SetActive(true);
        casted = true;
        caster = _caster;
        transform.position = caster.transform.position;
        transform.rotation = caster.transform.rotation;
        transform.parent = null;
        lifeTime = StartCoroutine(LifeTime(spellLife));
    }

    IEnumerator LifeTime(float _time)
    {
        yield return new WaitForSeconds(_time);
        gameObject.SetActive(false);
        transform.parent = caster.transform;
    }
}