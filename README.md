# Unity VR Overlay
Very simple fade-to-black (and back) overlay system for Virtual Reality applications (Oculus DK2 tested) in Unity 5. Useful as a graceful transition for intial environment loading and level switching.

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
