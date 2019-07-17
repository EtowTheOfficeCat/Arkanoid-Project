using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShipStateDefault : ShipState
{
    protected float Ballspeed;
    protected float xInput;
    protected float speed = 5f;
    protected float inputMultiplier = 1f;
    
    public override Vector3 Velocity { get; protected set; }

    public override void OnStateEnter()
    {
        
    }

    public override void OnStateExit()
    {
        
    }

    public override void OnUpdate()
    {
        Movement();
        ShootBall();
    }

    private void Movement()
    {
        xInput = Input.GetAxis("Horizontal");
        Vector3 newPos = Ship.transform.position;

        Velocity = inputMultiplier * xInput * Time.deltaTime * speed * Vector3.right;
        newPos += Velocity;

        if (newPos.x < -4)
        {
            newPos = new Vector3(-4f, Ship.transform.position.y, Ship.transform.position.z);

        }

        else if (newPos.x > 4)
        {
            newPos = new Vector3(4f, Ship.transform.position.y, Ship.transform.position.z);

        }
        Ship.transform.position = newPos;
    }

    private void ShootBall()
    {

        if (Input.GetKeyDown(KeyCode.W))
        {
            Ship.Ball.Shoot(Ship.MinBallAngleOffset, Ship.MaxBallAngleOffset);
        }


    }
}
