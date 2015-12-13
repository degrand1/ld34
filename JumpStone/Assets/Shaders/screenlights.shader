Shader "Custom/screenlight" {
	Properties {
        _GlowColor( "Glow color", Color )     = ( 1, 0.47, 0.47, 1 )
        _GlowConcentration( "Glow concentration", Float ) = 2.8
	}
	SubShader {
		Pass {
            Blend SrcAlpha OneMinusSrcAlpha

			CGPROGRAM
	        #pragma vertex vert
	        #pragma fragment frag
	        #include "UnityCG.cginc"

			fixed4 _GlowColor;
			fixed4 _PlayerPosition;
            fixed _GlowConcentration;

	        struct VS_OUT {
	            float4 vertex : SV_POSITION;
	            float2 uv     : TEXCOORD0;
	        };
	       
	        VS_OUT vert( appdata_base v )
            {
	            VS_OUT o;
	           
	            o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
	            o.uv = v.texcoord;
	           
	            return o;
	        }

			float4 spotlight ( float4 base, float2 uv, float4 color )
			{
                fixed dist = 1 - length( uv - fixed2( 0.5, 0.5 ) ) * 2;
                float4 lit = base + clamp( ( pow( dist, _GlowConcentration ) * color ), fixed4( 0, 0, 0, 0 ), fixed4( 1, 1, 1, dist ) );
				return lit;
			}
	        
	        fixed4 frag (VS_OUT i) : COLOR
	        {
                float4 original = ( 0, 0, 0, 0 );
				fixed4 outColor = spotlight( original, i.uv, _GlowColor );
	            return outColor;
	        }
	       
	        ENDCG
        }
	}
}
