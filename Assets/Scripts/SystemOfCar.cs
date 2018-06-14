using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SystemOfCar : MonoBehaviour {

    [Header("Whell configure")]
    public WheelCollider[] wheel;
    [Header("Mesh Render")]
    public Transform[] roda;
    [Header("Car configure")]
    public int MaxVelocity;
    public float MaxTorque;
    public int MaxAngle;
    public float BreakTorque;
    public float handBrake;
    public Rigidbody rgCar;
    Vector3 startAngulo;
    // System CenterOfMass
    [Header("CenterOfMass")]
    public Transform centerOfMass;
    public float Downforce = 100f;

    [Header("Cuver")]
    private WheelFrictionCurve curve = new WheelFrictionCurve();
    public  float _extremumSlip = 0.2F;
    public  float _extremumValue = 1F;
    public  float _asymptoteSlip = 0.5F;
    public  float _asymptoteValue = 0.75F;
    public  float _stiffness = 1F;
    public float _CurvaMax = 1F;
    public float _CurvaTime = 0.75F;

    private void Start()
    {
        if (rgCar != null)
        {
            rgCar.GetComponent<Rigidbody>();
            rgCar.centerOfMass = centerOfMass.localPosition;
        }
    }

    private void FixedUpdate()
    {
            controle();
            rodasRender();
            velocidade();
            AntRoll();
            Friction();

    }

    // controle do carro
    public void controle()
    {
        float angle = Input.GetAxis("Horizontal");
        // Front
        wheel[0].steerAngle = MaxAngle * angle;
        wheel[1].steerAngle = MaxAngle * angle;
        // end
        if (velocidade() <= MaxVelocity)
        {
            float torque = Input.GetAxis("Vertical");
            wheel[0].motorTorque = MaxTorque * torque;
            wheel[1].motorTorque = MaxTorque * torque;
            wheel[2].motorTorque = MaxTorque * torque;
            wheel[3].motorTorque = MaxTorque * torque;
        }
        else
        {
            wheel[0].motorTorque = 0;
            wheel[1].motorTorque = 0;
            wheel[2].motorTorque = 0;
            wheel[3].motorTorque = 0;
            
        }

        // Freio normal
        wheel[0].brakeTorque = (wheel[0].motorTorque == 0) ? BreakTorque : 0;
        wheel[1].brakeTorque = (wheel[1].motorTorque == 0) ? BreakTorque : 0;
        wheel[2].brakeTorque = (wheel[2].motorTorque == 0) ? BreakTorque : 0;
        wheel[3].brakeTorque = (wheel[3].motorTorque == 0) ? BreakTorque : 0;

        // Freio De mão
        if (Input.GetButton("Jump"))
        {
            Debug.Log("Jump");
            wheel[0].brakeTorque = handBrake;
            wheel[1].brakeTorque = handBrake;
            wheel[2].brakeTorque = handBrake;
            wheel[3].brakeTorque = handBrake;
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
        float speed = 0;
        int speedInt = 0;
        speed = rgCar.velocity.magnitude * 3.6f;
        speedInt = Mathf.FloorToInt(speed);
        return speedInt;
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(Screen.width - 100, 0, 100, 40),"KMH \n"+velocidade().ToString());
    }

    // AntRool
    public void AntRoll()
    {
            wheel[0].attachedRigidbody.centerOfMass = centerOfMass.localPosition;
            wheel[1].attachedRigidbody.centerOfMass = centerOfMass.localPosition;
            wheel[2].attachedRigidbody.centerOfMass = centerOfMass.localPosition;
            wheel[3].attachedRigidbody.centerOfMass = centerOfMass.localPosition;

            wheel[0].attachedRigidbody.AddForce(-transform.up * Downforce * wheel[0].attachedRigidbody.velocity.magnitude);
            wheel[1].attachedRigidbody.AddForce(-transform.up * Downforce * wheel[0].attachedRigidbody.velocity.magnitude);
            wheel[2].attachedRigidbody.AddForce(-transform.up * Downforce * wheel[0].attachedRigidbody.velocity.magnitude);
            wheel[3].attachedRigidbody.AddForce(-transform.up * Downforce * wheel[0].attachedRigidbody.velocity.magnitude);
    }

    public void Friction()
    {
        if (velocidade() <= MaxVelocity/1.3)
        {
            curve.asymptoteSlip = _asymptoteSlip;
            curve.asymptoteValue = _asymptoteValue;
            curve.extremumValue = _extremumValue;
            curve.extremumSlip = _extremumSlip;
            curve.stiffness = _stiffness;
        }
        else if (velocidade() >= MaxVelocity)
        {
            curve.asymptoteSlip = _asymptoteSlip;
            curve.extremumValue = _CurvaMax;
            curve.asymptoteValue = _CurvaTime;
            curve.extremumSlip = _extremumSlip;
            curve.stiffness = _stiffness;
        }
        
        wheel[0].sidewaysFriction = curve;
        wheel[1].sidewaysFriction = curve;
        wheel[2].sidewaysFriction = curve;
        wheel[3].sidewaysFriction = curve;
    }
}
