﻿Shader "Cutom/Hologram_ZWrite"
{
	Properties
	{
		[HDR]Color_219146F1("Hologram Color", Color) = (0.6,0.7475444,0.8784314,0)
		[NoScaleOffset] Texture2D_42C67CC("Hologram Texture", 2D) = "white" {}
	Vector2_547A76F1("Hologram Texture Tiling", Vector) = (1,3,0,0)
		Vector1_285C77C0("Hologram Speed", Float) = 0.1
		[HDR]Color_96DBF111("Glow Color", Color) = (0,17.56863,23.96863,0)

	}
		SubShader
	{
		Tags{ "RenderPipeline" = "LightweightPipeline" }
		Tags
	{
		"RenderPipeline" = "HDRenderPipeline"
		"RenderType" = "Transparent"
		"Queue" = "Transparent + 4000"
	}
		Pass
	{
		Tags{ "LightMode" = "LightweightForward" }

		// Material options generated by graph

		Blend SrcAlpha OneMinusSrcAlpha

		Cull Back

		ZTest LEqual

		ZWrite Off

		LOD 300

		HLSLPROGRAM
		// Required to compile gles 2.0 with standard srp library
#pragma prefer_hlslcc gles
#pragma exclude_renderers d3d11_9x
#pragma target 2.0

		// -------------------------------------
		// Lightweight Pipeline keywords
#pragma multi_compile _ _ADDITIONAL_LIGHTS
#pragma multi_compile _ _VERTEX_LIGHTS
#pragma multi_compile _ _MIXED_LIGHTING_SUBTRACTIVE
#pragma multi_compile _ _SHADOWS_ENABLED
#pragma multi_compile _ _LOCAL_SHADOWS_ENABLED
#pragma multi_compile _ _SHADOWS_SOFT
#pragma multi_compile _ _SHADOWS_CASCADE

		// -------------------------------------
		// Unity defined keywords
#pragma multi_compile _ DIRLIGHTMAP_COMBINED
#pragma multi_compile _ LIGHTMAP_ON
#pragma multi_compile_fog

		//--------------------------------------
		// GPU Instancing
#pragma multi_compile_instancing

#pragma vertex vert
#pragma fragment frag

		// Defines generated by graph
#define _SPECULAR_SETUP 1
#define _AlphaClip 1

#include "LWRP/ShaderLibrary/Core.hlsl"
#include "LWRP/ShaderLibrary/Lighting.hlsl"
#include "CoreRP/ShaderLibrary/Color.hlsl"
#include "CoreRP/ShaderLibrary/UnityInstancing.hlsl"
#include "ShaderGraphLibrary/Functions.hlsl"

		float4 Color_219146F1;
	TEXTURE2D(Texture2D_42C67CC); SAMPLER(samplerTexture2D_42C67CC);
	float2 Vector2_547A76F1;
	float Vector1_285C77C0;
	float4 Color_96DBF111;

	struct VertexDescriptionInputs
	{
		float3 ObjectSpacePosition;
	};

	struct SurfaceDescriptionInputs
	{
		float3 WorldSpaceNormal;
		float3 TangentSpaceNormal;
		float3 WorldSpaceViewDirection;
		float3 WorldSpacePosition;
		float4 ScreenPosition;
	};


	void Unity_FresnelEffect_float(float3 Normal, float3 ViewDir, float Power, out float Out)
	{
		Out = pow((1.0 - saturate(dot(normalize(Normal), normalize(ViewDir)))), Power);
	}

	void Unity_Multiply_float(float4 A, float4 B, out float4 Out)
	{
		Out = A * B;
	}

	void Unity_Multiply_float(float A, float B, out float Out)
	{
		Out = A * B;
	}

	void Unity_TilingAndOffset_float(float2 UV, float2 Tiling, float2 Offset, out float2 Out)
	{
		Out = UV * Tiling + Offset;
	}

	void Unity_Dither_float(float In, float4 ScreenPosition, out float Out)
	{
		float2 uv = ScreenPosition.xy * _ScreenParams.xy;
		float DITHER_THRESHOLDS[16] =
		{
			1.0 / 17.0,  9.0 / 17.0,  3.0 / 17.0, 11.0 / 17.0,
			13.0 / 17.0,  5.0 / 17.0, 15.0 / 17.0,  7.0 / 17.0,
			4.0 / 17.0, 12.0 / 17.0,  2.0 / 17.0, 10.0 / 17.0,
			16.0 / 17.0,  8.0 / 17.0, 14.0 / 17.0,  6.0 / 17.0
		};
		uint index = (uint(uv.x) % 4) * 4 + uint(uv.y) % 4;
		Out = In - DITHER_THRESHOLDS[index];
	}

	struct VertexDescription
	{
		float3 Position;
	};

	VertexDescription PopulateVertexData(VertexDescriptionInputs IN)
	{
		VertexDescription description = (VertexDescription)0;
		description.Position = IN.ObjectSpacePosition;
		return description;
	}

	struct SurfaceDescription
	{
		float3 Albedo;
		float3 Normal;
		float3 Emission;
		float3 Specular;
		float Smoothness;
		float Occlusion;
		float Alpha;
		float AlphaClipThreshold;
	};

	SurfaceDescription PopulateSurfaceData(SurfaceDescriptionInputs IN)
	{
		SurfaceDescription surface = (SurfaceDescription)0;
		float4 _Property_380878B_Out = Color_219146F1;
		float _FresnelEffect_91EBFD4D_Out;
		Unity_FresnelEffect_float(IN.WorldSpaceNormal, IN.WorldSpaceViewDirection, 0, _FresnelEffect_91EBFD4D_Out);
		float4 _Property_5257AAE4_Out = Color_96DBF111;
		float4 _Multiply_98CF0584_Out;
		Unity_Multiply_float((_FresnelEffect_91EBFD4D_Out.xxxx), _Property_5257AAE4_Out, _Multiply_98CF0584_Out);

		float4 _Multiply_B765B2A5_Out;
		Unity_Multiply_float(_Multiply_98CF0584_Out, float4(30, 2, 2, 2), _Multiply_B765B2A5_Out);

		float2 _Property_1347FC40_Out = Vector2_547A76F1;
		float _Property_1F614DB0_Out = Vector1_285C77C0;
		float _Multiply_D0306581_Out;
		Unity_Multiply_float(_Time.y, _Property_1F614DB0_Out, _Multiply_D0306581_Out);

		float2 _TilingAndOffset_88FF1AA_Out;
		Unity_TilingAndOffset_float((IN.WorldSpacePosition.xy), _Property_1347FC40_Out, (_Multiply_D0306581_Out.xx), _TilingAndOffset_88FF1AA_Out);
		float4 _SampleTexture2D_BF018FCD_RGBA = SAMPLE_TEXTURE2D(Texture2D_42C67CC, samplerTexture2D_42C67CC, _TilingAndOffset_88FF1AA_Out);
		float _SampleTexture2D_BF018FCD_R = _SampleTexture2D_BF018FCD_RGBA.r;
		float _SampleTexture2D_BF018FCD_G = _SampleTexture2D_BF018FCD_RGBA.g;
		float _SampleTexture2D_BF018FCD_B = _SampleTexture2D_BF018FCD_RGBA.b;
		float _SampleTexture2D_BF018FCD_A = _SampleTexture2D_BF018FCD_RGBA.a;
		float _Dither_6D84544E_Out;
		Unity_Dither_float(0, IN.ScreenPosition, _Dither_6D84544E_Out);
		surface.Albedo = (_Property_380878B_Out.xyz);
		surface.Normal = IN.TangentSpaceNormal;
		surface.Emission = (_Multiply_B765B2A5_Out.xyz);
		surface.Specular = IsGammaSpace() ? float3(0.5, 0.5, 0.5) : SRGBToLinear(float3(0.5, 0.5, 0.5));
		surface.Smoothness = 0.5;
		surface.Occlusion = 1;
		surface.Alpha = (_SampleTexture2D_BF018FCD_RGBA).x;
		surface.AlphaClipThreshold = _Dither_6D84544E_Out;
		return surface;
	}

	struct GraphVertexInput
	{
		float4 vertex : POSITION;
		float3 normal : NORMAL;
		float4 tangent : TANGENT;
		float4 texcoord1 : TEXCOORD1;
		UNITY_VERTEX_INPUT_INSTANCE_ID
	};


	struct GraphVertexOutput
	{
		float4 clipPos                : SV_POSITION;
		DECLARE_LIGHTMAP_OR_SH(lightmapUV, vertexSH, 0);
		half4 fogFactorAndVertexLight : TEXCOORD1; // x: fogFactor, yzw: vertex light
		float4 shadowCoord            : TEXCOORD2;

		// Interpolators defined by graph
		float3 WorldSpacePosition : TEXCOORD3;
		float3 WorldSpaceNormal : TEXCOORD4;
		float3 WorldSpaceTangent : TEXCOORD5;
		float3 WorldSpaceBiTangent : TEXCOORD6;
		float3 WorldSpaceViewDirection : TEXCOORD7;
		float4 ScreenPosition : TEXCOORD8;
		half4 uv1 : TEXCOORD9;

		UNITY_VERTEX_INPUT_INSTANCE_ID
			UNITY_VERTEX_OUTPUT_STEREO
	};

	GraphVertexOutput vert(GraphVertexInput v)
	{
		GraphVertexOutput o = (GraphVertexOutput)0;
		UNITY_SETUP_INSTANCE_ID(v);
		UNITY_TRANSFER_INSTANCE_ID(v, o);
		UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);

		// Vertex transformations performed by graph
		float3 WorldSpacePosition = mul(UNITY_MATRIX_M,v.vertex);
		float3 WorldSpaceNormal = mul(v.normal,(float3x3)UNITY_MATRIX_I_M);
		float3 WorldSpaceTangent = mul((float3x3)UNITY_MATRIX_M,v.tangent.xyz);
		float3 WorldSpaceBiTangent = normalize(cross(WorldSpaceNormal, WorldSpaceTangent.xyz) * v.tangent.w);
		float3 WorldSpaceViewDirection = SafeNormalize(_WorldSpaceCameraPos.xyz - mul(GetObjectToWorldMatrix(), float4(v.vertex.xyz, 1.0)).xyz);
		float4 ScreenPosition = ComputeScreenPos(mul(GetWorldToHClipMatrix(), mul(GetObjectToWorldMatrix(), v.vertex)), _ProjectionParams.x);
		float4 uv1 = v.texcoord1;
		float3 ObjectSpacePosition = mul(UNITY_MATRIX_I_M,float4(WorldSpacePosition,1.0));

		VertexDescriptionInputs vdi = (VertexDescriptionInputs)0;

		// Vertex description inputs defined by graph
		vdi.ObjectSpacePosition = ObjectSpacePosition;

		VertexDescription vd = PopulateVertexData(vdi);
		v.vertex.xyz = vd.Position;

		// Vertex shader outputs defined by graph
		o.WorldSpacePosition = WorldSpacePosition;
		o.WorldSpaceNormal = WorldSpaceNormal;
		o.WorldSpaceTangent = WorldSpaceTangent;
		o.WorldSpaceBiTangent = WorldSpaceBiTangent;
		o.WorldSpaceViewDirection = WorldSpaceViewDirection;
		o.ScreenPosition = ScreenPosition;
		o.uv1 = uv1;

		float3 lwWNormal = TransformObjectToWorldNormal(v.normal);
		float3 lwWorldPos = TransformObjectToWorld(v.vertex.xyz);
		float4 clipPos = TransformWorldToHClip(lwWorldPos);

		// We either sample GI from lightmap or SH.
		// Lightmap UV and vertex SH coefficients use the same interpolator ("float2 lightmapUV" for lightmap or "half3 vertexSH" for SH)
		// see DECLARE_LIGHTMAP_OR_SH macro.
		// The following funcions initialize the correct variable with correct data
		OUTPUT_LIGHTMAP_UV(v.texcoord1, unity_LightmapST, o.lightmapUV);
		OUTPUT_SH(lwWNormal, o.vertexSH);

		half3 vertexLight = VertexLighting(lwWorldPos, lwWNormal);
		half fogFactor = ComputeFogFactor(clipPos.z);
		o.fogFactorAndVertexLight = half4(fogFactor, vertexLight);
		o.clipPos = clipPos;

#ifdef _SHADOWS_ENABLED
#if SHADOWS_SCREEN
		o.shadowCoord = ComputeShadowCoord(clipPos);
#else
		o.shadowCoord = TransformWorldToShadowCoord(lwWorldPos);
#endif
#endif
		return o;
	}

	half4 frag(GraphVertexOutput IN) : SV_Target
	{
		UNITY_SETUP_INSTANCE_ID(IN);

	// Pixel transformations performed by graph
	float3 WorldSpacePosition = IN.WorldSpacePosition;
	float3 WorldSpaceNormal = normalize(IN.WorldSpaceNormal);
	float3 WorldSpaceTangent = IN.WorldSpaceTangent;
	float3 WorldSpaceBiTangent = IN.WorldSpaceBiTangent;
	float3 WorldSpaceViewDirection = normalize(IN.WorldSpaceViewDirection);
	float3x3 tangentSpaceTransform = float3x3(WorldSpaceTangent,WorldSpaceBiTangent,WorldSpaceNormal);
	float4 ScreenPosition = IN.ScreenPosition;
	float4 uv1 = IN.uv1;
	float3 TangentSpaceNormal = mul(WorldSpaceNormal,(float3x3)tangentSpaceTransform);

	SurfaceDescriptionInputs surfaceInput = (SurfaceDescriptionInputs)0;

	// Surface description inputs defined by graph
	surfaceInput.WorldSpaceNormal = WorldSpaceNormal;
	surfaceInput.TangentSpaceNormal = TangentSpaceNormal;
	surfaceInput.WorldSpaceViewDirection = WorldSpaceViewDirection;
	surfaceInput.WorldSpacePosition = WorldSpacePosition;
	surfaceInput.ScreenPosition = ScreenPosition;

	SurfaceDescription surf = PopulateSurfaceData(surfaceInput);

	float3 Albedo = float3(0.5, 0.5, 0.5);
	float3 Specular = float3(0, 0, 0);
	float Metallic = 1;
	float3 Normal = float3(0, 0, 1);
	float3 Emission = 0;
	float Smoothness = 0.5;
	float Occlusion = 1;
	float Alpha = 1;
	float AlphaClipThreshold = 0;

	// Surface description remap performed by graph
	Albedo = surf.Albedo;
	Normal = surf.Normal;
	Emission = surf.Emission;
	Specular = surf.Specular;
	Smoothness = surf.Smoothness;
	Occlusion = surf.Occlusion;
	Alpha = surf.Alpha;
	AlphaClipThreshold = surf.AlphaClipThreshold;

	InputData inputData;
	inputData.positionWS = WorldSpacePosition;

#ifdef _NORMALMAP
	inputData.normalWS = TangentToWorldNormal(Normal, WorldSpaceTangent, WorldSpaceBiTangent, WorldSpaceNormal);
#else
#if !SHADER_HINT_NICE_QUALITY
	inputData.normalWS = WorldSpaceNormal;
#else
	inputData.normalWS = normalize(WorldSpaceNormal);
#endif
#endif

#if !SHADER_HINT_NICE_QUALITY
	// viewDirection should be normalized here, but we avoid doing it as it's close enough and we save some ALU.
	inputData.viewDirectionWS = WorldSpaceViewDirection;
#else
	inputData.viewDirectionWS = normalize(WorldSpaceViewDirection);
#endif

	inputData.shadowCoord = IN.shadowCoord;

	inputData.fogCoord = IN.fogFactorAndVertexLight.x;
	inputData.vertexLighting = IN.fogFactorAndVertexLight.yzw;
	inputData.bakedGI = SAMPLE_GI(IN.lightmapUV, IN.vertexSH, inputData.normalWS);

	half4 color = LightweightFragmentPBR(
		inputData,
		Albedo,
		Metallic,
		Specular,
		Smoothness,
		Occlusion,
		Emission,
		Alpha);

	// Computes fog factor per-vertex
	ApplyFog(color.rgb, IN.fogFactorAndVertexLight.x);

#if _AlphaClip
	clip(Alpha - AlphaClipThreshold);
#endif
	return color;
	}

		ENDHLSL
	}
		Pass
	{
		Name "ShadowCaster"
		Tags{ "LightMode" = "ShadowCaster" }

		ZWrite On ZTest LEqual

		// Material options generated by graph
		Cull Back

		HLSLPROGRAM
		// Required to compile gles 2.0 with standard srp library
#pragma prefer_hlslcc gles
#pragma exclude_renderers d3d11_9x
#pragma target 2.0

		//--------------------------------------
		// GPU Instancing
#pragma multi_compile_instancing

#pragma vertex ShadowPassVertex
#pragma fragment ShadowPassFragment

		// Defines generated by graph
#define _AlphaClip 1

#include "LWRP/ShaderLibrary/Core.hlsl"
#include "LWRP/ShaderLibrary/Lighting.hlsl"
#include "ShaderGraphLibrary/Functions.hlsl"
#include "CoreRP/ShaderLibrary/Color.hlsl"

		float4 Color_219146F1;
	TEXTURE2D(Texture2D_42C67CC); SAMPLER(samplerTexture2D_42C67CC);
	float2 Vector2_547A76F1;
	float Vector1_285C77C0;
	float4 Color_96DBF111;

	struct VertexDescriptionInputs
	{
		float3 ObjectSpacePosition;
	};


	struct VertexDescription
	{
		float3 Position;
	};

	VertexDescription PopulateVertexData(VertexDescriptionInputs IN)
	{
		VertexDescription description = (VertexDescription)0;
		description.Position = IN.ObjectSpacePosition;
		return description;
	}

	struct GraphVertexInput
	{
		float4 vertex : POSITION;
		float3 normal : NORMAL;
		float4 tangent : TANGENT;
		float4 texcoord1 : TEXCOORD1;
		UNITY_VERTEX_INPUT_INSTANCE_ID
	};


	struct VertexOutput
	{
		float2 uv           : TEXCOORD0;
		float4 clipPos      : SV_POSITION;
		UNITY_VERTEX_INPUT_INSTANCE_ID
			UNITY_VERTEX_OUTPUT_STEREO
	};

	// x: global clip space bias, y: normal world space bias
	float4 _ShadowBias;
	float3 _LightDirection;

	VertexOutput ShadowPassVertex(GraphVertexInput v)
	{
		VertexOutput o;
		UNITY_SETUP_INSTANCE_ID(v);
		UNITY_TRANSFER_INSTANCE_ID(v, o);
		UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);

		// Vertex transformations performed by graph
		float3 WorldSpacePosition = mul(UNITY_MATRIX_M,v.vertex);
		float3 WorldSpaceNormal = mul(v.normal,(float3x3)UNITY_MATRIX_I_M);
		float4 uv1 = v.texcoord1;
		float3 ObjectSpacePosition = mul(UNITY_MATRIX_I_M,float4(WorldSpacePosition,1.0));

		VertexDescriptionInputs vdi = (VertexDescriptionInputs)0;

		// Vertex description inputs defined by graph
		vdi.ObjectSpacePosition = ObjectSpacePosition;

		VertexDescription vd = PopulateVertexData(vdi);
		v.vertex.xyz = vd.Position;

		o.uv = uv1;

		float3 positionWS = TransformObjectToWorld(v.vertex.xyz);
		float3 normalWS = TransformObjectToWorldDir(v.normal);

		float invNdotL = 1.0 - saturate(dot(_LightDirection, normalWS));
		float scale = invNdotL * _ShadowBias.y;

		// normal bias is negative since we want to apply an inset normal offset
		positionWS = normalWS * scale.xxx + positionWS;
		float4 clipPos = TransformWorldToHClip(positionWS);

		// _ShadowBias.x sign depens on if platform has reversed z buffer
		clipPos.z += _ShadowBias.x;

#if UNITY_REVERSED_Z
		clipPos.z = min(clipPos.z, clipPos.w * UNITY_NEAR_CLIP_VALUE);
#else
		clipPos.z = max(clipPos.z, clipPos.w * UNITY_NEAR_CLIP_VALUE);
#endif
		o.clipPos = clipPos;

		return o;
	}

	half4 ShadowPassFragment(VertexOutput IN) : SV_TARGET
	{
		UNITY_SETUP_INSTANCE_ID(IN);
	return 0;
	}

		ENDHLSL
	}

		Pass
	{
		Name "DepthOnly"
		Tags{ "LightMode" = "DepthOnly" }

		ZWrite On
		ColorMask 0

		// Material options generated by graph
		Cull Back

		HLSLPROGRAM
		// Required to compile gles 2.0 with standard srp library
#pragma prefer_hlslcc gles
#pragma exclude_renderers d3d11_9x
#pragma target 2.0

		//--------------------------------------
		// GPU Instancing
#pragma multi_compile_instancing

#pragma vertex vert
#pragma fragment frag

		// Defines generated by graph
#define _AlphaClip 1

#include "LWRP/ShaderLibrary/Core.hlsl"
#include "LWRP/ShaderLibrary/Lighting.hlsl"
#include "ShaderGraphLibrary/Functions.hlsl"
#include "CoreRP/ShaderLibrary/Color.hlsl"

		float4 Color_219146F1;
	TEXTURE2D(Texture2D_42C67CC); SAMPLER(samplerTexture2D_42C67CC);
	float2 Vector2_547A76F1;
	float Vector1_285C77C0;
	float4 Color_96DBF111;

	struct VertexDescriptionInputs
	{
		float3 ObjectSpacePosition;
	};


	struct VertexDescription
	{
		float3 Position;
	};

	VertexDescription PopulateVertexData(VertexDescriptionInputs IN)
	{
		VertexDescription description = (VertexDescription)0;
		description.Position = IN.ObjectSpacePosition;
		return description;
	}

	struct GraphVertexInput
	{
		float4 vertex : POSITION;
		float3 normal : NORMAL;
		float4 tangent : TANGENT;
		float4 texcoord1 : TEXCOORD1;
		UNITY_VERTEX_INPUT_INSTANCE_ID
	};


	struct VertexOutput
	{
		float2 uv           : TEXCOORD0;
		float4 clipPos      : SV_POSITION;
		UNITY_VERTEX_INPUT_INSTANCE_ID
			UNITY_VERTEX_OUTPUT_STEREO
	};

	VertexOutput vert(GraphVertexInput v)
	{
		VertexOutput o = (VertexOutput)0;
		UNITY_SETUP_INSTANCE_ID(v);
		UNITY_TRANSFER_INSTANCE_ID(v, o);
		UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);

		// Vertex transformations performed by graph
		float3 WorldSpacePosition = mul(UNITY_MATRIX_M,v.vertex);
		float3 WorldSpaceNormal = mul(v.normal,(float3x3)UNITY_MATRIX_I_M);
		float4 uv1 = v.texcoord1;
		float3 ObjectSpacePosition = mul(UNITY_MATRIX_I_M,float4(WorldSpacePosition,1.0));

		VertexDescriptionInputs vdi = (VertexDescriptionInputs)0;

		// Vertex description inputs defined by graph
		vdi.ObjectSpacePosition = ObjectSpacePosition;

		VertexDescription vd = PopulateVertexData(vdi);
		v.vertex.xyz = vd.Position;

		o.uv = uv1;
		o.clipPos = TransformObjectToHClip(v.vertex.xyz);
		return o;
	}

	half4 frag(VertexOutput IN) : SV_TARGET
	{
		UNITY_SETUP_INSTANCE_ID(IN);
	return 0;
	}
		ENDHLSL
	}

		// This pass it not used during regular rendering, only for lightmap baking.
		Pass
	{
		Name "Meta"
		Tags{ "LightMode" = "Meta" }

		Cull Off

		HLSLPROGRAM
		// Required to compile gles 2.0 with standard srp library
#pragma prefer_hlslcc gles
#pragma exclude_renderers d3d11_9x
#pragma target 2.0

#pragma vertex LightweightVertexMeta
#pragma fragment LightweightFragmentMeta

#pragma shader_feature _SPECULAR_SETUP
#pragma shader_feature _EMISSION
#pragma shader_feature _METALLICSPECGLOSSMAP
#pragma shader_feature _ _SMOOTHNESS_TEXTURE_ALBEDO_CHANNEL_A
#pragma shader_feature EDITOR_VISUALIZATION

#pragma shader_feature _SPECGLOSSMAP

#include "LWRP/ShaderLibrary/InputSurfacePBR.hlsl"
#include "LWRP/ShaderLibrary/LightweightPassMetaPBR.hlsl"
		ENDHLSL
	}
	}
		FallBack "Hidden/InternalErrorShader"
}
