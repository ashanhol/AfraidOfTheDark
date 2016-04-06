using UnityEngine;
using System.Collections;

public class SetTransparency : MonoBehaviour {

	// Use this for initialization
	void Start () {
        SpriteRenderer spRend = gameObject.transform.GetComponent<SpriteRenderer>();
        Color col = spRend.color;
        col.a = 0.5f;
        spRend.color = col;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
