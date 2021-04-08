#version 330

out vec4 outputColor;
out vec4 outputTexture;

in vec2 texCoord;
in vec3 color;

uniform sampler2D texture0;

void main()
{
    outputTexture = texture(texture0, texCoord);
    //outputColor = vec4(color, 1.0);
}