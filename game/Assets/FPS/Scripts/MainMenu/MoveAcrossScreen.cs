using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAcrossScreen : MonoBehaviour
{

    float move_per_frame = 0.1F;
    bool forward = true;

    Quaternion forwardRotation;
    Quaternion backwardsRotation;
    
    private Vector3 randomBird()
    {
        Vector3 SpawnPosition;

        if(forward) 
        {
            SpawnPosition.x = 55;
            forward = false;
        }
        else
        {
            SpawnPosition.x = -55;
            forward = true;
        }

        SpawnPosition.z = Random.Range(0F,100F);
        SpawnPosition.y = Random.Range(55F,80F);

        return SpawnPosition;
    }

    // Start is called before the first frame update
    void Start()
    {
        Vector3 spawnposition = Vector3.zero;

        spawnposition.Set(55,60,0);

        backwardsRotation = transform.rotation;
        forwardRotation = Quaternion.Inverse(transform.rotation);

        transform.rotation = forwardRotation;
        transform.position = spawnposition;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 position;
        Quaternion rotation;

        position = transform.position;
        rotation = transform.rotation;

        if (forward)
        {
            position.x += move_per_frame;
            if (position.x >= 55)
            {
                position = randomBird();
                rotation = forwardRotation;
            }
        }
        else
        {
            position.x -= move_per_frame;
            if (position.x <= -60)
            {
                position = randomBird();
                rotation = backwardsRotation;
            }
        }

       

        transform.position = position;
        transform.rotation = rotation;

    }
}
