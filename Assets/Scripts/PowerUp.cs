using System;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public static Action<PU> PUCollected;
    public static Action PUDestroyed;
    [SerializeField] private PU puType;
    public PU PUType { get => puType; }

   

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ship"))
        {
            PUCollected?.Invoke(puType);
        }
        else
        {
         Destroy(gameObject);
        }
        
    }

    public void OnNewShip()
    {
        PUDestroyed?.Invoke();
        Destroy(gameObject);
    }
}

public enum PU { None, Expand, Fastship, Multiball }
