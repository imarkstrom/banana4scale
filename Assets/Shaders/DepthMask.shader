Shader "Custom/DepthMaskPassTwo" {

	SubShader{
		// Render the mask after regular geometry, but before masked geometry and
		// transparent things.

		Tags{ "Queue" = "Geometry-8" }

		// Don't draw in the RGBA channels; just the depth buffer
		ZTest Off
		ColorMask 0
		ZWrite On


		// Do nothing specific in the pass:

		Pass{}
	}
}

