// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:0,lgpr:1,limd:3,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:False,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4013,x:33303,y:32677,varname:node_4013,prsc:2|diff-1882-OUT,spec-458-OUT,gloss-6907-OUT,normal-7170-RGB,emission-2937-OUT,clip-7098-OUT;n:type:ShaderForge.SFN_Color,id:1304,x:32247,y:32426,ptovrint:False,ptlb:Color(A),ptin:_ColorA,varname:node_1304,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Slider,id:458,x:32832,y:32561,ptovrint:False,ptlb:Specular,ptin:_Specular,varname:node_458,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.1539281,max:1;n:type:ShaderForge.SFN_Vector4Property,id:4510,x:31245,y:33080,ptovrint:False,ptlb:_SectionCentre,ptin:_SectionCentre,varname:node_4510,prsc:2,glob:True,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.5,v2:0.5,v3:0.5,v4:1;n:type:ShaderForge.SFN_Negate,id:5861,x:31449,y:32991,varname:node_5861,prsc:2|IN-4510-X;n:type:ShaderForge.SFN_Negate,id:2667,x:31450,y:33119,varname:node_2667,prsc:2|IN-4510-Y;n:type:ShaderForge.SFN_Negate,id:1496,x:31450,y:33255,varname:node_1496,prsc:2|IN-4510-Z;n:type:ShaderForge.SFN_Add,id:7331,x:31660,y:32926,varname:node_7331,prsc:2|A-2263-X,B-5861-OUT;n:type:ShaderForge.SFN_Add,id:4282,x:31660,y:33050,varname:node_4282,prsc:2|A-2667-OUT,B-2263-Y;n:type:ShaderForge.SFN_Add,id:1853,x:31660,y:33169,varname:node_1853,prsc:2|A-2263-Z,B-1496-OUT;n:type:ShaderForge.SFN_FragmentPosition,id:2263,x:31449,y:32862,varname:node_2263,prsc:2;n:type:ShaderForge.SFN_Append,id:2355,x:31896,y:32848,varname:node_2355,prsc:2|A-7331-OUT,B-1853-OUT;n:type:ShaderForge.SFN_Vector2,id:4668,x:31896,y:32977,varname:node_4668,prsc:2,v1:0,v2:0;n:type:ShaderForge.SFN_Rotator,id:6788,x:32096,y:32937,varname:node_6788,prsc:2|UVIN-2355-OUT,PIV-4668-OUT,ANG-4804-OUT;n:type:ShaderForge.SFN_Append,id:3322,x:31896,y:33146,varname:node_3322,prsc:2|A-7331-OUT,B-4282-OUT;n:type:ShaderForge.SFN_ValueProperty,id:4804,x:31896,y:33084,ptovrint:False,ptlb:Angle,ptin:_Angle,varname:node_4804,prsc:2,glob:True,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Tex2d,id:2033,x:32449,y:33078,varname:node_2033,prsc:2,ntxv:0,isnm:False|UVIN-2399-UVOUT,TEX-6769-TEX;n:type:ShaderForge.SFN_Tex2d,id:7726,x:32449,y:33236,varname:node_7726,prsc:2,ntxv:0,isnm:False|UVIN-8332-UVOUT,TEX-6769-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:6769,x:32150,y:33366,ptovrint:False,ptlb:Clamped,ptin:_Clamped,varname:node_6769,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:2096,x:32638,y:33176,varname:node_2096,prsc:2|A-2033-R,B-7726-R;n:type:ShaderForge.SFN_Tex2d,id:784,x:32247,y:32226,ptovrint:False,ptlb:Diffuse,ptin:_Diffuse,varname:node_784,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Blend,id:766,x:32495,y:32304,varname:node_766,prsc:2,blmd:1,clmp:True|SRC-784-RGB,DST-1304-RGB;n:type:ShaderForge.SFN_Add,id:7098,x:32802,y:33113,varname:node_7098,prsc:2|A-2869-OUT,B-2096-OUT;n:type:ShaderForge.SFN_ValueProperty,id:2869,x:32638,y:33094,ptovrint:False,ptlb:OpacityOverride,ptin:_OpacityOverride,varname:node_2869,prsc:2,glob:True,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Tex2d,id:8381,x:32495,y:32112,ptovrint:False,ptlb:AmbientOcclusion (UV2),ptin:_AmbientOcclusionUV2,varname:node_8381,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-9077-UVOUT;n:type:ShaderForge.SFN_Multiply,id:2179,x:32724,y:32285,varname:node_2179,prsc:2|A-8381-RGB,B-766-OUT;n:type:ShaderForge.SFN_TexCoord,id:9077,x:32247,y:32045,varname:node_9077,prsc:2,uv:1;n:type:ShaderForge.SFN_Panner,id:8332,x:32150,y:33183,varname:node_8332,prsc:2,spu:0,spv:-1|UVIN-3322-OUT,DIST-4958-OUT;n:type:ShaderForge.SFN_ValueProperty,id:4958,x:31896,y:33302,ptovrint:False,ptlb:VerticalOffset,ptin:_VerticalOffset,varname:node_4958,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Panner,id:2399,x:32279,y:32937,varname:node_2399,prsc:2,spu:0,spv:1|UVIN-6788-UVOUT,DIST-2816-OUT;n:type:ShaderForge.SFN_ValueProperty,id:2816,x:32096,y:33100,ptovrint:False,ptlb:HorizontalOffset,ptin:_HorizontalOffset,varname:node_2816,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Tex2d,id:7170,x:32937,y:32824,ptovrint:False,ptlb:Normalmap,ptin:_Normalmap,varname:node_7170,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:3,isnm:True;n:type:ShaderForge.SFN_FaceSign,id:1484,x:32615,y:32899,varname:node_1484,prsc:2,fstp:0;n:type:ShaderForge.SFN_Lerp,id:2937,x:32802,y:32969,varname:node_2937,prsc:2|A-2776-RGB,B-6888-RGB,T-1484-VFACE;n:type:ShaderForge.SFN_Color,id:2776,x:32615,y:32526,ptovrint:False,ptlb:Backfaces,ptin:_Backfaces,varname:node_2776,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Lerp,id:1882,x:32932,y:32381,varname:node_1882,prsc:2|A-2776-RGB,B-2179-OUT,T-1484-VFACE;n:type:ShaderForge.SFN_Color,id:6888,x:32615,y:32724,ptovrint:False,ptlb:Hidden,ptin:_Hidden,varname:node_6888,prsc:2,glob:False,taghide:True,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Lerp,id:6907,x:33009,y:32671,varname:node_6907,prsc:2|A-6888-R,B-4815-OUT,T-1484-VFACE;n:type:ShaderForge.SFN_ValueProperty,id:4815,x:32816,y:32705,ptovrint:False,ptlb:Gloss,ptin:_Gloss,varname:node_4815,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.5;proporder:784-1304-7170-8381-6769-458-4815-4958-6888-2816-2776;pass:END;sub:END;*/

