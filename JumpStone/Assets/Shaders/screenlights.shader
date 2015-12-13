Shader "Custom/screenlight" {
	Properties {
		_MainTex ("Screen Texture", 2D) = "white" {}
		_LightIntensity  ( "Spotlight intensity", Vector ) = ( 1.8, 1.8, 1.8, 1 )
		_PlayerPosition( "Player position", Vector ) = ( 0, 0, 0, 1 )
        _PlayerColor( "Player color", Color )     = ( 1, 0.47, 0.47, 1 )
		_LightFalloff	 ( "Spotlight falloff", Float ) = 0.12
	}
	SubShader {
		Pass {
			CGPROGRAM
	        #pragma vertex vert
	        #pragma fragment frag
	        #include "UnityCG.cginc"

	        sampler2D _MainTex;
	        float4 _MainTex_TexelSize;
			fixed4 _LightIntensity;
			fixed _LightFalloff;
			fixed4 _PlayerColor;
			fixed4 _PlayerPosition;

	        struct VS_OUT {
	            float4 vertex : SV_POSITION;
	            float2 uv     : TEXCOORD0;
	        };
	       
	        VS_OUT vert( appdata_img v )
            {
	            VS_OUT o;
	           
	            o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
	            o.uv = v.texcoord;
	           
	            return o;
	        }

			float4 spotlight ( float4 base, float4 pos, float4 lightPos, float4 color )
			{
                fixed falloffScreenSize = _ScreenParams.x * _LightFalloff;
				float gradient = 1 - ( clamp( distance( pos.xy, lightPos.xy ), 0, falloffScreenSize ) / falloffScreenSize );
				float4 lit = base * lerp( fixed4( 1, 1, 1, 1 ), _LightIntensity, gradient );

                // afterglow -- we couldn't accomplish this in the bloom
                lit += clamp( ( 0.35 * pow( gradient, 2.8 ) * color ), fixed4( 0, 0, 0, 1 ), fixed4( 1, 1, 1, 1 ) );
				return lit;
			}
	        
	        fixed4 frag (VS_OUT i) : COLOR
	        {
                float4 original = tex2D( _MainTex, i.uv);
				fixed4 outColor = spotlight( original, fixed4( _ScreenParams.xy * i.uv, 0, 0 ), _PlayerPosition, _PlayerColor );
	            return outColor;
	        }
	       
	        ENDCG
        }
	}
}
