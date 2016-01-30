Shader "Custom/Wavy" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_MaskTex ("Normal Map", 2D) = "bump" {}
		_stage ("Stage", Range (0, 1)) = 0
		_intensity("Intensity", Range(0,1)) =1
		_maskSize ("Mask Size", Float) = 1
	}
	SubShader {
		Pass {
			CGPROGRAM
			#pragma vertex vert_img
			#pragma fragment frag
 
			#include "UnityCG.cginc"
 
			uniform sampler2D _MainTex;
			uniform sampler2D _MaskTex;
			uniform float _stage;
			uniform float _intensity;
			uniform float _maskSize;
 			
			float4 frag(v2f_img i) : COLOR {
			half2 n = tex2D(_MaskTex, i.uv*_maskSize);
			half2 d = n * 2 -1;
			i.uv += d * _stage;
			i.uv = saturate(i.uv);
		 
			float4 c = tex2D(_MainTex, i.uv);
			float4 result = c;
			//result.rgb = lerp(c.rgb, bw.rgb, _intensity);
			return result;
			}
			ENDCG
		}
	}
	FallBack "Diffuse"

}

