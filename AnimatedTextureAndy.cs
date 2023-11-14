using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedTexture : MonoBehaviour
{
    //Declaring each member variable and method
    public Texture2D[] textures;
    public float framerate = 60;

    private float waitSeconds;
    private int numTextures;
    private int i = 0;
    private Material material;

    //Initialize to feed into main loop
    void Start()
    {
        material = gameObject.GetComponent<MeshRenderer>().material;
        numTextures = textures.Length;
        StartCoroutine(AnimateTexture());
    }

    //Dont know why, just need this here so that we can have the animated texture
    IEnumerator AnimateTexture()
    {
        while (true)
        {
            if (i == numTextures)
            {
                i = 0;
            }
            material.SetTexture("_BaseMap", textures[i]);
            i++;

            //delays the loop speed so that its not running at insane speed
            yield return new WaitForSeconds(waitSeconds);
        }
    }

    //This is the main loop that we supplied initial conditions to with void Start()
    void Update()
    {
        waitSeconds = 1 / framerate;
    }
}