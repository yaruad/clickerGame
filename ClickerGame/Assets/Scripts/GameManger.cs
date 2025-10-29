using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class GameManger : MonoBehaviour
{
    public static GameManger gm;

    public long money = 0;
    public long moneyIncreaseAmount;
    public long moneyIncreaseLevel;
    public long moneyIncreasePrice;

    public int employeeCount;
    public long employeeIncreasePrice;
    public long employeeIncreaseAmount;

    public GameObject moneyPrefab;
    public GameObject panelPrice;
    public GameObject panelRecruit;
    public GameObject moneyobj;
    public GameObject recruitobj;

    public Button buttonPrice;
    public Button buttonRecruit;

    public TextMeshProUGUI money_txt;
    public TextMeshProUGUI price_txt;
    public TextMeshProUGUI recruit_txt;
    void Start()
    {
        moneyIncreaseAmount = 100;
        moneyIncreasePrice = 200;

    }

    private void Awake()
    {
        gm = this;
    }


    void Update()
    {
        UpdateUI();
        MoneyIncrease();
        UpdateUpgradePanel();
        ButtonActiveCheack();
        UpdateRecruitPanel();
    }

    void UpdateUI()
    {
        money_txt.text = $"{money:F0}원";
    }

    void MoneyIncrease()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject() == false)
            { 
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                GameObject obj = Instantiate(moneyPrefab, mousePosition, Quaternion.identity);
                money += moneyIncreaseAmount;
            }
        }
    }

    void UpdateUpgradePanel()
    {
        if (panelPrice.activeSelf == true)
        {
            price_txt.text = $"Lv.{moneyIncreaseLevel:F0}\n 외주 당 단가:{moneyIncreaseAmount:F0}\n 업그레이드 가격:{moneyIncreasePrice:F0}";
        }
    }
    void UpdateRecruitPanel()
    {
        if (panelRecruit.activeSelf == true)
        {
            recruit_txt.text = $"Lv.{employeeCount:F0}\n 직원 당 단가:{employeeIncreaseAmount:F0}\n 업그레이드 가격:{employeeIncreasePrice:F0}";
        }
    }
    public void UpgradePrice()
    {
        if (money >= moneyIncreasePrice)
        {
            money -= moneyIncreasePrice;
            moneyIncreaseLevel++;
            moneyIncreaseAmount = moneyIncreaseLevel * 100;
            moneyIncreasePrice = moneyIncreaseLevel * 500;
        }
    }
    public void ButtonActiveCheack()
    {
        if (money >= moneyIncreasePrice)
        {
            buttonPrice.interactable = true;
        }
        else
        {
            buttonPrice.interactable= false;
        }

        if (money >= employeeIncreasePrice)
        {
            buttonRecruit.interactable = true;
        }
        else
        {
            buttonRecruit.interactable=! false;
        }
    }

    public void PanelSwitch()
    {
        moneyobj.SetActive(!moneyobj.activeSelf);
        recruitobj.SetActive(!recruitobj.activeSelf);
    }
}
