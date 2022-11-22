using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGun : MonoBehaviour
{
    public GameObject trigger;
    public float defaultRotation = 90f;
    public float maxRotation = 40f;
    public GameObject barrel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RotateTrigger(float val)
    {
        float actualRotation = maxRotation * val;
        trigger.transform.localEulerAngles = new Vector3(defaultRotation -actualRotation, trigger.transform.localEulerAngles.y, trigger.transform.localEulerAngles.z);
    }
    
    
    public void Shoot()
    {
        if (Physics.Raycast(barrel.transform.position, barrel.transform.forward, out RaycastHit hitData, 100f))
        {
            Enemy hitEnemy = hitData.transform.GetComponent<Enemy>();
            if (hitEnemy != null)
            {
                hitEnemy.Kill();
            }
        }
    }
}
