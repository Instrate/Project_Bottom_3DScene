#version 440 core

layout (location = 0) in vec3 aPos;
layout (location = 1) in vec3 aNormal;
layout(location = 2) in vec2 aTexCoord;

out vec2 texCoord;
out vec3 Normal;
out vec3 FragPos;

uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;

void main(void)
{
    texCoord = aTexCoord;
    gl_Position = vec4(aPos, 1.0) * model * view * projection;
    FragPos = vec3(vec4(aPos, 1.0) * model);
    Normal = aNormal * mat3(transpose(inverse(model)));
}
