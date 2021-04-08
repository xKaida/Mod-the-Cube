using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    bool getBig = true;
    private float maxScale;
    private float changeSizeRate;
    private Vector3 vectorChange;
    float randomX;
    float randomY;
    float randomZ;

    Material material;

    void Start()
    {
        material = Renderer.material;
        RandomCube();
    }
    
    void Update()
    {
        if(getBig)
        {
            transform.localScale += vectorChange;
            if (transform.localScale.x > maxScale) getBig = false;
        }
        else
        {
            transform.localScale -= vectorChange;
            if (transform.localScale.x < 0)
            {
                getBig = true;
                RandomCube();
            }
        }
        transform.Rotate(randomX * Time.deltaTime, randomY * Time.deltaTime, randomZ * Time.deltaTime);
    }
    void RandomCube()
    {
        changeSizeRate = Random.Range(0.01f, 0.02f);
        vectorChange = new Vector3(changeSizeRate, changeSizeRate, changeSizeRate);
        maxScale = Random.Range(2f, 4f);
        transform.position = new Vector3(0, Random.Range(-10, 11), Random.Range(-20, 21));
        material.color = new Color(Random.Range(0,1f), Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0.5f, 1f));
        int rando = Random.Range(0, 2);
        if(rando == 0)
        {
            randomX = Random.Range(30f, 120f);
        }
        else
        {
            randomX = Random.Range(-30f, -120f);
        }
        rando = Random.Range(0, 2);
        if (rando == 0)
        {
            randomY = Random.Range(30f, 120f);
        }
        else
        {
            randomY = Random.Range(-30f, -120f);
        }
        rando = Random.Range(0, 2);
        if (rando == 0)
        {
            randomZ = Random.Range(30f, 120f);
        }
        else
        {
            randomZ = Random.Range(-30f, -120f);
        }
    }
}
