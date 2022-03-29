using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelection : MonoBehaviour
{
    public List<Unit> unitList = new List<Unit>();
    public List<Unit> unitSelected = new List<Unit>();

    private static UnitSelection _instance;
    public static UnitSelection Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void SelectClick(Unit unitAdd)
    {
        DeselectAll();
        unitSelected.Add(unitAdd);
        unitAdd.Selected();
    }

    public void ShiftClickSelect(Unit unitAdd)
    {
        if (!unitSelected.Contains(unitAdd))
        {
            unitSelected.Add(unitAdd);
            unitAdd.Selected();
        }
        else
        {
            unitSelected.Remove(unitAdd);
            unitAdd.Unselected();
        }
    }

    public void DragSelect (Unit unitAdd)
    {
        if (!unitSelected.Contains(unitAdd))
        {
            unitSelected.Add(unitAdd);
            unitAdd.Selected();
        }
    }

    public void DeselectAll()
    {

        foreach(Unit unit in unitSelected)
        {
            unit.Unselected();
        }
        unitSelected.Clear();
        
    }

    public void Deselect(Unit unitDeselect)
    {

    }

}
