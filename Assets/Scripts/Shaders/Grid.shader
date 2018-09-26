Shader "Custom/Grid"
{
	Properties{
		_GridThickness("Grid Thickness", Float) = 0.01
		_GridSpacingX("Grid Spacing X", Float) = 1.0
		_GridSpacingZ("Grid Spacing Z", Float) = 1.0
		_GridOffsetX("Grid Offset X", Float) = 0
		_GridOffsetZ("Grid Offset Z", Float) = 0
		_GridColor("Grid Color", Color) = (0.5, 1.0, 1.0, 1.0)
		_BaseColor("Base Color", Color) = (0.0, 0.0, 0.0, 0.0)
		//_Emission("Intensity", Range(0,5)) = 1
	}

		SubShader{
			Tags{"Queue" = "Transparent"
				"IgnoreProjector" = "True"
				"RenderType" = "Transparent"}

			Pass{
				ZWrite Off
				Blend SrcAlpha OneMinusSrcAlpha

				CGPROGRAM

			#pragma vertex vert
			#pragma fragment frag

			uniform float _GridThickness;
			uniform float _GridSpacingX;
			uniform float _GridSpacingZ;
			uniform float _GridOffsetX;
			uniform float _GridOffsetZ;
			uniform float4 _GridColor; 
			uniform float4 _BaseColor; 
			uniform half _Emission;

			struct vertexInput {
				float4 vertex : POSITION;
			};

			struct vertexOutput {
				float4 pos : SV_POSITION;
				float4 worldPos : TEXCOORD0;
			};

			vertexOutput vert(vertexInput input) {
				vertexOutput output; 
				output.pos = UnityObjectToClipPos(input.vertex);
				output.worldPos = mul(unity_ObjectToWorld, input.vertex);
				return output; 
			}

			float4 frag(vertexOutput input) : COLOR{
				if (frac((input.worldPos.x + _GridOffsetX) / _GridSpacingX) < (_GridThickness / _GridSpacingX)
				|| frac((input.worldPos.z + _GridOffsetZ) / _GridSpacingZ) < (_GridThickness / _GridSpacingZ))
				{
					//return _GridColor * _Emission; 
					return _GridColor; 
				}
				else {

					return _BaseColor;
				}
			}
			ENDCG
		}
	}
}
