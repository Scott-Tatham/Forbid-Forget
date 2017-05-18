using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour, IHealth, IBurn
{
    protected bool canMove, canAttack;
    protected int unitType, resistOff;
    protected float health, maxHealth, shield, moveSpeed;
    protected float[] resistances;
    //protected Dictionary<ElementalMods, Coroutine> resistBuffs;
    //protected Dictionary<Buffs, Coroutine> timedBuffs;
    //protected Dictionary<Buffs, float> durabBuffs;

    public bool GetCanMove() { return canMove; }
    public bool GetCanAttack() { return canAttack; }
    public float GetHealth() { return health; }
    public float GetMoveSpeed() { return moveSpeed; }
    public float GetEleResistance(int _index) { return resistances[_index]; }
    //public Dictionary<Buffs, Coroutine> GetTimedBuffs() { return timedBuffs; }
    //public Dictionary<Buffs, float> GetDurabBuffs() { return durabBuffs; }

    public virtual void SetCanMove(bool _canMove) { canMove = _canMove; }
    public virtual void SetCanAttack(bool _canAttack) { canAttack = _canAttack; }
    public void SetHealth(float _health) { health = _health; }
    public void SetShield(float _shield) { shield = _shield; }
    public void SetMoveSpeed(float _moveSpeed) { moveSpeed = _moveSpeed; }

    //public void SetResistances()
    //{
    //    for (int i = 0; i < resistances.Length; i++)
    //    {
    //        resistances[i] = (float)(double)UnitData.GetUnitStats()[unitType][0][i + resistOff];
    //    }
    //}

    //public void SetBuff(Buffs _buff, Coroutine _cor)
    //{
    //    if (timedBuffs.ContainsKey(_buff))
    //    {
    //        StopCoroutine(timedBuffs[_buff]);
    //        timedBuffs.Remove(_buff);
    //    }
    //
    //    timedBuffs.Add(_buff, _cor);
    //}

    //public void SetBuff(Buffs _buff, float _time, float _amount)
    //{
    //    if (timedBuffs.ContainsKey(_buff))
    //    {
    //        StopCoroutine(timedBuffs[_buff]);
    //        timedBuffs.Remove(_buff);
    //    }
    //    
    //    float baseMoveSpeed = (float)(double)UnitData.GetUnitStats()[unitType][0][1];
    //    float curDiff = moveSpeed - baseMoveSpeed;
    //    moveSpeed = baseMoveSpeed;
    //    timedBuffs.Add(_buff, StartCoroutine(Slow(_time, _amount + curDiff)));
    //}

    //public void SetBuff(Buffs _buff, float _durab)
    //{
    //    if (durabBuffs.ContainsKey(_buff))
    //    {
    //        StopCoroutine(timedBuffs[_buff]);
    //        durabBuffs.Remove(_buff);
    //    }
    //
    //    durabBuffs.Add(_buff, _durab);
    //}

    //public void SetBuff(float _time, float _amount, ElementalMods _element)
    //{
    //    if (resistBuffs.ContainsKey(_element))
    //    {
    //        StopCoroutine(resistBuffs[_element]);
    //        resistBuffs.Remove(_element);
    //    }
    //
    //    float curResist = resistances[(int)_element];
    //    float baseResist = (float)(double)UnitData.GetUnitStats()[unitType][0][(int)_element + resistOff];
    //    float curDiff = curResist - baseResist;
    //    resistances[(int)_element] = baseResist;
    //    resistBuffs.Add(_element, StartCoroutine(ModResistance(_time, _amount + curDiff, _element)));
    //}

    //public void RemoveBuff(Buffs _buff)
    //{
    //    if (timedBuffs.ContainsKey(_buff))
    //    {
    //        timedBuffs.Remove(_buff);
    //    }
    //
    //    else if (durabBuffs.ContainsKey(_buff))
    //    {
    //        durabBuffs.Remove(_buff);
    //    }
    //}

    //public void RemoveBuff(ElementalMods _element)
    //{
    //    if (resistBuffs.ContainsKey(_element))
    //    {
    //        resistBuffs.Remove(_element);
    //    }
    //}

    //void Awake()
    //{
    //    resistBuffs = new Dictionary<ElementalMods, Coroutine>();
    //    timedBuffs = new Dictionary<Buffs, Coroutine>();
    //    durabBuffs = new Dictionary<Buffs, float>();
    //}

    protected virtual void Start()
    {
        unitType = 0;
        health = (float)(double)UnitData.GetUnitStats()[unitType][0][0];
        maxHealth = health;
        resistOff = 3;
    //    resistances = new float[SpellDataTypes.GetSpellData()[0].Count];
        //SetResistances();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log(gameObject.name + ": " + health);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            DealDamage(50);
        }

        Death();
    }

    public void Death()
    {
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public virtual void DealDamage(float _dmg)
    {
        if (shield > 0)
        {
            if (_dmg - shield <= 0)
            {
                shield -= _dmg;
                _dmg = 0;
            }
    
            else
            {
                _dmg -= shield;
                shield = 0;
            }
        }
    
        health -= _dmg;
    }

    public virtual void ApplyHeal(float _heal)
    {
        if ((health + _heal) > maxHealth)
        {
            health = maxHealth;
        }

        else
        {
            health += _heal;
        }
    }

    public Coroutine RunDOT(int _iter, float _time, float _dmg)
    {
        return StartCoroutine(DOT(_iter, _time, _dmg));
    }

    public virtual IEnumerator DOT(int _iter, float _time, float _dmg)
    {
        for (float i = 0; i < _iter; i += 0.1f)
        {
            float dmg = Random.Range((_dmg - 5), (_dmg + 5));
            //dmg /= 10;
            dmg = Mathf.Abs(dmg);
            DealDamage(dmg);

            yield return new WaitForSeconds(_time);
        }
    }

    public Coroutine RunHOT(int _iter, float _time, float _heal)
    {
        return StartCoroutine(HOT(_iter, _time, _heal));
    }

    public virtual IEnumerator HOT(int _iter, float _time, float _heal)
    {
        for (float i = 0; i < _iter; i += 0.1f)
        {
            float heal = Random.Range((_heal - 5), (_heal + 5));
            //heal /= 10;
            heal = Mathf.Abs(heal);
            ApplyHeal(heal);

            yield return new WaitForSeconds(_time);
        }
    }

    public Coroutine RunBurn(int _iter, float _time, float _dmg)
    {
        return StartCoroutine(Burn(_iter, _time, _dmg));
    }

    public virtual IEnumerator Burn(int _iter, float _time, float _dmg)
    {
        for (int i = 0; i < _iter; i++)
        {
            DealDamage(_dmg);
            yield return new WaitForSeconds(_time);
        }
    }

    //public virtual IEnumerator ModResistance(float _time, float _amount, ElementalMods _element)
    //{
    //    resistances[(int)_element] += _amount;
    //    yield return new WaitForSeconds(_time);
    //    resistances[(int)_element] -= _amount;
    //    RemoveBuff(_element);
    //}
}