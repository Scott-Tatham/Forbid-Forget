using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField]
    float offSet;

    Transform player;

    void Start()
    {
        player = transform.parent.GetChild(0);
    }

    void Update()
    {
        Follow();
    }

    void Follow()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.position.x, transform.position.y, player.position.z - offSet), player.GetComponent<Player>().GetMoveSpeed() * Time.deltaTime);
    }
}