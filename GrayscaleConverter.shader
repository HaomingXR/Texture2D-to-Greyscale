Shader "Hidden/GrayscaleConverter" {
    Properties {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader {
        Pass {
            CGPROGRAM
                #pragma vertex vert_img
                #pragma fragment frag
                #include "UnityCG.cginc"

                sampler2D _MainTex;

                fixed4 frag (v2f_img i) : SV_Target {
                    fixed4 col = tex2D(_MainTex, i.uv);
                    float luminance = dot(col.rgb, float3(0.2126, 0.7152, 0.0722));
                    return fixed4(luminance, luminance, luminance, col.a);
                }
            ENDCG
        }
    }
}
