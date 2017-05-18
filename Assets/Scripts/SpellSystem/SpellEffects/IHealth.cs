using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealth
{
    void DealDamage(float _dmg);
    void ApplyHeal(float _heal);
    Coroutine RunDOT(int _iter, float _time, float _dmg);
    Coroutine RunHOT(int _iter, float _time, float _heal);
    IEnumerator DOT(int _iter, float _time, float _dmg);
    IEnumerator HOT(int _iter, float _time, float _heal);
}