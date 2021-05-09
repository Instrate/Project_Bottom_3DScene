#version 330
out vec4 outputTexture;

out vec4 FragColor;

in vec2 texCoord;

uniform sampler2D texture0;

void main()
{
    FragColor = vec4(1.0);
    outputTexture = texture(texture0, texCoord);
}