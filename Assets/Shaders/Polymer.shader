// Upgrade NOTE: replaced 'samplerRECT' with 'sampler2D'

Shader "Unlit/Polymer"
{
    Properties
    {
        _MainTex ("_MainTex", 2D) = "white" {}
        _PaletteTex("_PaletteTex", 2D) = "white" {}
        _LookupTex("_LookupTex", 2D) = "white" {}
        _MaterialParams("_MaterialParams", Vector) = (1, 0, 0, 0)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                nointerpolation float4 depth : TEXCOORD1;
                float4 vertex : SV_POSITION;
            };
            texture2D _PaletteTex;
            sampler2D _MainTex;
            texture2D _LookupTex;


            float4 _MainTex_ST;
            float4 _MaterialParams;

            float linearize_depth(float d, float zNear, float zFar)
            {
                return zNear * zFar / (zFar + d * (zNear - zFar));
            }


            v2f vert (appdata v)
            {
                v2f o;

                o.vertex = UnityObjectToClipPos(v.vertex);
                o.depth.x = linearize_depth(o.vertex.z / o.vertex.w, 0.001, 3000);

                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                 

                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float visibility =  _MaterialParams.x;
                float shadeOffset =  _MaterialParams.y;
                float palette =  _MaterialParams.z;
                float curbasepal =  _MaterialParams.w;

                float shadeLookup = i.depth.x / 1.024 * visibility;
                shadeLookup = min(max(shadeLookup + shadeOffset, 0), 30);

                // sample the texture
                float colorIndex = tex2D(_MainTex, i.uv).r * 256;
                if (colorIndex == 256)
                    discard;

                float colorIndexNear = _LookupTex.Load(int3(colorIndex, shadeLookup + (32 * palette), 0 )).r * 256;
                float colorIndexFar = _LookupTex.Load(int3(colorIndex, shadeLookup + (32 * palette) + 1, 0)).r * 256;



                float3 texelNear = _PaletteTex.Load(int3(colorIndexNear, curbasepal, 0)).xyz;
                float3 texelFar = _PaletteTex.Load(int3(colorIndexFar, curbasepal, 0)).xyz;

                float3 tileArtColored = lerp(texelNear, texelFar, frac(shadeLookup));


                return float4(tileArtColored.x, tileArtColored.y, tileArtColored.z, 1) * 2;
            }
            ENDHLSL
        }
    }
}
