using NUnit.Framework;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyList : MonoBehaviour
{
    public List<GameObject> list = new();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        list.Add(GameObject.FindWithTag("Enemy"));
    }
}
