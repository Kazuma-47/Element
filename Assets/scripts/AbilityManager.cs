using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityManager : MonoBehaviour
{
     public Ability [] Abilities = new Ability[4];
     public Image [] playerUIElements = new Image[4];
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject castPoint;
   

    private int selectedAbility = 0;

    public void AddAbility(Ability ability)
    {
        for (int i = 0; i < Abilities.Length; i++)
        {
            if (Abilities[i] != null)
                continue;
            Abilities[i] = ability;
            playerUIElements[i].sprite = ability.Icon;
            Debug.Log(ability.Element + "added");
            return;
        }
        Debug.Log("No empty slots available.");
    }
    
    public void UseAbility()
    {
        if(Abilities[selectedAbility] != null)
        {
            GameObject _castElement = Instantiate(projectile, castPoint.transform.position, castPoint.transform.rotation);
            Rigidbody _projectile_RigidBody = _castElement.GetComponent<Rigidbody>();

            Vector3 _direction = castPoint.transform.forward;

            _projectile_RigidBody.AddForce(_direction * 15f, ForceMode.VelocityChange);
            _castElement.GetComponent<AbilityHandler>().ActivateAbility(Abilities[selectedAbility].Element);

            Abilities[selectedAbility] = null;
            playerUIElements[selectedAbility].sprite = null;
        }
    }
    public void ChangeSelectedAbility(int input)
    {
        selectedAbility = input;
    }

}
