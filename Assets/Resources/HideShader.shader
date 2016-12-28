Shader "Custom/PositionBasedTransparency" {
	Properties{
		_MainTex("Base (RGB)", 2D) = "black" {}
	_LeftLimit("Left Limit: World Pos X", Float) = -2.0
		_RightLimit("Right Limit: World Pos X", Float) = 2.0
		_TopLimit("Top Limit: World Pos Y", Float) = -2.0
		_BottomLimit("Bottom Limit: World Pos Y", Float) = 2.0
		_ColorTint ("Tint", Color) = (1.0, 0.6, 0.6, 1.0)
	}
		SubShader{
		Lighting Off
		AlphaTest Greater 0.5

		Tags{
		"Queue" = "Transparent"
		"IgnoreProjector" = "True"
		"RenderType" = "Transparent"
		"PreviewType" = "Plane"
		"CanUseSpriteAtlas" = "True"
	}

		Cull Off
		Lighting Off
		ZWrite Off
		Fog{ Mode Off }
		Blend One OneMinusSrcAlpha
		LOD 200

		CGPROGRAM
#pragma surface surf NoLighting
#include "UnityCG.cginc"

		fixed4 LightingNoLighting(SurfaceOutput s, fixed3 lightDir, fixed atten) {
		fixed4 c;
		c.rgb = s.Albedo;
		c.a = s.Alpha;
		return c;
	}

	sampler2D _MainTex;
	float _LeftLimit;
	float _RightLimit;
	float _TopLimit;
	float _BottomLimit;
	fixed4 _ColorTint;

	struct Input {
		float2 uv_MainTex;
		float3 worldPos;
	};

	void surf(Input IN, inout SurfaceOutput o) {
		// clip will not display the current pixel when the argument passed has a non positive value
		if (IN.worldPos.x - _LeftLimit < 0 || _RightLimit - IN.worldPos.x < 0 ||
			IN.worldPos.y - _TopLimit < 0 || _BottomLimit - IN.worldPos.y < 0) {
			clip(-1.0);
		}

		half4 c = tex2D(_MainTex, IN.uv_MainTex);
		o.Albedo = c.rgb * _ColorTint.rgb;
		o.Alpha = _ColorTint.rgb;
	}
	ENDCG
	}
		FallBack "Diffuse"
}
