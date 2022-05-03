using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tavern : MonoBehaviour
{
    [SerializeField] SelectableObject ringSelector;
    [SerializeField] GameObject HUDPanel;
    [SerializeField] Transform spawnWarrior;
    [SerializeField] GameObject warrior;

    Almacen almacen;

    // mensaje de error de buildingHUD (dentro del townhall)
    public GameObject errMess;

    private bool itsSelected = false;

    void Start()
    {
        almacen = FindObjectOfType<Almacen>();

    }

    public void Selected()
    {
        ringSelector.TurnOnSelector();
        itsSelected = true;
        HUDPanel.SetActive(true);
    }

    public void Unselected()
    {
        ringSelector.TurnOffSelector();
        itsSelected = false;
        HUDPanel.SetActive(false);

    }

    public void SpawnWarrior()
    {
        //Instantiate(villager, spawnVillager.position, Quaternion.identity);

        if (almacen.food > 20 && almacen.rock > 10)
        {

            WarSpawn();
        }
        else
        {
            errMess.SetActive(true);
            StartCoroutine("messageDis");
        }
    }

    public void WarSpawn()
    {

        Instantiate(warrior, spawnWarrior.position, Quaternion.identity);
        almacen.food -= 20;
    }

    IEnumerator messageDis()
    {
        yield return new WaitForSeconds(1f);
        errMess.SetActive(false);
    }
}
