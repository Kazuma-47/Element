                                                                                                                                                    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHandler : MonoBehaviour
{
    [Header("Spell Debug Configuration")]
    [HideInInspector] private Elements spellElement;
    [SerializeField] private float spellLifetime = 4f;
    [SerializeField] private bool onActive;
    private float timer ;
    public void ActivateAbility(Elements element)
    {
        timer = spellLifetime;
        spellElement = element;
        onActive = true;
        switch (spellElement)
        {
            case Elements.Fire:
                //show the fire elemnt  
                break;
            case Elements.Water:
                //show the water element
                break;
            case Elements.None:
                //blank bullets to catch errors
                break;
            default:
                //Debug error
                break;
        }
    }

    private void Update()
    {
        if (onActive)
        {
            timer -= Time.deltaTime;
            if(timer <= 0f)
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        // checks if the object is a manipulatable and if so calls a function that will effect it
        ObjectManipulator _objectManipulator = collision.gameObject.GetComponent<ObjectManipulator>();
        if(_objectManipulator != null)
        {
            switch (spellElement)
            {
                case Elements.Fire:
                    _objectManipulator.DamageObject();
                    Destroy(gameObject);
                    break;
                case Elements.Water:
                    _objectManipulator.GrowObject();
                    Destroy(gameObject);
                    break;
            }
        }
    }

}
