using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealingItem : MonoBehaviour
{
    private SliderModifier foodHealthSlider;
    public Timer timerScript;

    void Start()
    {
        GameObject sliderObject = GameObject.Find("FoodSlider");
        foodHealthSlider = sliderObject.GetComponent<SliderModifier>();

        GameObject textObject = GameObject.Find("TimerText");
        timerScript = textObject.GetComponent<Timer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            Debug.Log("Vous avez trouvé un healing item");
            foodHealthSlider.HealDamage(100);
            timerScript.increaseTimer(30f);

            Destroy(gameObject);
        }
    }
}
