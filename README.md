# Unity VR Overlay
![unity-vr-overlay demo gif](http://33c4d819db899251066f-11ab2606b95aca1e296d8d1ea376f411.r17.cf1.rackcdn.com/tcdent-unity-vr-overlay.gif)

Very simple fade-to-black (and back) overlay system for Virtual Reality applications (Oculus DK2 tested) in Unity 5. Useful as a graceful transition for intial environment loading and level switching.

## Compatibility
References a Shader from the Oculus VR SDK: `"Oculus/Unlit Transparent Color"` found in the `OVR/Moonlight/Resources` folder.

## Usage
Drag the `LoadingOverlay` prefab to your main camera.

Fade in the scene with:

```
LoadingOverlay overlay = GameObject.Find("LoadingOverlay").gameObject.GetComponent<LoadingOverlay>();
overlay.FadeIn();
```

Fade out with:

```
overlay.FadeOut();
```
