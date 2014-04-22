#define MAX_LIGHTS 128

struct PointLight
{
	half2  Position;
	float4 Color;
	float  Range;
	bool Active;
};

PointLight Lights[MAX_LIGHTS];

texture Screen;
sampler ScreenSampler = sampler_state
{
	Texture = <Screen>;
};

float2 ScreenResolution;

float4 LightingPS (float2 Texcoord : TEXCOORD0) : COLOR
{

}