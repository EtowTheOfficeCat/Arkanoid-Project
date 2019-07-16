using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] private float defaultSpeed;
    public float DefaultSpeed { get => defaultSpeed; }

    [SerializeField] private Transform defaultShipSize;
    public Transform DefaultShipSize { get => defaultShipSize; }

    public Ball Ball { get; private set; }
    public ShipState currentState { get; private set; }

void Start()
    {
        Ball = GetComponentInChildren<Ball>();
        SwitchState(new ShipStateDefault());
        
        
    }

    void Update()
    {
        currentState.OnUpdate();
        if (Input.GetKeyDown(KeyCode.F))
        {
            SwitchState(new ShipStateFastShip());
        }
    }

    public void SwitchState(ShipState state)
    {
        currentState?.OnStateExit();
        currentState = state;
        currentState.Ship = this;
        currentState.OnStateEnter();
    }

}
