using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drink2 : MonoBehaviour
{
    public GameObject[] icons;

    public void UpdateDrink(int drink2)
    {
        for (int i = 0; i < icons.Length; i++)
        {
            if (i < drink2) icons[i].SetActive(true);
            else icons[i].SetActive(false);
        }

    }
}
