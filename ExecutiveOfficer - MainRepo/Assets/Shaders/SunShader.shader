// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:True,lico:1,lgpr:1,limd:2,spmd:0,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:32719,y:32712,varname:node_3138,prsc:2|normal-4879-OUT,emission-4879-OUT,refract-837-OUT;n:type:ShaderForge.SFN_Lerp,id:7478,x:32256,y:32686,varname:node_7478,prsc:2|A-4237-RGB,B-7541-OUT,T-833-OUT;n:type:ShaderForge.SFN_Color,id:4237,x:31808,y:32540,ptovrint:False,ptlb:CoronaColor,ptin:_CoronaColor,varname:node_4237,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Color,id:453,x:31654,y:32633,ptovrint:False,ptlb:MainColor,ptin:_MainColor,varname:node_453,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.9,c2:0.9,c3:0.2,c4:1;n:type:ShaderForge.SFN_Vector1,id:4612,x:31654,y:32800,varname:node_4612,prsc:2,v1:2.33;n:type:ShaderForge.SFN_Multiply,id:7541,x:32055,y:32706,varname:node_7541,prsc:2|A-453-RGB,B-4612-OUT;n:type:ShaderForge.SFN_NormalVector,id:3196,x:31452,y:32780,prsc:2,pt:False;n:type:ShaderForge.SFN_Vector1,id:8290,x:31452,y:32925,varname:node_8290,prsc:2,v1:1;n:type:ShaderForge.SFN_Fresnel,id:7676,x:31654,y:32864,varname:node_7676,prsc:2|NRM-3196-OUT,EXP-8290-OUT;n:type:ShaderForge.SFN_OneMinus,id:9206,x:31839,y:32864,varname:node_9206,prsc:2|IN-7676-OUT;n:type:ShaderForge.SFN_Slider,id:2193,x:31613,y:33039,ptovrint:False,ptlb:node_2193,ptin:_node_2193,varname:node_2193,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Multiply,id:833,x:32033,y:32864,varname:node_833,prsc:2|A-9206-OUT,B-2193-OUT;n:type:ShaderForge.SFN_TexCoord,id:9236,x:31194,y:33155,varname:node_9236,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Vector1,id:2409,x:31194,y:33293,varname:node_2409,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Multiply,id:6688,x:31373,y:33222,varname:node_6688,prsc:2|A-9236-UVOUT,B-2409-OUT;n:type:ShaderForge.SFN_ComponentMask,id:1546,x:31786,y:33222,varname:node_1546,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-3757-RGB;n:type:ShaderForge.SFN_Tex2d,id:3757,x:31565,y:33222,ptovrint:False,ptlb:SunEdgeTexture,ptin:_SunEdgeTexture,varname:node_3757,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:bbab0a6f7bae9cf42bf057d8ee2755f6,ntxv:3,isnm:True|UVIN-6688-OUT;n:type:ShaderForge.SFN_Vector1,id:7643,x:31786,y:33372,varname:node_7643,prsc:2,v1:10;n:type:ShaderForge.SFN_Multiply,id:6637,x:31965,y:33222,varname:node_6637,prsc:2|A-1546-OUT,B-7643-OUT;n:type:ShaderForge.SFN_Lerp,id:4879,x:32473,y:32834,varname:node_4879,prsc:2|A-7478-OUT,B-837-OUT,T-2191-OUT;n:type:ShaderForge.SFN_Vector1,id:2191,x:32239,y:32938,varname:node_2191,prsc:2,v1:0.07;n:type:ShaderForge.SFN_OneMinus,id:837,x:32402,y:33222,varname:node_837,prsc:2|IN-8170-OUT;n:type:ShaderForge.SFN_Lerp,id:8170,x:32176,y:33222,varname:node_8170,prsc:2|A-2687-RGB,B-6637-OUT,T-1688-OUT;n:type:ShaderForge.SFN_Color,id:2687,x:31965,y:33082,ptovrint:False,ptlb:EdgeEmphasisColor,ptin:_EdgeEmphasisColor,varname:node_2687,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0,c3:0,c4:0;n:type:ShaderForge.SFN_Vector1,id:1688,x:31965,y:33372,varname:node_1688,prsc:2,v1:0.5;proporder:4237-2193-3757-2687-453;pass:END;sub:END;*/

Shader "Shader Forge/SunShader" {
    Properties {
        _CoronaColor ("CoronaColor", Color) = (1,0.5,0.5,1)
        _node_2193 ("node_2193", Range(0, 1)) = 1
        _SunEdgeTexture ("SunEdgeTexture", 2D) = "bump" {}
        _EdgeEmphasisColor ("EdgeEmphasisColor", Color) = (0,0,0,0)
        _MainColor ("MainColor", Color) = (0.9,0.9,0.2,1)
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        GrabPass{ }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma target 3.0
            uniform sampler2D _GrabTexture;
            uniform sampler2D _SunEdgeTexture; uniform float4 _SunEdgeTexture_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float4, _CoronaColor)
                UNITY_DEFINE_INSTANCED_PROP( float4, _MainColor)
                UNITY_DEFINE_INSTANCED_PROP( float, _node_2193)
                UNITY_DEFINE_INSTANCED_PROP( float4, _EdgeEmphasisColor)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                float4 projPos : TEXCOORD5;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 _CoronaColor_var = UNITY_ACCESS_INSTANCED_PROP( Props, _CoronaColor );
                float4 _MainColor_var = UNITY_ACCESS_INSTANCED_PROP( Props, _MainColor );
                float _node_2193_var = UNITY_ACCESS_INSTANCED_PROP( Props, _node_2193 );
                float4 _EdgeEmphasisColor_var = UNITY_ACCESS_INSTANCED_PROP( Props, _EdgeEmphasisColor );
                float2 node_6688 = (i.uv0*0.5);
                float3 _SunEdgeTexture_var = UnpackNormal(tex2D(_SunEdgeTexture,TRANSFORM_TEX(node_6688, _SunEdgeTexture)));
                float3 node_837 = (1.0 - lerp(_EdgeEmphasisColor_var.rgb,float3((_SunEdgeTexture_var.rgb.rg*10.0),0.0),0.5));
                float3 node_4879 = lerp(lerp(_CoronaColor_var.rgb,(_MainColor_var.rgb*2.33),((1.0 - pow(1.0-max(0,dot(i.normalDir, viewDirection)),1.0))*_node_2193_var)),node_837,0.07);
                float3 normalLocal = node_4879;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float2 sceneUVs = (i.projPos.xy / i.projPos.w) + node_837.rg;
                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
////// Lighting:
////// Emissive:
                float3 emissive = node_4879;
                float3 finalColor = emissive;
                return fixed4(lerp(sceneColor.rgb, finalColor,1),1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
