// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced 'samplerRECT' with 'sampler2D'

Shader "Unlit/Polymer"
{
    Properties
    {
        _MainTex ("_MainTex", 2D) = "white" {}
        _PaletteTex("_PaletteTex", 2D) = "white" {}
        _LookupTex("_LookupTex", 2D) = "white" {}
        _MaterialParams("_MaterialParams", Vector) = (1, 0, 0, 0)
        _MaterialParams2("_MaterialParams2", Vector) = (1, 0, 0, 0)
    }
    SubShader
    {
        Tags{"RenderType" = "Opaque" "RenderPipeline" = "UniversalRenderPipeline" "IgnoreProjector" = "True"}
        LOD 100
        Cull Off

        Pass
        {
            Tags { "LightMode" = "UniversalForward" }

            HLSLPROGRAM
            #pragma vertex LitPassVertex
            #pragma fragment LitPassFragment

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"

            struct appdata
            {
                float4 positionOS   : POSITION;
                float3 normalOS     : NORMAL;
                float4 tangentOS    : TANGENT;
                float2 uv           : TEXCOORD0;
                float2 uvLM         : TEXCOORD1;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 depth : TEXCOORD1;
                float3 worldVertex : TEXCOORD2;
                float3 normal : TEXCOORD3;
                float4 vertex : SV_POSITION;
            };
            texture2D _PaletteTex;
            sampler2D _MainTex;
            texture2D _LookupTex;


            float4 _MainTex_ST;
            float4 _MaterialParams;
            float4 _MaterialParams2;

            float linearize_depth(float d, float zNear, float zFar)
            {
                return zNear * zFar / (zFar + d * (zNear - zFar));
            }

            float fogFactorLinear(const float dist, const float start, const float end) {
                return 1.0 - clamp((end - dist) / (end - start), 0.0, 1.0);
            }


            v2f LitPassVertex(appdata input)
            {
                v2f o;

                // VertexPositionInputs contains position in multiple spaces (world, view, homogeneous clip space)
                // Our compiler will strip all unused references (say you don't use view space).
                // Therefore there is more flexibility at no additional cost with this struct.
                VertexPositionInputs vertexInput = GetVertexPositionInputs(input.positionOS.xyz);

                // Similar to VertexPositionInputs, VertexNormalInputs will contain normal, tangent and bitangent
                // in world space. If not used it will be stripped.
                VertexNormalInputs vertexNormalInput = GetVertexNormalInputs(input.normalOS, input.tangentOS);

                o.normal = vertexNormalInput.normalWS;
                o.worldVertex.xyz = vertexInput.positionWS.xyz;
                o.vertex = vertexInput.positionCS;
                o.depth.x = (o.vertex.z / (1.0 / o.vertex.w));

                o.uv = TRANSFORM_TEX(input.uv, _MainTex);
                 
                bool isSprite = _MaterialParams2.x == -1;

                if (isSprite)
                {
                    o.vertex.w -= 0.0005;
                }

                return o;
            }

            struct fragmentOutput
            {
                half4 color : COLOR;
                float depth : DEPTH;
            };

            fragmentOutput LitPassFragment(v2f i) : SV_Target
            {
                fragmentOutput o;
                float visibility =  (_MaterialParams.x + 16.0f) / 16.0f;
                float shadeOffset =  _MaterialParams.y;
                float palette =  _MaterialParams.z;
                float curbasepal =  _MaterialParams.w;
                float flipx = curbasepal < 0;
                float highres = _MaterialParams2.y;               

                curbasepal = 0; // abs(curbasepal) - 1;

                float shadeLookup = i.depth.x / 1.024 * (visibility);
               shadeLookup = max(shadeLookup + shadeOffset, 0);

                // sample the texture
                float colorIndex = 0;
               
                if (highres != 0)
                {
                    float2 _uv = i.uv;
                    _uv.y = 1.0 - _uv.y;
                    o.color = tex2D(_MainTex, _uv);
                }
                else
                {
                    if (flipx == 0)
                    {
                        colorIndex = tex2D(_MainTex, i.uv).r * 256;
                    }
                    else
                    {
                        float2 uv = i.uv;
                        uv.x = 1 - uv.x;
                        colorIndex = tex2D(_MainTex, uv).r * 256;
                    }
                    if (colorIndex == 256)
                        discard;

                    float lookupIndex = _LookupTex.Load(int3(colorIndex, shadeLookup + (32 * palette), 0)).r * 256;
                    float3 texelNear = _PaletteTex.Load(int3(lookupIndex, curbasepal, 0)).xyz;

                    float lum = saturate(Luminance(texelNear.rgb) * 4);

                    o.color = float4(texelNear.rgb, 1.0) * 4;
                }

                // 
                if (shadeOffset > 0)
                {       
                    if (_MaterialParams.x <= 239)
                    {
                        o.color.xyz *= clamp(1.0 - ((i.depth.x) * (shadeOffset / 8)), 0.0, 1.0);
                    }
                }

                // Surface data contains albedo, metallic, specular, smoothness, occlusion, emission and alpha
                // InitializeStandarLitSurfaceData initializes based on the rules for standard shader.
                // You can write your own function to initialize the surface data of your shader.
                //SurfaceData surfaceData;
                //InitializeStandardLitSurfaceData(i.uv, surfaceData);
                //
                //// BRDFData holds energy conserving diffuse and specular material reflections and its roughness.
                //// It's easy to plugin your own shading fuction. You just need replace LightingPhysicallyBased function
                //// below with your own.
                //BRDFData brdfData;
                //InitializeBRDFData(surfaceData.albedo, surfaceData.metallic, surfaceData.specular, surfaceData.smoothness, surfaceData.alpha, brdfData);

                //half3 viewDirectionWS = SafeNormalize(GetCameraPositionWS() - i.worldVertex);

                int additionalLightsCount = GetAdditionalLightsCount();
                for (int d = 0; d < additionalLightsCount; ++d)
                {
                    // Similar to GetMainLight, but it takes a for-loop index. This figures out the
                    // per-object light index and samples the light buffer accordingly to initialized the
                    // Light struct. If _ADDITIONAL_LIGHT_SHADOWS is defined it will also compute shadows.
                    Light light = GetAdditionalLight(d, i.worldVertex);

                    // Same functions used to shade the main light.
                    o.color.xyz += LightingLambert(light.color.xyz, light.direction.xyz, i.normal.xyz) * light.distanceAttenuation; //LightingPhysicallyBased(brdfData, light, i.normal, viewDirectionWS);
                }

                return o;
            }
            ENDHLSL
        }
    }
}
