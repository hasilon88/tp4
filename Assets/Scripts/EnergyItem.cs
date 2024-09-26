using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyItem : MonoBehaviour
{
    private SliderModifier energyHealthSlider;
    public Timer timerScript;

    void Start()
    {
        GameObject sliderObject = GameObject.Find("EnergySlider");
        energyHealthSlider = sliderObject.GetComponent<SliderModifier>();

        GameObject textObject = GameObject.Find("TimerText");
        timerScript = textObject.GetComponent<Timer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            Debug.Log("Vous avez trouvé un energy item");
            energyHealthSlider.HealDamage(100);
            timerScript.increaseTimer(30f);

            Destroy(gameObject);
        }
    }
}
