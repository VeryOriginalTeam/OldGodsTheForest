Shader "Custom/Trippy" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_stage ("Stage", Range (0, 1)) = 0
	}
	SubShader {
		Pass {
			CGPROGRAM
			#pragma vertex vert_img
			#pragma fragment frag
 
			#include "UnityCG.cginc"
 
			uniform sampler2D _MainTex;
			uniform float _stage;
 			uniform float4x4 _mymatrix;
 			
			float4 frag(v2f_img i) : COLOR {
				float4 c = tex2D(_MainTex, i.uv);
				
				//float lum = c.r*.3 + c.g*.59 + c.b*.11;
				float4 bw = mul(_mymatrix,c); 
				
				float4 result = c;
				result.rgb = lerp(c.rgb, bw.rgb, _stage);
				return result;
			}
			ENDCG
		}
	}
	FallBack "Diffuse"
}
