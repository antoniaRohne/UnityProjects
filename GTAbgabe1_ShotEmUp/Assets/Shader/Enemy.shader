Shader "MyShaders/Enemy" {
	Properties{
		_Color("Color", Color) = (1,1,1,1)
		_BurnDistance("BurnDistance", Range(0,1)) = 0.3
		_BurnColor("BurnColor", Color) = (1,0,0,1)
		_DissolveFactor("DissolveFactor", Range(0,1)) = 0
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_DissolveTex("Dissolve Tex", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
	}
	SubShader {
		Tags { "RenderType"="Opaque" "Queue" = "Transparent" }
		LOD 200

		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows alpha:blend

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;
		sampler2D _DissolveTex;

		struct Input {
			float2 uv_MainTex;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;
		fixed4 _BurnColor;
		float _BurnDistance;
		float _DissolveFactor;

		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_BUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_BUFFER_END(Props)

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			fixed noise = tex2D(_DissolveTex, IN.uv_MainTex).r;
			float alpha = step(_DissolveFactor, noise);
			float value = smoothstep(noise - _BurnDistance, noise, _DissolveFactor);
			fixed3 color = lerp(c.rgb, _BurnColor.rgb, value);
			o.Albedo = color.rgb;
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = alpha;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
