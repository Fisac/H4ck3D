// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/Wireframe" {
	Properties{
		_ColorFill("Fill Color", Color) = (0,0,0,1)
		_ColorWire("Wire Color", Color) = (1,1,1,1)
		_Offset("Wire Offset", Range(0,0.5)) = 0.455
	}
		SubShader{
			Tags { "RenderType" = "Transparent" }
			ZWrite ON
			Blend SrcAlpha OneMinusSrcAlpha

			Pass{
			CGPROGRAM

		#pragma vertex vert
		#pragma fragment frag

#include "UnityCG.cginc"
		uniform float4 _ColorFill; 
		uniform float4 _ColorWire; 
		uniform float _Offset;

	struct vertexInput {
		float4 vertex : POSITION;
		float4 uv : TEXCOORD0;
		float4 color : COLOR;
	};

	struct fragmentInput {
		float4 position : SV_POSITION;
		float4 uv : TEXCOORD0;
		float4 color:COLOR;
	};

	fragmentInput vert(vertexInput i) {
		fragmentInput o;
		o.position = UnityObjectToClipPos(i.vertex);

		o.uv = i.uv;
		o.color = i.color;

		return o;
	}

	fixed4 frag(fragmentInput i) : SV_TARGET{

				float4 c;
				float coord = step(_Offset, abs(i.uv.x - 0.5)) || step(_Offset, abs(i.uv.y - 0.5));

				c = lerp(_ColorFill, _ColorWire, coord * _ColorWire.a);


				return c;
	}
	ENDCG
			}
		}
	}
