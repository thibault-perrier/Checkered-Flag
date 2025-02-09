using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CarController : MonoBehaviour
{
    public enum CarType
    {
        Player,
        AI
    }

    public enum Axle
    {
        Front,
        Rear
    }

    [Serializable]
    public struct Wheel
    {
        public GameObject WheelModel;
        public WheelCollider WheelColl;
        public Axle Axle;
    }

    public CarType carType;

    [SerializeField] private float maxAcceleration = 30.0f;
    [SerializeField] private float _breakAcceleration = 50.0f;
    [SerializeField] private float _steeringSensitivity = 1.0f;
    [SerializeField] private float _maxSteeringAngle = 30.0f;

    [SerializeField] private List<Wheel> _wheels = new();

    [HideInInspector] public float MoveInput = 0.0f;
    [HideInInspector] public float SteerInput = 0.0f;

    [SerializeField] private Vector3 _centerOfMass = new Vector3(0, -10.0f, 0);

    private Rigidbody _carRb;

    // float zRotationLimit = 20.0f;


    void Start()
    {
        _carRb = GetComponent<Rigidbody>();
        _carRb.centerOfMass = _centerOfMass;
    }

    void LateUpdate()
    {
        Move();
        Steer();
    }

    private void Move()
    {
        foreach (Wheel wheel in _wheels)
        {
            wheel.WheelColl.motorTorque = MoveInput * 450 * maxAcceleration * Time.deltaTime;
        }
    }

    private void Steer()
    {
        foreach (Wheel wheel in _wheels)
        {
            if (wheel.Axle == Axle.Front)
            {
                var steerAngle = SteerInput * _steeringSensitivity * _maxSteeringAngle;
                wheel.WheelColl.steerAngle = Mathf.Lerp(wheel.WheelColl.steerAngle, steerAngle, 0.1f);
            }
        }

        // transform.rotation = new Quaternion
        // (
        //     transform.rotation.x,
        //     transform.rotation.y,
        //     Mathf.Clamp(transform.rotation.eulerAngles.z, -zRotationLimit, zRotationLimit),
        //     transform.rotation.w
        // );
    }
}
