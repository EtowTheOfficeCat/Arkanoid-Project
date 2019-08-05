using System.IO;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float xGap = 1;
    [SerializeField] private float yGap = 1;
    [SerializeField] private Block[] blockPrefabs;
    private StreamReader sr;
    List<int[]> blocks = new List<int[]>(6);

    
    void Start()
    {
        ReadFile();
        Spawn();
    }

    void ReadFile()
    {
        using (StreamReader reader = new StreamReader($"{Application.streamingAssetsPath}/Levels/Level1.txt"))
        {
            string line = "";
            while ((line = reader.ReadLine()) != null)
            {
                string[] tokens = line.Split(' ');
                int[] blockRow = Array.ConvertAll<string, int>(tokens, int.Parse);
                blocks.Add(blockRow);
            }
        }
    }

   private void Spawn()
    {
        for (int y = 0; y < blocks.Count; y++)
        {
            for( int x = 0; x < blocks[y].Length; x++)
            {
                
                int prefabIdx = blocks[y][x];
                Block block = Instantiate<Block>(blockPrefabs[prefabIdx], transform);
                block.transform.localPosition = new Vector3(x * xGap, -y * yGap, 0f); 

            }
        }
    }
}
