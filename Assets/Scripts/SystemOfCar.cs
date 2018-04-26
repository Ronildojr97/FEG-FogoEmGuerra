using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemOfCar : MonoBehaviour {

    [Header("Whell configure")]
    public WheelCollider[] wheel;
    [Header("Mesh Render")]
    public Transform[] roda;
    [Header("Car configure")]
    public float MaxVelocity;
    public float MaxTorque;
    public int MaxAngle;
    public float BreakTorque;
    [Header("CenterOfMass")]
    public Vector3 centerOfMass;
    public Rigidbody GetRigidbody;

    private void Start()
    {
        GetRigidbody.GetComponent<Rigidbody>();
        GetRigidbody.centerOfMass = centerOfMass;   
    }

    void Update () {
		
	}
    private void FixedUpdate()
    {
        controle();
        rodasRender();
        velocidade();
    }

    // controle do carro
    public void controle()
    {
        float angle = Input.GetAxis("Horizontal");
        float torque = Input.GetAxis("Vertical");
        // Front
        wheel[0].steerAngle = MaxAngle * angle;
        wheel[1].steerAngle = MaxAngle * angle;
        // end
        if (velocidade() <= MaxVelocity)
        {            
            wheel[2].motorTorque = MaxTorque * torque;
            wheel[3].motorTorque = MaxTorque * torque;
        }
        else
        {
            wheel[2].motorTorque = MaxTorque * 0;
            wheel[3].motorTorque = MaxTorque * 0;
        }

        if (wheel[2].motorTorque == 0)
        {
            wheel[2].brakeTorque = BreakTorque;
            wheel[3].brakeTorque = BreakTorque;
        }
        else
        {
            wheel[2].brakeTorque = 0;
            wheel[3].brakeTorque = 0;
        }
    }

    // mesh rodas
     void meshRender(WheelCollider wheel, Transform roda)
    {
        Vector3 pos;
        Quaternion quaternion;
        wheel.GetWorldPose(out pos, out quaternion);
        roda.transform.position = pos;
        roda.transform.rotation = quaternion;
    }

    public void rodasRender()
    {      
        meshRender(wheel[0], roda[0]);
        meshRender(wheel[1], roda[1]);
        meshRender(wheel[2], roda[2]);
        meshRender(wheel[3], roda[3]);
    }
    // calcular Kmhd
    public int velocidade()
    {
        float speed = 0f;
        int maxVelociade = 0;
        speed = GetRigidbody.velocity.magnitude * 3.6f;
        maxVelociade = Mathf.FloorToInt(speed * 1.2F);
       // Debug.Log("Velociade em KMH: "+maxVelociade);
        return maxVelociade;
    }
}
