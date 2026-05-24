using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchiveManager : MonoBehaviour
{
    public int totalArchives;        // Total number in the level
    private int collectedArchives = 0;

    public static ArchiveManager instance;

    void Awake()
    {
        instance = this;
    }

    public void CollectArchive()
    {
        collectedArchives++;

        Debug.Log("Archives Collected: " + collectedArchives + "/" + totalArchives);

        if (collectedArchives >= totalArchives)
        {
            WinGame();
        }
    }

    void WinGame()
    {
        Debug.Log("YOU WIN! All archives collected!");
        // You can add UI, scene change, etc. here
    }
}
