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
Cull Off
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
                 float4 depth : TEXCOORD1;
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
                o.depth.x = (o.vertex.z / (1.0 / o.vertex.w));

                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                 

                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float visibility =  (_MaterialParams.x + 1);
                float shadeOffset =  _MaterialParams.y;
                float palette =  _MaterialParams.z;
                float curbasepal =  _MaterialParams.w;
                float flipx = curbasepal < 0;

                curbasepal = 0; // abs(curbasepal) - 1;

                float shadeLookup = i.depth.x / 0.2 * (visibility + shadeOffset);
               shadeLookup = min(max(shadeLookup, 0), 23);

                // sample the texture
                float colorIndex = 0;
               
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

                float lookupIndex = _LookupTex.Load(int3(colorIndex, shadeLookup + (32 * palette), 0 )).r * 256;
                float3 texelNear = _PaletteTex.Load(int3(lookupIndex, curbasepal, 0)).xyz;

                float lum = saturate(Luminance(texelNear.rgb) * 4);

                return float4(texelNear.rgb * (lum * 256), 0.5);
            }
            ENDHLSL
        }
    }
}
