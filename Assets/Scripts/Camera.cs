using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lab1;

public class Camera : MonoBehaviour
{
    [SerializeField]
    Transform dogRoot;
    Dogs[] dogs;
    void Start()
    {
        LoadDogs(dogRoot.childCount);
    }

    void LoadDogs(int count)
    {
        dogs = new Dogs[count];
        for (int i = 0; i < dogRoot.childCount; i++)
        {
            dogs[i] = dogRoot.GetChild(i).GetComponent<Dogs>();
        }
    }

    private void Update()
    {
        foreach (var Dogs in dogs)
        {

        }
    }

}
