using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTableManager : MonoBehaviour
{

    [Range(0, 1)]
    public float GoldDropChance = 0.5f;
    public float GoldDropAmount = 10.0f;

    [Range(0, 1)]
    public float ItemDropChance = 0.25f;

    [System.Serializable]
    public struct DropTableEntry
    {
        public GameObject Item;
        public float DropChance;
    }

    [Header("Drop Table")]
    public DropTableEntry[] DropTable;

    public void DropItem()
    {
        float RandNum = Random.Range(0.0f, 1.0f);
        if (DropTable != null && RandNum <= ItemDropChance)
        {
            float CumulativeChance = 0.0f;
            RandNum = Random.Range(0.0f, 1.0f);
            foreach (DropTableEntry it in DropTable)
            {
                CumulativeChance += it.DropChance;
                if (RandNum <= CumulativeChance)
                {
                    Instantiate(it.Item);
                }
            }
        }
    }
}
