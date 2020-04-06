// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/NormalShader" {
	Properties{
			_MainTex("Main Texture", 2D) = "white" {}
		}
	SubShader {
		Tags
			{
				"PreviewType" = "Plane"
				"Queue" = "Transparent"
			}
		Pass
		{
			Blend SrcAlpha OneMinusSrcAlpha
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
            sampler2D _MainTex;
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
				float2 uv : TEXCOORD1;
			};

			v2f vert(appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);//将网格上的局部顶点从一个与网格相关的点，转换成一个屏幕上的点
				o.uv = v.uv; //将获取到的UV传过去
				return o;
			}

			float4 frag(v2f i) : SV_Target
			{
				//float4 color = float4(i.uv.r,i.uv.g,1, 1);
				//return color;
				return tex2D(_MainTex, i.uv);
			}
			ENDCG
		}
	}
	FallBack "Diffuse"
}
