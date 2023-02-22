using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
// using UnityEngine.Rendering;
// using UnityEngine.Rendering.Universal;

public class BloomEffectTestScr : MonoBehaviour
{
    //public PostProcessVolume volume;
 
    // public PostProcessVolume volume;
    // public float BloomIntensityValue;
    // public Slider BloomIntensitySlider;
 
    // public float BloomDiffusionValue;
    // public Slider BloomDiffusionSlider;
    // public void Update()
    // {
    //     ChangeBloomIntensitySettings();
    //     BloomIntensityValue = BloomIntensitySlider.value * 20;
 
    //     ChangeBloomDiffusionSettings();
    //     BloomDiffusionValue = BloomDiffusionSlider.value * 10;
    // }
    // public void ChangeBloomIntensitySettings()
    // {
    //     GameObject gameObject = GameObject.Find("Coloured Cubes");
    //     volume = gameObject.GetComponent<PostProcessVolume>();
    //     Bloom bloom;
    //     volume.profile.TryGetSettings(out bloom);
    //     bloom.intensity.value = BloomIntensityValue;
    // }
    // public void ChangeBloomDiffusionSettings()
    // {
    //     GameObject gameObject = GameObject.Find("Coloured Cubes");
    //     volume = gameObject.GetComponent<PostProcessVolume>();
    //     Bloom bloom;
    //     volume.profile.TryGetSettings(out bloom);
    //     bloom.diffusion.value = BloomDiffusionValue;
    // }


    public PostProcessVolume volume;
    private Vignette _Vignette;
    private Bloom _Bloom;

    void Start() 
    {
        volume.profile.TryGetSettings(out _Bloom);
        volume.profile.TryGetSettings(out _Vignette);

        _Bloom.intensity.value = 0;
        _Vignette.intensity.value = 0;


    void Update()
    {
        _Bloom.intensity.value = Mathf.Lerp(_Bloom.intensity.value, 15, .5f * Time.deltaTime);
        _Vignette.intensity.value = Mathf.Lerp(_Vignette.intensity.value, 15, .5f * Time.deltaTime);
    }

    }
}
