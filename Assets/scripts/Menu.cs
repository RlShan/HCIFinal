using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Menu : MonoBehaviour
{
    [SerializeField] private RectTransform items,line;
    [SerializeField] private Material[] colors;
    [SerializeField] private TMP_Dropdown colorDropDown;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void OnChairs()
    {
        LeanTween.value(items.anchorMin.x, 0, 1f).setOnUpdate(OnValueMinChange);
        LeanTween.value(items.anchorMax.x, 1, 1f).setOnUpdate(OnValueMaxChange);
        Debug.Log("OnClick");
    }
    public void OnTables()
    {
        LeanTween.value(items.anchorMin.x, -1, 1f).setOnUpdate(OnValueMinChange);
        LeanTween.value(items.anchorMax.x, 0, 1f).setOnUpdate(OnValueMaxChange);
        Debug.Log("OnClick");

    }
    public void OnSofa()
    {
        LeanTween.value(items.anchorMin.x, -2, 1f).setOnUpdate(OnValueMinChange);
        LeanTween.value(items.anchorMax.x, -1, 1f).setOnUpdate(OnValueMaxChange);
    }
    private void OnValueMinChange(float val)
    {
        items.anchorMin = new Vector2(val, 0);
    }
    private void OnValueMaxChange(float val)
    {
        items.anchorMax = new Vector2(val, 1);
    }
    public void ShiftLine(float val)
    {
        LeanTween.value(line.anchorMin.x, val, 1f).setOnUpdate(OnLineChange);
    }
    private void OnLineChange(float val)
    {
        line.anchorMin = new Vector2(val, 0.75f);
        line.anchorMax = new Vector2(val, 0.75f);

    }
    public void OnColorChange()
    {
        for(int i = 0; i < items.transform.childCount - 1; i++)
        {
            items.transform.GetChild(i).GetComponent<MeshRenderer>().material = colors[colorDropDown.value];
        }
    }
}
