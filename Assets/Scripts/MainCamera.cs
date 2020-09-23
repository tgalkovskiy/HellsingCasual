using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public GeneralMove Player;
    private Vector3 VelocityCamera;
    private void Awake()
    {
        VelocityCamera = new Vector3(0,0,-10);
        
    }
    private void LateUpdate()
    {
        VelocityCamera.x += Player.Velocity.x*Player.Speed*Time.deltaTime;
        transform.position = VelocityCamera;
    }
}
