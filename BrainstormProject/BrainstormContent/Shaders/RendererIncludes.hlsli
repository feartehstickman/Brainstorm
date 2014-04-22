#define NUM_SUPPORTED_LIGHTS 128

struct PointLight2D
{
	half2  Position;
	float4 Color;
	float  Range;
	float  Intensity;
	bool   Enabled;
};

half2 GetScreenSpaceCoordinates (float2 UV, half2 ScreenResolition)
{
	return half2(UV.x*ScreenResolition.x,UV.y*ScreenResolition.y);
}

PointLight2D EngineLights[NUM_SUPPORTED_LIGHTS];

void ResetLighting()
{
	[UNROLL]
	for ( int i = 0; i < NUM_SUPPORTED_LIGHTS; ++i )
	{
		EngineLights[i].Position = half2(0,0);
		EngineLights[i].Color = float4(0,0,0,0);
		EngineLights[i].Range = 0;
		EngineLights[i].Intensity = 0;
		EngineLights[i].Enabled = false;
	}
}