using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class PostProcessingControl : MonoBehaviour
{
    [SerializeField] PostProcessLayer _mainLayer;
    [SerializeField] PostProcessVolume _mainVolume;
    [SerializeField] PostProcessProfile _mainProfile;

    AmbientOcclusion _ambientOcclusion;
    Bloom _bloom;
    ChromaticAberration _chromaticAberration;
    DepthOfField _depthOfField;
    Grain _grain;
    LensDistortion _lensDistortion;
    MotionBlur _motionBlur;
    Vignette _vignette;

    [SerializeField] GameObject
        fxaaMenu,
        smaaMenu,
        taaMenu,
        aoSettings,
        bloomSettings,
        caSettings,
        grainSettings,
        vignetteSettings;

    enum aaType
    {
        None,
        FXAA,
        SMAA,
        TAA
    }

    // Start is called before the first frame update
    void Awake()
    {
        //fxaaMenu = GameObject.Find("FXAA Settings");
        //smaaMenu = GameObject.Find("SMAA Settings");
        //taaMenu = GameObject.Find("TAA Settings");

        _mainLayer = GetComponent<PostProcessLayer>();
        _mainVolume = GetComponent<PostProcessVolume>();

        _mainVolume.sharedProfile.AddSettings<AmbientOcclusion>();
        _ambientOcclusion = _mainVolume.sharedProfile.GetSetting<AmbientOcclusion>();
        _ambientOcclusion.intensity.overrideState = true;
        _ambientOcclusion.thicknessModifier.overrideState = true;

        _mainVolume.sharedProfile.AddSettings<Bloom>();
        _bloom = _mainVolume.sharedProfile.GetSetting<Bloom>();
        _bloom.intensity.overrideState = true;
        _bloom.fastMode.overrideState = true;

        _mainVolume.sharedProfile.AddSettings<ChromaticAberration>();
        _chromaticAberration = _mainVolume.sharedProfile.GetSetting<ChromaticAberration>();
        _chromaticAberration.intensity.overrideState = true;
        _chromaticAberration.fastMode.overrideState = true;

        _mainVolume.sharedProfile.AddSettings<DepthOfField>();
        _depthOfField = _mainVolume.sharedProfile.GetSetting<DepthOfField>();

        _mainVolume.sharedProfile.AddSettings<Grain>();
        _grain = _mainVolume.sharedProfile.GetSetting<Grain>();
        _grain.colored.overrideState = true;
        _grain.intensity.overrideState = true;
        _grain.size.overrideState = true;

        _mainVolume.sharedProfile.AddSettings<MotionBlur>();
        _motionBlur = _mainVolume.sharedProfile.GetSetting<MotionBlur>();

    }

    // Update is called once per frame
    void Update()
    {
        //_grain.intensity.value = grainIntensity;
    }

    //----------Ambient Occlusion------------//

    public void ToggleAmbientOcclusion(bool clicked)
    {
        aoSettings.SetActive(clicked);
        _ambientOcclusion.enabled.value = clicked;
    }

    public void AdjustAOIntensity(float intensity)
    {
        _ambientOcclusion.intensity.value = intensity;
    }

    public void AdjustAOThickness(float thickness)
    {
        _ambientOcclusion.thicknessModifier.value = thickness;
    }

    //-----------Anti-Aliasing---------------//

    public void AdjustAntiAliasingType(int type)
    {
        switch(type)
        {
            default:
            case 0:
                _mainLayer.antialiasingMode = PostProcessLayer.Antialiasing.None;
                ToggleAASubMenus(aaType.None);
                break;
            case 1:
                _mainLayer.antialiasingMode = PostProcessLayer.Antialiasing.FastApproximateAntialiasing;
                ToggleAASubMenus(aaType.FXAA);
                break;
            case 2:
                _mainLayer.antialiasingMode = PostProcessLayer.Antialiasing.SubpixelMorphologicalAntialiasing;
                ToggleAASubMenus(aaType.SMAA);
                break;
            case 3:
                _mainLayer.antialiasingMode = PostProcessLayer.Antialiasing.TemporalAntialiasing;
                ToggleAASubMenus(aaType.TAA);
                break;
        }
    }

    void ToggleAASubMenus(aaType type)
    {
        switch (type)
        {
            default:
            case aaType.None:
                fxaaMenu.SetActive(false);
                smaaMenu.SetActive(false);
                taaMenu.SetActive(false);
                break;
            case aaType.FXAA:
                fxaaMenu.SetActive(true);
                smaaMenu.SetActive(false);
                taaMenu.SetActive(false);
                break;
            case aaType.SMAA:
                fxaaMenu.SetActive(false);
                smaaMenu.SetActive(true);
                taaMenu.SetActive(false);
                break;
            case aaType.TAA:
                fxaaMenu.SetActive(false);
                smaaMenu.SetActive(false);
                taaMenu.SetActive(true);
                break;
        }
    }

    public void ToggleFXAAFastMode(bool _bool)
    {
        _mainLayer.fastApproximateAntialiasing.fastMode = _bool;
    }

    public void ToggleFXAAKeepAlpha(bool _bool)
    {
        _mainLayer.fastApproximateAntialiasing.keepAlpha = _bool;
    }

    public void SMAAQualityLevel(int level)
    {
        switch (level)
        {
            default:
            case 0:
                _mainLayer.subpixelMorphologicalAntialiasing.quality = SubpixelMorphologicalAntialiasing.Quality.Low;
                break;
            case 1:
                _mainLayer.subpixelMorphologicalAntialiasing.quality = SubpixelMorphologicalAntialiasing.Quality.Medium;
                break;
            case 2:
                _mainLayer.subpixelMorphologicalAntialiasing.quality = SubpixelMorphologicalAntialiasing.Quality.High;
                break;
        }
    }

    public void AdjustTAAJitterSpread(float spread)
    {
        _mainLayer.temporalAntialiasing.jitterSpread = spread;
    }

    public void AdjustTAAStationaryBlending(float blend)
    {
        _mainLayer.temporalAntialiasing.stationaryBlending = blend;
    }

    public void AdjustTAAMotionBlending(float blend)
    {
        _mainLayer.temporalAntialiasing.motionBlending = blend;
    }

    public void AdjustTAASharpness(float sharpness)
    {
        _mainLayer.temporalAntialiasing.sharpness = sharpness;
    }

    //-----------------Bloom-----------------//

    public void ToggleBloom(bool clicked)
    {
        bloomSettings.SetActive(clicked);
        _bloom.enabled.value = clicked;
    }

    public void AdjustBloomIntensity(float intensity)
    {
        _bloom.intensity.value = intensity;
    }

    public void ToggleBloomFastMode(bool _bool)
    {
        _bloom.fastMode.value = _bool;
    }

    //---------Chromatic Aberration----------//

    public void ToggleCA(bool clicked)
    {
        caSettings.SetActive(clicked);
        _chromaticAberration.enabled.value = clicked;
    }

    public void AdjustCAIntensity(float intensity)
    {
        _chromaticAberration.intensity.value = intensity;
    }

    public void ToggleCAFastMode(bool _bool)
    {
        _chromaticAberration.fastMode.value = _bool;
    }

    //------Depth of Field & Motion Blur-----//

    public void ToggleDOF(bool clicked)
    {
        _depthOfField.enabled.value = clicked;
    }

    public void ToggleMotionBlur(bool clicked)
    {
        _motionBlur.enabled.value = clicked;
    }

    //-----------------Grain-----------------//

    public void ToggleGrain(bool clicked)
    {
        grainSettings.SetActive(clicked);
        _grain.enabled.value = clicked;
    }

    public void AdjustGrainColored(bool colored)
    {
        _grain.colored.value = colored;
    }

    public void AdjustGrainIntensity(float intensity)
    {
        _grain.intensity.value = intensity;
    }

    public void AdjustGrainSize(float size)
    {
        _grain.size.value = size;
    }

    //----------------Vignette---------------//

    public void ToggleVignette(bool clicked)
    {
        vignetteSettings.SetActive(clicked);
        _vignette.enabled.value = clicked;
    }

    public void AdjustVignetteIntensity(float intensity)
    {
        _vignette.intensity.value = intensity;
    }

    public void AdjustVignetteSmoothness(float smoothness)
    {
        _vignette.smoothness.value = smoothness;
    }

    public void AdjustVignetteRoundness(float roundness)
    {
        _vignette.roundness.value = roundness;
    }
}