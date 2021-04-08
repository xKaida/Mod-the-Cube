using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;

    //bool for checking if the cube gets big or small at the moment
    bool getBig = true;

    //these global variables get used in Update and are randomized in RandomCube
    private float maxScale;
    private float changeSizeRate;
    private Vector3 vectorScaleChange;
    private Vector3 vectorRotationChange;

    

    Material material;

    void Start()
    {
        material = Renderer.material;
        RandomCube();
    }
    
    void Update()
    {
        //makes cube get big up until the randomized maxScale
        if(getBig)
        {
            transform.localScale += vectorScaleChange;
            if (transform.localScale.x > maxScale) getBig = false;
        }
        //cube gets smaller until the scale reaches 0
        else
        {
            transform.localScale -= vectorScaleChange;
            //if the cubes scale reaches 0, randomize values and make cube get big again
            if (transform.localScale.x < 0)
            {
                getBig = true;
                RandomCube();
            }
        }
        transform.Rotate(vectorRotationChange*Time.deltaTime);
    }
    void RandomCube()
    {
        //randomize rate at which cube grows/shrinks
        changeSizeRate = Random.Range(0.01f, 0.02f);
        vectorScaleChange = new Vector3(changeSizeRate, changeSizeRate, changeSizeRate);

        //randomized maximum scale
        maxScale = Random.Range(2f, 4f);

        //randomized position at which the cube appears
        transform.position = new Vector3(0, Random.Range(-10, 11), Random.Range(-20, 21));

        //randomize color, opacity is kept at above half
        material.color = new Color(Random.Range(0,1f), Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0.5f, 1f));
        
        //float array to store vector3 values in(3 floats)
        float[] randomRotations = new float[3];

        //loop for randomizing x,y,z
        for (int i = 0; i < 3; i++)
        {
            /*
            note that I randomized getting positive and negative values to prevent cubes with near 
            0 rotation from appearing(as opposed to just randomizing between -120 and 120)
            also Random.Range(0, 2) returns either 0 or 1 so it's a 50/50 chance
            */
            int rando = Random.Range(0, 2);
            if (rando == 0)
            {
                randomRotations[i] = Random.Range(30f, 120f);
            }
            else
            {
                randomRotations[i] = Random.Range(-120f, -30f);
            }
        }
        //store the 3 randomized values from float array in vector3
        vectorRotationChange = new Vector3(randomRotations[0], randomRotations[1], randomRotations[2]);
    }
}
