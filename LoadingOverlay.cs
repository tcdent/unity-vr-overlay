using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshFilter))]
public class LoadingOverlay : MonoBehaviour {
    private bool fading;
    private float fade_timer;

    public float in_alpha = 1.0f;
    public float out_alpha = 0.0f;

    private Color from_color;
    private Color to_color;
    private Material material;

    void Start(){
        LoadingOverlay.ReverseNormals(this.gameObject);
        this.fading = false;
        this.fade_timer = 0;

        this.material = this.gameObject.GetComponent<Renderer>().material;
        this.from_color = this.material.color;
        this.to_color = this.material.color;
    }
    
    void Update(){
        if(this.fading == false)
            return;

        this.fade_timer += Time.deltaTime;
        this.material.color = Color.Lerp(this.from_color, this.to_color, this.fade_timer);
        if(this.material.color == this.to_color){
            this.fading = false;
            this.fade_timer = 0;
        }
    }

    public void FadeOut(){
        // Fade the overlay to `out_alpha`.
        this.from_color.a = this.in_alpha;
        this.to_color.a = this.out_alpha;
        if(this.to_color != this.material.color){
            this.fading = true;
        }
    }

    public void FadeIn(){
        // Fade the overlay to `in_alpha`.
        this.from_color.a = this.out_alpha;
        this.to_color.a = this.in_alpha;
        if(this.to_color != this.material.color){
            this.fading = true;
        }
    }

    public static void ReverseNormals(GameObject gameObject){
        // Renders interior of the overlay instead of exterior.
        // Included for ease-of-use. 
        // Public so you can use it, too.
        MeshFilter filter = gameObject.GetComponent(typeof(MeshFilter)) as MeshFilter;
        if(filter != null){
            Mesh mesh = filter.mesh;
            Vector3[] normals = mesh.normals;
            for(int i = 0; i < normals.Length; i++)
                normals[i] = -normals[i];
            mesh.normals = normals;

            for(int m = 0; m < mesh.subMeshCount; m++){
                int[] triangles = mesh.GetTriangles(m);
                for(int i = 0; i < triangles.Length; i += 3){
                    int temp = triangles[i + 0];
                    triangles[i + 0] = triangles[i + 1];
                    triangles[i + 1] = temp;
                }
                mesh.SetTriangles(triangles, m);
            }
        }
    }
}
