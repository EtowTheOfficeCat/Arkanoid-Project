using UnityEngine;

public class ShipStateFastShip : ShipStateDefault
{
    public override void OnStateEnter()
    {
        speed = 20f;
        shipSize = shipSize.transform.localScale += new Vector3(10, 10, 10);

    }

    
}
