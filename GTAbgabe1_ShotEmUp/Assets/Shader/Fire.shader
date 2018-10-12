Shader "MyShaders/Fire"
{
	Properties
	{
		_MainTex ("Driver Texture", 2D) = "white" {}
		_ColorRampTex ("Color Texture", 2D) = "red" {}
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" "Queue"= "Transparent" }
		Blend One One
		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			sampler2D _ColorRampTex;
			float4 _MainTex_ST;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				fixed4 driver1 = tex2D(_MainTex, i.uv*float2(_Time.x, _Time.x))*float4(2,2,2,2);
				fixed4 driver2 = tex2D(_MainTex, i.uv*float2(-_Time.x, -_Time.x))*float4(2,2,2,2);

				float calcU = saturate((driver1.r+driver2.r)/2.0);

				return tex2D(_ColorRampTex, float2(calcU, 0.5));
			}
			ENDCG
		}
	}
}
