using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWave : Spell
{
    [SerializeField]
    float dmg;
    [SerializeField]
    float time;

    bool canDmg;

    void Start()
    {
        canDmg = true;
    }

    void OnTriggerStay(Collider _col)
    {
        if (_col.GetComponent<Unit>() != null && _col.GetComponent<Unit>() != caster && canDmg)
        {
            if (_col.GetComponent<IHealth>() != null)
            {
                _col.GetComponent<IHealth>().DealDamage(dmg);
                StartCoroutine(DmgWait(time));
            }

            casted = false;
            transform.parent = caster.transform;
            gameObject.SetActive(false);
        }
    }

    IEnumerator DmgWait(float _time)
    {
        canDmg = false;
        yield return new WaitForSeconds(_time);
        canDmg = true;
    }
}