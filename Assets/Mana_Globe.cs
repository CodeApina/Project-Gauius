using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mana_Globe : MonoBehaviour
{
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = GameManager.Instance.character_mana.mana / GameManager.Instance.character_mana.max_mana;
    }
}
