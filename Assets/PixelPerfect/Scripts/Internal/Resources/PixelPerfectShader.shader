// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.13 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.13;sub:START;pass:START;ps:flbk:,lico:1,lgpr:1,nrmq:1,nrsp:0,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,rprd:False,enco:False,rmgx:True,rpth:0,hqsc:True,hqlp:False,tesm:0,bsrc:0,bdst:1,culm:0,dpts:2,wrdp:True,dith:0,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:8849,x:32975,y:32435,varname:node_8849,prsc:2|emission-8878-RGB;n:type:ShaderForge.SFN_TexCoord,id:7655,x:31479,y:32625,varname:node_7655,prsc:2,uv:0;n:type:ShaderForge.SFN_Tex2d,id:8878,x:32649,y:32606,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:node_8878,prsc:2,ntxv:0,isnm:False|UVIN-15-OUT;n:type:ShaderForge.SFN_ScreenParameters,id:3289,x:31048,y:32372,varname:node_3289,prsc:2;n:type:ShaderForge.SFN_Append,id:7945,x:31266,y:32372,varname:node_7945,prsc:2|A-3289-PXW,B-3289-PXH;n:type:ShaderForge.SFN_Multiply,id:3813,x:31692,y:32625,varname:node_3813,prsc:2|A-5411-OUT,B-7655-UVOUT;n:type:ShaderForge.SFN_Floor,id:6113,x:31862,y:32625,varname:node_6113,prsc:2|IN-3813-OUT;n:type:ShaderForge.SFN_Divide,id:15,x:32434,y:32638,varname:node_15,prsc:2|A-5865-OUT,B-9889-OUT;n:type:ShaderForge.SFN_Add,id:7680,x:32038,y:32478,varname:node_7680,prsc:2|A-779-OUT,B-6113-OUT;n:type:ShaderForge.SFN_Vector1,id:779,x:32038,y:32404,cmnt:Half pixel offset,varname:node_779,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Divide,id:5411,x:31479,y:32487,cmnt:SD Resolution,varname:node_5411,prsc:2|A-7945-OUT,B-5595-OUT;n:type:ShaderForge.SFN_Relay,id:5865,x:32322,y:32619,varname:node_5865,prsc:2|IN-5953-OUT;n:type:ShaderForge.SFN_Relay,id:9889,x:32258,y:32703,varname:node_9889,prsc:2|IN-7945-OUT;n:type:ShaderForge.SFN_ValueProperty,id:5595,x:31266,y:32550,ptovrint:False,ptlb:Zoom,ptin:_Zoom,varname:node_5595,prsc:2,glob:False,v1:1;n:type:ShaderForge.SFN_Subtract,id:7341,x:31493,y:32141,varname:node_7341,prsc:2|A-7945-OUT,B-5411-OUT;n:type:ShaderForge.SFN_Divide,id:9515,x:31696,y:32141,varname:node_9515,prsc:2|A-7341-OUT,B-939-OUT;n:type:ShaderForge.SFN_Vector1,id:939,x:31696,y:32070,varname:node_939,prsc:2,v1:2;n:type:ShaderForge.SFN_Add,id:5953,x:32258,y:32432,varname:node_5953,prsc:2|A-7680-OUT,B-1847-OUT;n:type:ShaderForge.SFN_Floor,id:1847,x:31883,y:32141,varname:node_1847,prsc:2|IN-9515-OUT;proporder:8878-5595;pass:END;sub:END;*/

Shader "Pixelatto/PixelPerfect" {
    Properties {
        _MainTex ("MainTex", 2D) = "white" {}
        _Zoom ("Zoom", Float ) = 1
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float _Zoom;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                UNITY_FOG_COORDS(1)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos(v.vertex);
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
/////// Vectors:
////// Lighting:
////// Emissive:
                float2 node_7945 = float2(_ScreenParams.r,_ScreenParams.g);
                float2 node_5411 = (node_7945/_Zoom); // SD Resolution
                float2 node_15 = (((0.5+floor((node_5411*i.uv0)))+floor(((node_7945-node_5411)/2.0)))/node_7945);
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(node_15, _MainTex));
                float3 emissive = _MainTex_var.rgb;
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
