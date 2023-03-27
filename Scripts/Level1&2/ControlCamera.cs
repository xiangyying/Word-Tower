using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamera : MonoBehaviour
{
    [SerializeField]private Transform player;
    public Vector3 offset;


    private void Update()
    {
        transform.position = new Vector3(transform.position.x, player.position.y + 6, transform.position.z);
    }
}
