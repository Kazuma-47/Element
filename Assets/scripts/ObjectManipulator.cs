using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManipulator : MonoBehaviour
{
    private float shrinkAmount = 0.7f;
    private float growAmount = 0.7f;
    public void DamageObject()
    {
        if (transform.localScale.y == 0.5f)
        {
            Debug.Log("Object can shrink anymore");
        }
        else
        { 
            Vector3 currentScale = transform.localScale;
            currentScale.y -= shrinkAmount;
            currentScale.y = Mathf.Max(currentScale.y, 0.5f);

            Vector3 currentPosition = transform.position;
            currentPosition.y -= shrinkAmount / 2.0f;

            transform.localScale = currentScale;
            transform.position = currentPosition;
        }
    }
    public void GrowObject()
    {
        if (transform.localScale.y == 10f)
        {
            Debug.Log("Object can grow anymore");
        }
        Vector3 currentScale = transform.localScale;
        currentScale.y += growAmount;
        currentScale.y = Mathf.Min(currentScale.y, 10f);
        transform.localScale = currentScale;
    }

    public void ToggleGraffity()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        if(rigidbody != null)
        {
            if (rigidbody.useGravity == true)
                rigidbody.useGravity = false;
            else
                rigidbody.useGravity = true;
        }
        
    }
}


