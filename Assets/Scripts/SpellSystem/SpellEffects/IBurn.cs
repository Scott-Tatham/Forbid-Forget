using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBurn
{
    Coroutine RunBurn(int _iter, float _time, float _dmg);
    IEnumerator Burn(int _iter, float _time, float _dmg);
}