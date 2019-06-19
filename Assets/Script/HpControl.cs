using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpControl : MonoBehaviour
{
    public UnityEngine.UI.Slider sliderHP;
    public BoxControl bike;
    public BackControl back;
    public int SLIDER_NUMBER;

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
            if (SLIDER_NUMBER == 0) sliderHP.value = bike.HP / bike.MAX_HP;
            if (SLIDER_NUMBER == 1) sliderHP.value = back.HP / bike.MAX_HP;
            if (SLIDER_NUMBER == 2) sliderHP.value = back.HP / bike.MAX_HP;
        }
    }
}
