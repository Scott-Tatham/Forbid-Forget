using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpells : MonoBehaviour
{
    bool cast;
    Player player;
    List<GameObject>[] spells;
    Dictionary<SpellIndex, GameObject> spellObjs;

    void Start()
    {
        player = GetComponent<Player>();
        spells = new List<GameObject>[8]
        {
            new List<GameObject>(),
            new List<GameObject>(),
            new List<GameObject>(),
            new List<GameObject>(),
            new List<GameObject>(),
            new List<GameObject>(),
            new List<GameObject>(),
            new List<GameObject>()
        };

        spellObjs = new Dictionary<SpellIndex, GameObject>()
        {
            { SpellIndex.FIREBALL, (GameObject)Resources.Load("Prefabs/Spells/Fireball") }
        };

        EquipSpell(SpellIndex.FIREBALL, 5, 0);
    }

    void EquipSpell(SpellIndex _spellIndex, int _iter, int _slot, bool _clear = false)
    {
        if (_clear)
        {
            spells[_slot].Clear();
        }

        for (int i = 0; i < _iter; i++)
        {
            spells[_slot].Add(Instantiate(spellObjs[_spellIndex], player.transform.position, Quaternion.identity, player.transform));
        }
    }

    void Update()
    {
        Cast();
    }

    void Cast()
    {
        float trigger = Input.GetAxis("P" + player.GetPlayerNo() + "Trigg");
        
        if (Input.GetButtonDown("P" + player.GetPlayerNo() + "RBump") || Input.GetButtonDown("ButtSlot1"))
        {
            for (int i = 0; i < spells[0].Count; i++)
            {
                if (i >= spells[0].Count - 2)
                {
                    EquipSpell(SpellIndex.FIREBALL, 1, 0);
                }

                if (!spells[0][i].GetComponent<Spell>().GetCasted())
                {
                    spells[0][i].GetComponent<Spell>().Cast(player);
                    return;
                }
            }
        }
        
        if (Input.GetButtonDown("P" + player.GetPlayerNo() + "LBump") || Input.GetButtonDown("ButtSlot2"))
        {
            for (int i = 0; i < spells[1].Count; i++)
            {
                if (i >= spells[1].Count - 2)
                {
                    EquipSpell(SpellIndex.FIREBALL, 1, 1);
                }

                if (!spells[1][i].GetComponent<Spell>().GetCasted())
                {
                    spells[1][i].GetComponent<Spell>().Cast(player);
                    return;
                }
            }
        }
        
        if (trigger > 0 || Input.GetButtonDown("ButtSlot3"))
        {
            for (int i = 0; i < spells[2].Count; i++)
            {
                if (i >= spells[2].Count - 2)
                {
                    EquipSpell(SpellIndex.FIREBALL, 1, 2);
                }

                if (!spells[2][i].GetComponent<Spell>().GetCasted())
                {
                    spells[2][i].GetComponent<Spell>().Cast(player);
                    return;
                }
            }
        }
        
        if (trigger < 0 || Input.GetButtonDown("ButtSlot4"))
        {
            for (int i = 0; i < spells[3].Count; i++)
            {
                if (i >= spells[3].Count - 2)
                {
                    EquipSpell(SpellIndex.FIREBALL, 1, 3);
                }

                if (!spells[3][i].GetComponent<Spell>().GetCasted())
                {
                    spells[3][i].GetComponent<Spell>().Cast(player);
                    return;
                }
            }
        }
        
        if (Input.GetButtonDown("P" + player.GetPlayerNo() + "Butt1") || Input.GetButtonDown("ButtSlot5"))
        {
            for (int i = 0; i < spells[4].Count; i++)
            {
                if (i >= spells[4].Count - 2)
                {
                    EquipSpell(SpellIndex.FIREBALL, 1, 4);
                }

                if (!spells[4][i].GetComponent<Spell>().GetCasted())
                {
                    spells[4][i].GetComponent<Spell>().Cast(player);
                    return;
                }
            }
        }
        
        if (Input.GetButtonDown("P" + player.GetPlayerNo() + "Butt2") || Input.GetButtonDown("ButtSlot6"))
        {
            for (int i = 0; i < spells[5].Count; i++)
            {
                if (i >= spells[5].Count - 2)
                {
                    EquipSpell(SpellIndex.FIREBALL, 1, 5);
                }

                if (!spells[5][i].GetComponent<Spell>().GetCasted())
                {
                    spells[5][i].GetComponent<Spell>().Cast(player);
                    return;
                }
            }
        }
        
        if (Input.GetButtonDown("P" + player.GetPlayerNo() + "Butt3") || Input.GetButtonDown("ButtSlot7"))
        {
            for (int i = 0; i < spells[6].Count; i++)
            {
                if (i >= spells[6].Count - 2)
                {
                    EquipSpell(SpellIndex.FIREBALL, 1, 6);
                }

                if (!spells[6][i].GetComponent<Spell>().GetCasted())
                {
                    spells[6][i].GetComponent<Spell>().Cast(player);
                    return;
                }
            }
        }
        
        if (Input.GetButtonDown("P" + player.GetPlayerNo() + "Butt4") || Input.GetButtonDown("ButtSlot8"))
        {
            for (int i = 0; i < spells[7].Count; i++)
            {
                if (i >= spells[7].Count - 2)
                {
                    EquipSpell(SpellIndex.FIREBALL, 1, 7);
                }

                if (!spells[7][i].GetComponent<Spell>().GetCasted())
                {
                    spells[7][i].GetComponent<Spell>().Cast(player);
                    return;
                }
            }
        }
    }
}