using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Vector3 movePos;
    Player player;

    void Start()
    {
        movePos = transform.position;
        player = GetComponent<Player>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        Ray ray = transform.parent.GetChild(1).GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("Environment"));
        float lX = Input.GetAxis("P" + player.GetPlayerNo() + "LHoriz");
        float lZ = Input.GetAxis("P" + player.GetPlayerNo() + "LVert");
        float rX = Input.GetAxis("P" + player.GetPlayerNo() + "RHoriz");
        float rZ = Input.GetAxis("P" + player.GetPlayerNo() + "RVert");
        float keyH = Input.GetAxis("KeyHoriz");
        float keyV = Input.GetAxis("KeyVert");

        // Player Movement
        if (lX != 0 || lZ != 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x + lX, transform.position.y, transform.localPosition.z + lZ), player.GetMoveSpeed() * Time.deltaTime);
            movePos = transform.position;
        }

        if (keyH != 0 || keyV != 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x + keyH, transform.position.y, transform.position.z + keyV), player.GetMoveSpeed() * Time.deltaTime);
            movePos = transform.position;
        }

        // Targeter Movement
        if (rX != 0 || rZ != 0)
        {
            player.GetTargeter().transform.position = Vector3.MoveTowards(player.GetTargeter().transform.position, new Vector3(player.GetTargeter().transform.position.x + rX, player.GetTargeter().transform.position.y, player.GetTargeter().transform.position.z + rZ), player.GetTargeterSpeed() * Time.deltaTime);
        }

        if (hit.transform != null)
        {
            player.GetTargeter().transform.position = new Vector3(hit.point.x, player.GetTargeter().transform.position.y, hit.point.z);
        }

        // Player Rotation
        transform.LookAt(new Vector3(player.GetTargeter().transform.position.x, transform.position.y, player.GetTargeter().transform.position.z));
    }
}