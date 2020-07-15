using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;
    
    private void Awake()
    {
        
    }
    void LateUpdate()
    {
        transform.rotation = player.transform.rotation;
        transform.position = player.transform.position;
        transform.Translate(offset);
        transform.LookAt(player.transform);
    }
}
