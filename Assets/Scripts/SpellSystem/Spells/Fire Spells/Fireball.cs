using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Spell
{
    [SerializeField]
    int iter;
    [SerializeField]
    float dmg, time, burn, speed;

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (casted)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.forward, speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider _col)
    {
        if (_col.GetComponent<Unit>() != null && _col.GetComponent<Unit>() != caster)
        {
            if (_col.GetComponent<IHealth>() != null)
            {
                _col.GetComponent<IHealth>().DealDamage(dmg);
            }

            if (_col.GetComponent<IBurn>() != null)
            {
                _col.GetComponent<IBurn>().RunBurn(iter, time, burn);
            }

            casted = false;
            transform.parent = caster.transform;
            gameObject.SetActive(false);
        }
    }
}