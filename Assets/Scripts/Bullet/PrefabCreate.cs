using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabCreate : MonoBehaviour
{
    public Transform Spawn;
    public GameObject Prefab;

    public void Create()
    {
        Instantiate(Prefab, Spawn.position, Spawn.rotation);
    }
}