Shader "Custom/CrossSection" {
    Properties {
        _Diffuse ("Diffuse", 2D) = "white" {}
        _ColorA ("Color(A)", Color) = (1,1,1,1)
        _Normalmap ("Normalmap", 2D) = "bump" {}
        _AmbientOcclusionUV2 ("AmbientOcclusion (UV2)", 2D) = "white" {}
        _Clamped ("Clamped", 2D) = "white" {}
        _Specular ("Specular", Range(0, 1)) = 0.1539281
        _Gloss ("Gloss", Float ) = 0.5
        _VerticalOffset ("VerticalOffset", Float ) = 0
        [HideInInspector]_Hidden ("Hidden", Color) = (0,0,0,1)
        _HorizontalOffset ("HorizontalOffset", Float ) = 0
        _Backfaces ("Backfaces", Color) = (1,0,0,1)
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
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
            Cull Off
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma exclude_renderers d3d9 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _ColorA;
            uniform float _Specular;
            uniform float4 _SectionCentre;
            uniform float _Angle;
            uniform sampler2D _Clamped; uniform float4 _Clamped_ST;
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform float _OpacityOverride;
            uniform sampler2D _AmbientOcclusionUV2; uniform float4 _AmbientOcclusionUV2_ST;
            uniform float _VerticalOffset;
            uniform float _HorizontalOffset;
            uniform sampler2D _Normalmap; uniform float4 _Normalmap_ST;
            uniform float4 _Backfaces;
            uniform float4 _Hidden;
            uniform float _Gloss;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                LIGHTING_COORDS(7,8)
                UNITY_FOG_COORDS(9)
                #if defined(LIGHTMAP_ON) || defined(UNITY_SHOULD_SAMPLE_SH)
                    float4 ambientOrLightmapUV : TEXCOORD10;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                #ifdef LIGHTMAP_ON
                    o.ambientOrLightmapUV.xy = v.texcoord1.xy * unity_LightmapST.xy + unity_LightmapST.zw;
                    o.ambientOrLightmapUV.zw = 0;
                #elif UNITY_SHOULD_SAMPLE_SH
                #endif
                #ifdef DYNAMICLIGHTMAP_ON
                    o.ambientOrLightmapUV.zw = v.texcoord2.xy * unity_DynamicLightmapST.xy + unity_DynamicLightmapST.zw;
                #endif
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _Normalmap_var = UnpackNormal(tex2D(_Normalmap,TRANSFORM_TEX(i.uv0, _Normalmap)));
                float3 normalLocal = _Normalmap_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float node_6788_ang = _Angle;
                float node_6788_spd = 1.0;
                float node_6788_cos = cos(node_6788_spd*node_6788_ang);
                float node_6788_sin = sin(node_6788_spd*node_6788_ang);
                float2 node_6788_piv = float2(0,0);
                float node_7331 = (i.posWorld.r+(-1*_SectionCentre.r));
                float2 node_6788 = (mul(float2(node_7331,(i.posWorld.b+(-1*_SectionCentre.b)))-node_6788_piv,float2x2( node_6788_cos, -node_6788_sin, node_6788_sin, node_6788_cos))+node_6788_piv);
                float2 node_2399 = (node_6788+_HorizontalOffset*float2(0,1));
                float4 node_2033 = tex2D(_Clamped,TRANSFORM_TEX(node_2399, _Clamped));
                float2 node_8332 = (float2(node_7331,((-1*_SectionCentre.g)+i.posWorld.g))+_VerticalOffset*float2(0,-1));
                float4 node_7726 = tex2D(_Clamped,TRANSFORM_TEX(node_8332, _Clamped));
                clip((_OpacityOverride+(node_2033.r*node_7726.r)) - 0.5);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float gloss = lerp(_Hidden.r,_Gloss,isFrontFace);
                float specPow = exp2( gloss * 10.0+1.0);
/////// GI Data:
                UnityLight light;
                #ifdef LIGHTMAP_OFF
                    light.color = lightColor;
                    light.dir = lightDirection;
                    light.ndotl = LambertTerm (normalDirection, light.dir);
                #else
                    light.color = half3(0.f, 0.f, 0.f);
                    light.ndotl = 0.0f;
                    light.dir = half3(0.f, 0.f, 0.f);
                #endif
                UnityGIInput d;
                d.light = light;
                d.worldPos = i.posWorld.xyz;
                d.worldViewDir = viewDirection;
                d.atten = attenuation;
                #if defined(LIGHTMAP_ON) || defined(DYNAMICLIGHTMAP_ON)
                    d.ambient = 0;
                    d.lightmapUV = i.ambientOrLightmapUV;
                #else
                    d.ambient = i.ambientOrLightmapUV;
                #endif
                d.boxMax[0] = unity_SpecCube0_BoxMax;
                d.boxMin[0] = unity_SpecCube0_BoxMin;
                d.probePosition[0] = unity_SpecCube0_ProbePosition;
                d.probeHDR[0] = unity_SpecCube0_HDR;
                d.boxMax[1] = unity_SpecCube1_BoxMax;
                d.boxMin[1] = unity_SpecCube1_BoxMin;
                d.probePosition[1] = unity_SpecCube1_ProbePosition;
                d.probeHDR[1] = unity_SpecCube1_HDR;
                Unity_GlossyEnvironmentData ugls_en_data;
                ugls_en_data.roughness = 1.0 - gloss;
                ugls_en_data.reflUVW = viewReflectDirection;
                UnityGI gi = UnityGlobalIllumination(d, 1, normalDirection, ugls_en_data );
                lightDirection = gi.light.dir;
                lightColor = gi.light.color;
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float LdotH = max(0.0,dot(lightDirection, halfDirection));
                float4 _AmbientOcclusionUV2_var = tex2D(_AmbientOcclusionUV2,TRANSFORM_TEX(i.uv1, _AmbientOcclusionUV2));
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                float3 diffuseColor = lerp(_Backfaces.rgb,(_AmbientOcclusionUV2_var.rgb*saturate((_Diffuse_var.rgb*_ColorA.rgb))),isFrontFace); // Need this for specular when using metallic
                float specularMonochrome;
                float3 specularColor;
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, _Specular, specularColor, specularMonochrome );
                specularMonochrome = 1-specularMonochrome;
                float NdotV = max(0.0,dot( normalDirection, viewDirection ));
                float NdotH = max(0.0,dot( normalDirection, halfDirection ));
                float VdotH = max(0.0,dot( viewDirection, halfDirection ));
                float visTerm = SmithBeckmannVisibilityTerm( NdotL, NdotV, 1.0-gloss );
                float normTerm = max(0.0, NDFBlinnPhongNormalizedTerm(NdotH, RoughnessToSpecPower(1.0-gloss)));
                float specularPBL = max(0, (NdotL*visTerm*normTerm) * (UNITY_PI / 4) );
                float3 directSpecular = 1 * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularPBL*lightColor*FresnelTerm(specularColor, LdotH);
                half grazingTerm = saturate( gloss + specularMonochrome );
                float3 indirectSpecular = (gi.indirect.specular);
                indirectSpecular *= FresnelLerp (specularColor, grazingTerm, NdotV);
                float3 specular = (directSpecular + indirectSpecular);
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float3 directDiffuse = ((1 +(fd90 - 1)*pow((1.00001-NdotL), 5)) * (1 + (fd90 - 1)*pow((1.00001-NdotV), 5)) * NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += gi.indirect.diffuse;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float3 emissive = lerp(_Backfaces.rgb,_Hidden.rgb,isFrontFace);
/// Final Color:
                float3 finalColor = diffuse + specular + emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma exclude_renderers d3d9 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _SectionCentre;
            uniform float _Angle;
            uniform sampler2D _Clamped; uniform float4 _Clamped_ST;
            uniform float _OpacityOverride;
            uniform float _VerticalOffset;
            uniform float _HorizontalOffset;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos(v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float node_6788_ang = _Angle;
                float node_6788_spd = 1.0;
                float node_6788_cos = cos(node_6788_spd*node_6788_ang);
                float node_6788_sin = sin(node_6788_spd*node_6788_ang);
                float2 node_6788_piv = float2(0,0);
                float node_7331 = (i.posWorld.r+(-1*_SectionCentre.r));
                float2 node_6788 = (mul(float2(node_7331,(i.posWorld.b+(-1*_SectionCentre.b)))-node_6788_piv,float2x2( node_6788_cos, -node_6788_sin, node_6788_sin, node_6788_cos))+node_6788_piv);
                float2 node_2399 = (node_6788+_HorizontalOffset*float2(0,1));
                float4 node_2033 = tex2D(_Clamped,TRANSFORM_TEX(node_2399, _Clamped));
                float2 node_8332 = (float2(node_7331,((-1*_SectionCentre.g)+i.posWorld.g))+_VerticalOffset*float2(0,-1));
                float4 node_7726 = tex2D(_Clamped,TRANSFORM_TEX(node_8332, _Clamped));
                clip((_OpacityOverride+(node_2033.r*node_7726.r)) - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
        Pass {
            Name "Meta"
            Tags {
                "LightMode"="Meta"
            }
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_META 1
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #include "UnityMetaPass.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma exclude_renderers d3d9 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _ColorA;
            uniform float _Specular;
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform sampler2D _AmbientOcclusionUV2; uniform float4 _AmbientOcclusionUV2_ST;
            uniform float4 _Backfaces;
            uniform float4 _Hidden;
            uniform float _Gloss;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : SV_Target {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                o.Emission = lerp(_Backfaces.rgb,_Hidden.rgb,isFrontFace);
                
                float4 _AmbientOcclusionUV2_var = tex2D(_AmbientOcclusionUV2,TRANSFORM_TEX(i.uv1, _AmbientOcclusionUV2));
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                float3 diffColor = lerp(_Backfaces.rgb,(_AmbientOcclusionUV2_var.rgb*saturate((_Diffuse_var.rgb*_ColorA.rgb))),isFrontFace);
                float specularMonochrome;
                float3 specColor;
                diffColor = DiffuseAndSpecularFromMetallic( diffColor, _Specular, specColor, specularMonochrome );
                float roughness = 1.0 - lerp(_Hidden.r,_Gloss,isFrontFace);
                o.Albedo = diffColor + specColor * roughness * roughness * 0.5;
                
                return UnityMetaFragment( o );
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
