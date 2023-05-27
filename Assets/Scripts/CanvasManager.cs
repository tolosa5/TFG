using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] Slider slider;

    void Update()
    {
        float fuelValue = PlayerController.instance.currentFuel;
        slider.value = fuelValue;
    }
}
