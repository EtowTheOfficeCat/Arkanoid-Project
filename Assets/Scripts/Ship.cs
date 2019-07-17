using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    //[SerializeField] private float defaultSpeed;
    //public float DefaultSpeed { get => defaultSpeed; }
    private Vector3 startPos;
    [SerializeField] private Transform ballParent;
    public Transform BallParent { get => ballParent; }

    [SerializeField] private Ball ballPrefab;
    public Ball BallPrefab { get => ballPrefab; }

    [SerializeField] private float maxBallAngleOffset = 5f;
    public float MaxBallAngleOffset => maxBallAngleOffset;

    [SerializeField] private float minBallAngleOffset = 0.25f;
    public float MinBallAngleOffset => minBallAngleOffset;

    [SerializeField] private Transform shipMesh;
    public Transform ShipMesh { get => shipMesh; }

    [SerializeField] private Vector3 defaultShipSize = new Vector3(1.5f, 0.4f, 1f);
    public Vector3 DefaultShipSize { get => defaultShipSize; }

    public Ball Ball { get; private set; }
    public ShipState currentState { get; private set; }

void Start()
    {
        startPos = transform.position;
        Ball = GetComponentInChildren<Ball>();
        Ball.Player = this;
        Ball.PlayerTransform = transform;
        SwitchState(new ShipStateDefault());
    }

    void Update()
    {
        currentState.OnUpdate();
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchState(new ShipStateFastShip());
        }

        
        if (Input.GetKeyDown(KeyCode.L))
        {
            SwitchState(new ShipStateExpand());
        }

        
        if (Input.GetKeyDown(KeyCode.S))
        {
            SwitchState(new ShipStateFastBall());
        }

        
        if (Input.GetKeyDown(KeyCode.I))
        {
            SwitchState(new ShipStateInputSwitch());
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SwitchState(new ShipStateMultiBall());
        }
    }

    public void SwitchState(ShipState state)
    {
        currentState?.OnStateExit();
        currentState = state;
        currentState.Ship = this;
        currentState.OnStateEnter();
    }

    public void Reset()
    {
        transform.position = startPos;
        Ball.Reset();
    }
}
