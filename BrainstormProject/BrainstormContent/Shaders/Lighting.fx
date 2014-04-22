#define MAX_LIGHTS 128

struct PointLight
{
	half2  Position;
	float4 Color;
	float  Range;
	bool Active;
};

half2 res;

PointLight Lights[MAX_LIGHTS];

half2 GetScreenSpaceCoordinates ( float2 uv)
{
	half2 ss = half2(uv.x*res.x,uv.y*res.y);
    return ss;
}
texture Screen;
sampler ScreenSampler = sampler_state
{
	Texture = <Screen>;
};

float4 LightingPS (float2 Texcoord : TEXCOORD0) : COLOR
{

}