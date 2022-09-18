using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSelector : MonoBehaviour
{
    [SerializeField]
    private List<NPC> npcs;
    public NPC SelectNPC()
    {
        int random = Random.Range(0, npcs.Count);
        NPC selectedNpc = npcs[random];
        npcs.RemoveAt(random);
        return selectedNpc;
    }

    //Dummy class
    public bool IsLast()
    {
        return false;
    }
}
