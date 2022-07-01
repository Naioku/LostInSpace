using System;
using Core;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private Color goodState;
        [SerializeField] private Color warningState;
        [SerializeField] private Color criticalState;
        [SerializeField] private Slider slider;
        [SerializeField] private GameObject sliderFill;

        private void Start()
        {
            slider.maxValue = FindObjectOfType<GameplayData>().PlayerMaxHealth;
        }

        public void SetHealth(int value)
        {
            slider.value = value;
            RefreshSliderColor();
        }

        public void AddHealth(int value)
        {
            slider.value += value;
            RefreshSliderColor();
        }
        
        public void SubtractHealth(int value)
        {
            slider.value -= value;
            RefreshSliderColor();
        }

        private void RefreshSliderColor()
        {
            if (slider.value > 0.5 * FindObjectOfType<GameplayData>().PlayerMaxHealth)
            {
                sliderFill.GetComponent<Image>().color = goodState;
            }
            else if (slider.value > 0.25 * FindObjectOfType<GameplayData>().PlayerMaxHealth)
            {
                sliderFill.GetComponent<Image>().color = warningState;
            }
            else
            {
                sliderFill.GetComponent<Image>().color = criticalState;
            }
        }
    }
}
