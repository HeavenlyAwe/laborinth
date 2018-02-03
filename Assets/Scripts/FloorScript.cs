﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScript : MonoBehaviour {

	//public Dictionary<Color32, int> colorMap = new Dictionary<Color32, int>();
	public GameObject[] preFabs = new GameObject[16];
	public GameObject[] objectGO = new GameObject[16];

    // Use this for initialization

    void Start () {
        //colorMap.Add(new Color32(255, 255, 255, 255),0);     //white
       // colorMap.Add(new Color32(0, 0, 0, 255),0);          //tapet+panel
       // colorMap.Add(new Color32(0, 0, 255, 255),1);     //kakel

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Texture2D tex = sr.sprite.texture;

        int w = tex.width;
        int h = tex.height;


        Color32[] c = tex.GetPixels32();

        for (int x = 0; x<w; x++)
        {
            for( int y = 0; y<h; y++)
            {
                //int colorInteger = colorMap[c[x+w*y]];
				GameObject tmpGO;

                //Debug.Log("HEJ");
                //Debug.Log("COLOR: "+ c[x+w*y]);
                int index = (int)(c[x+w*y].r / 16);

                //Debug.Log(index);
                //Debug.Log(preFabs(index));

                if(index < 2) {
                        tmpGO = Instantiate(preFabs[index], new Vector3((float)(x*0.2), 0, (float)(y*0.2)), Quaternion.identity);
                        //tmpGO = Instantiate(preFabs[colorInteger], new Vector3(x, 0, y), Quaternion.identity);
                        tmpGO.transform.parent = objectGO[index].transform;
                } else {
                    //tmpGO = Instantiate(preFabs[3], new Vector3((float)(x*0.2), 0, (float)(y*0.2)), Quaternion.identity);
                    //tmpGO = Instantiate(preFabs[colorInteger], new Vector3(x, 0, y), Quaternion.identity);
                    //tmpGO.transform.parent = objectGO[3].transform;
                }
					 
			}
        }
            
        sr.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
