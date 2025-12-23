using UnityEngine;
using UnityEngine.UI;

public class SliderValueReader : MonoBehaviour
{
    public Slider slider;
    void Update()
    {
        ShimoDB.Instance.setkoudo(slider.value);
    }
}