using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LeafGroupsController : MonoBehaviour
{
    public List<GameObject> leafGroups;
    public void EnableGroup(int groupIndex)
    {
        leafGroups[groupIndex].SetActive(true);
        if(groupIndex > 1)
        {
            leafGroups[groupIndex - 2].SetActive(false);
        }
    }
}
