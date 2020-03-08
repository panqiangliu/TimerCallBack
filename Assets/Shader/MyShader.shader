.Shader "LPQ/MyShader"
{
	Properties
	{
	}

	SubShader
	{
		Pass
	{
#pragma vertex vert	
#pragma fragment frag



		struct a2v
	{
		float4 pos : POSITION;  //颜色的RGBA值  xyzw
		float2 uv:TEXCOORD0;
	};

	//顶点函数

	struct v2f
	}
		float4 svpos:SV_POSITION;
	}
