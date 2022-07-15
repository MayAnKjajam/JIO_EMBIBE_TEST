using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene4Manager : MonoBehaviour
{
    public GameObject Needle;
    public Slider slider;
    public float StartLocalRotation, EndLocalRotatoion;

    private void OnEnable()
    {
        slider.value = float.MinValue;
        slider.onValueChanged.AddListener(delegate { needleDeflection(); });
    }
    // Update is called once per frame

    public void needleDeflection()
    {
        Needle.transform.localRotation = Quaternion.Euler(0, StartLocalRotation + ((EndLocalRotatoion-StartLocalRotation) / 3f * slider.value),-90);
    }
}
