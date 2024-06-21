using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private GameObject weapon;

    [SerializeField]
    private Transform shootTransform;

    [SerializeField]
    private float shootInterval = 0.01f;
    private float lastShootTime = 0f;

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float toX = Mathf.Clamp(mousePos.x, -2.35f, 2.35f);
        transform.position = new Vector3(toX, transform.position.y, transform.position.z);

        Shoot();

    }
    void Shoot(){
        if(Time.time - lastShootTime > shootInterval){
            Instantiate(weapon, shootTransform.position, Quaternion.identity );
            lastShootTime = Time.time;
        }
    }
}