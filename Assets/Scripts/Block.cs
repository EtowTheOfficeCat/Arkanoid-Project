﻿using System.Collections;
using System;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private Material flashDamageColor = null;
    [SerializeField] private Material originalColor = null;
    [SerializeField] private int health = 1;
    [SerializeField] private int points = 1;
    public static Action<Block> BlockHit;
    public int Points { get => points; }
    private Collider BlockCollider;


    private MeshRenderer meshRenderer = null;
    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        originalColor = meshRenderer.material;
        BlockCollider = GetComponent<Collider>();
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        BlockHit?.Invoke(this);
        if (health > 0)
        {
              health--;
            BlockCollider.enabled = false;
            StartCoroutine(Flash());
            
        }
        else
            BlockCollider.enabled = false;
            StartCoroutine(FlashDie());


    }

    private IEnumerator Flash()
    {
        meshRenderer.material = flashDamageColor;

        WaitForSeconds wait = new WaitForSeconds(0.1f);
        yield return wait;
        if (health == 0)
            Destroy(gameObject);
        meshRenderer.material = originalColor;
    }

    private IEnumerator FlashDie()
    {
        meshRenderer.material = flashDamageColor;

        WaitForSeconds wait = new WaitForSeconds(0.1f);
        yield return wait;
        
            Destroy(gameObject);
        meshRenderer.material = originalColor;
    }


}
