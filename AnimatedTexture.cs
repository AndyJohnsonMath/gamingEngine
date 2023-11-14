 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedTexture : MonoBehaviour
{
    // Start is called before the first frame update

    public Texture2D[] textures;
    public float framerate = 60;
    
    private float waitSeconds;
    private int numTextures;
    private int i = 0;
    private Material material;

    void Start()
    {
        material = gameObject.GetComponent<MeshRenderer>().material;
        numTextures = textures.Length;
        StartCoroutine(AnimateTexture());
    }

    IEnumerator AnimateTexture()
    {
        while (true)
        {
            if (i == numTextures)
            {
                i = 0;
            }
            material.SetTexture("_MainTex", textures[i]);
            i++;
            yield return new WaitForSeconds(waitSeconds);
        }
    }

    void Update()
    {
        waitSeconds = 1 / framerate;
    }
}