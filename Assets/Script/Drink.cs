using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drink : MonoBehaviour
{
    public GameObject[] icons;

    public void UpdateDrink(int drink)
    {
        for(int i = 0; i < icons.Length; i++)
        {
            if (i < drink) icons[i].SetActive(true);
            else icons[i].SetActive(false);
        }
    }
}
