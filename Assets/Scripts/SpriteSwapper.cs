using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSwapper : MonoBehaviour
{

	[SerializeField] private Texture[] _textures;
	private int _number;

	public void SwapSprite()
	{
		GetComponent<Renderer>().material.mainTexture = _textures[_number];
		_number++;
		if (_number < _textures.Length)
		{
			_number = 0;
		}
	}

	public void SwapSpecificSprite(int number)
	{
		GetComponent<Renderer>().material.mainTexture = _textures[number];
	}
}
