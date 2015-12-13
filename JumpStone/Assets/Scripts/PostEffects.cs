using UnityEngine;
using System.Collections;

public class PostEffects : MonoBehaviour {
	public Shader postFXShader = null;
	private Material mat;
	private GameObject player;

	// Use this for initialization
	void Start () {
		if (postFXShader)
		{
			mat = new Material(postFXShader);
			mat.name = "PostFXMaterial";
			mat.hideFlags = HideFlags.HideAndDontSave;
		}
		
		else
		{
			Debug.LogWarning(gameObject.name + ": Post FX Shader is not assigned. Disabling...", this.gameObject);
			enabled = false;
		}
	}
	
	void OnRenderImage(RenderTexture src, RenderTexture dst)
	{
		if (postFXShader && mat)
		{
			Graphics.Blit(src, dst, mat);
		}
		else
		{
			Graphics.Blit(src, dst);
			Debug.LogWarning(gameObject.name + ": Post FX Shader is not assigned. Disabling...", this.gameObject);
			enabled = false;
		}
	}

	void Update()
	{
		if ( player == null ) player = GameObject.FindGameObjectWithTag( "Player" );
		if ( player != null ) mat.SetVector("_PlayerPosition", Camera.main.WorldToScreenPoint( player.transform.position ) );
	}

	void OnDisable()
	{
	}
}
