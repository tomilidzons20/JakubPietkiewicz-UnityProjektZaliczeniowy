using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyDrops : MonoBehaviour
{
    [Serializable]
    public class Drops
    {
        public GameObject dropPrefab;
        [Range(0, 100)]
        public int dropChance;
    }

    public List<Drops> drops;

    public void DropPickup()
    {
        List<Drops> possibleDrops = new List<Drops>();
        int chance = UnityEngine.Random.Range(0, 101);
        // Check possibleDrops
        foreach (Drops drop in drops)
        {
            if (chance <= drop.dropChance)
            {
                possibleDrops.Add(drop);
            }
        }
        // Select drop with lowest dropChance and instantiate it
        if (possibleDrops.Count > 0)
        {
            Drops finalDrop = possibleDrops[0];
            foreach (Drops drop in possibleDrops)
            {
                if (drop.dropChance < finalDrop.dropChance)
                {
                    finalDrop = drop;
                }
            }
            Instantiate(finalDrop.dropPrefab, transform.position, transform.rotation);
        }
        
        
    }
}
