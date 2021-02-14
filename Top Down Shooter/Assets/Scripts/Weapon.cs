using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] Transform shotPoint;
    [SerializeField] float timeBetweenShots;

    private float shotTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // mouse position minus the weapon's position, cinonvert muna si Input.mousePosition to WorldPoint, kasi pixels ang return niya
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        
        //transform the direction to an angle multiplied by Mathf.Rad2Deg para maconvert yung radians to degrees
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // convert angle to unity rotation (-90 para tama yung calibration ng mouse)
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward); // rotate it on the z axis

        transform.rotation = rotation;

        if (Input.GetMouseButton(0))
        {
            if(Time.time >= shotTime)
            {
                Instantiate(projectile, shotPoint.position, transform.rotation);
                shotTime = Time.time + timeBetweenShots;
            }
        }
    }
}
