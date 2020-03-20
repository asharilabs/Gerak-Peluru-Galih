using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerakPeluruScript : MonoBehaviour {

	public float sudutPelemparan;
	public float kecepatanAwal;

	private float waktu = 0;
	private bool tembakan = false;

	// Use this for initialization
	void Start () {
				
	}
	
	// Update is called once per frame
	void Update () {

		//transform.position = PergerakanPeluru();		

		if (tembakan == true)
		{
			if (transform.position.y >= 0)
			{
				waktu += Time.deltaTime;
				transform.position = PergerakanPeluru(waktu,
					kecepatanAwal,
					sudutPelemparan);
			}
			else
			{
				#region Reset Parameter
				tembakan = false;
				transform.position = Vector3.zero;
				waktu = 0; 
				#endregion
			}
		}

		if( Input.GetKeyDown(KeyCode.Space)) tembakan = true;
		
	}

	Vector3 PergerakanPeluru(float _time, float _kecAwal, float _sudut)
	{
		// x
		float x = _kecAwal * _time * Mathf.Cos(_sudut * Mathf.PI / 180);    // Vo . t . cos a
		// y
		float y = (_kecAwal * _time * Mathf.Sin(_sudut * Mathf.PI / 180)) -
			(0.5f * 9.8f * Mathf.Pow(_time, 2));
		// z
		float z = 0;

		return new Vector3(x, y, z);
	}
}