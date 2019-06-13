using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpControl : MonoBehaviour
{
    public UnityEngine.UI.Slider sliderHP;
    public BikeControl bike;

    void Start()
    {
        if (sliderHP != null)
        {
            sliderHP.value = 1.0f;
        }
    }

    void Update()
    {
        if (sliderHP != null)
        {
            sliderHP.value = bike.HP / bike.MAX_HP;
        }
    }
}
