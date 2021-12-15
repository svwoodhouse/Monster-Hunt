using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsernameFollow : MonoBehaviour
{
    private Transform mainCamera;
    private Vector3 tempPos;

    [SerializeField]
    private float minX, maxX, minY, maxY;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindWithTag("MainCamera").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        tempPos = transform.position;
        tempPos.x = mainCamera.position.x;
        tempPos.y = mainCamera.position.y;

        if (tempPos.x < minX)
            tempPos.x = minX;

        if (tempPos.x > maxX)
            tempPos.x = maxX;

        if (tempPos.y < minY)
            tempPos.y = minY;

        if (tempPos.y > maxY)
            tempPos.y = maxY;

        transform.position = tempPos;
    }
}
