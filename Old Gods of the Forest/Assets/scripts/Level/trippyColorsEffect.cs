
using UnityEngine;
using System.Collections;


[ExecuteInEditMode]
public class trippyColorsEffect : MonoBehaviour {
		
		public float intensity;
		private Material material;
		private float stage;
		
		
		// Creates a private material used to the effect
		void Awake ()
		{
			//material = new Material( Shader.Find("Hidden/BWDiffuse") );
			material = new Material( Shader.Find("Custom/Trippy") );
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
			float s1 =(Mathf.Sin(stage)+1.0f)/2.0f;
			float c1 = (Mathf.Cos (stage)+1.0f)/2.0f;
			float s2 =(Mathf.Sin(stage*1.3f+Mathf.PI)+1.0f)/2.0f;
			float c2 = (Mathf.Cos (stage*1.3f+Mathf.PI)+1.0f)/2.0f;
			material.SetFloat("_stage", intensity);
			Matrix4x4 colorMatrix= new Matrix4x4();
			colorMatrix.SetRow (0, new Vector4 (s1,c1,s2,0));
			colorMatrix.SetRow (1, new Vector4 (c2,c1,s1,0));
			colorMatrix.SetRow (2, new Vector4 (c2,s1,c1,0));
			colorMatrix.SetRow (3, new Vector4 (0,0,0,1));
			Debug.Log(colorMatrix.ToString ());
			material.SetMatrix ("_mymatrix", colorMatrix);
			Graphics.Blit (source, destination, material);
		}
}
