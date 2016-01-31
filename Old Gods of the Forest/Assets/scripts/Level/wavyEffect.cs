
using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class wavyEffect : MonoBehaviour {
	
	public float intensity;
	public Material material;
	private float stage;
	
	
	// Creates a private material used to the effect
	void Awake ()
	{
		//material = new Material( Shader.Find("Hidden/BWDiffuse") );
		//material = new Material( Shader.Find("Custom/Wavy") );
		stage = 0.0f;
	}
	
	// Postprocess the image
	void OnRenderImage (RenderTexture source, RenderTexture destination)
	{
		stage += 0.02f;
		if (intensity == 0)
		{
			Graphics.Blit (source, destination);
			return;
		}

		material.SetFloat("_intensity", intensity);
		material.SetFloat ("_stage",Mathf.Sin(stage)*0.02f);
		material.SetFloat ("_maskSize",0.20f);

		Graphics.Blit (source, destination, material);
	}
}