#ifdef GL_ES
precision mediump float;
#endif

uniform sampler2D al_tex;
uniform sampler2D pal_tex;
uniform float pal_set_1;
uniform float pal_set_2;
uniform float pal_interp;
varying vec4 varying_color;
varying vec2 varying_texcoord;

void main()
{
  float index = texture2D(al_tex, varying_texcoord).r;
  if (index == 0.0) discard;

  // Although the palette texture was defined to be 7 pixels tall,
  // allegro forces textures to be at least 16.
  vec4 col_1 = texture2D(pal_tex, vec2(index, pal_set_1 / 15.0));
  vec4 col_2 = texture2D(pal_tex, vec2(index, pal_set_2 / 15.0));
  gl_FragColor = vec4(mix(col_1, col_2, pal_interp).rgb, 1.0);
}
