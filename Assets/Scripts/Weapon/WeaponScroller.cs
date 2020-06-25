using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponScroller : MonoBehaviour
{
    [SerializeField] private RectTransform content;
    [SerializeField] private ScrollRect scrollRect;

    public List<RectTransform> weaponScrollList = new List<RectTransform>(); // -1650, 2100


    private void Start()
    {
        foreach (RectTransform child in content)
        {
            weaponScrollList.Add(child);
        }

        //StartCoroutine(ShowPosition());
    }

    private void Update()
    {
        if(weaponScrollList[0].position.x < -1650 - 300)
        {
            SortListRight();
            return;
        }

        if (weaponScrollList[weaponScrollList.Count - 1].position.x > 2100 + 300)
            SortListLeft();
    }

    private void SortListRight()
    {
        return;

        weaponScrollList[0].anchoredPosition = new Vector2(weaponScrollList[weaponScrollList.Count - 1].anchoredPosition.x + 290, weaponScrollList[0].position.y);
        RectTransform bubble = weaponScrollList[0];

        for(int i = 1; i < weaponScrollList.Count; i++)
        {
            weaponScrollList[i - 1] = weaponScrollList[i];
        }

        weaponScrollList[weaponScrollList.Count - 1] = bubble;
    }

    private void SortListLeft()
    {


    }

    IEnumerator ShowPosition()
    {
        yield return new WaitForSeconds(5);

        for(int i = 0; i < weaponScrollList.Count; i++)
        {
            Debug.Log(weaponScrollList[i].position.x);
        }

        foreach(RectTransform rect in weaponScrollList)
        {
            //Debug.Log(rect.position.x);
        }
    }
}
