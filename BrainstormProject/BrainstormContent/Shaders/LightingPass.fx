#define MAX_SUPPORTED_LIGHTS 128

struct PointLight2D
{
    half2  Position;
    float4 Color;
    float  Intensity;
    float  Range;
    bool   Enabled;
};

PointLight2D EngineLights[MAX_SUPPORTED_LIGHTS];

float2 PositionToScreenSpace (half2 Position, float2 UV )
{
    return half2 ( ( Position.x * UV.x ) , ( Position.y * UV.y ) );
}

struct PixelShaderInput
{
    float2 UV : TEXCOORD;
};

struct PixelShaderOutput
{
    float4 Color : COLOR0;
};

PixelShaderOutput LightingPassPS( PixelShaderInput input )
{
    float4 ScreenSample = tex2D ( ScreenSampler , input.UV );
}

technique LightingPass
{
    pass MainPass
    {
        
    }
}
