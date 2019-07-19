﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private Material flashDamageColor = null;
    [SerializeField] private Material originalColor = null;

    private MeshRenderer meshRenderer = null;
    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        originalColor = meshRenderer.material;
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Game.score++;
        StartCoroutine(Flash());
        
    }

    private IEnumerator Flash()
    {
        meshRenderer.material = flashDamageColor;

        WaitForSeconds wait = new WaitForSeconds(0.1f);
        yield return wait;
        Destroy(gameObject);
        meshRenderer.material = originalColor;
    }

    
}
