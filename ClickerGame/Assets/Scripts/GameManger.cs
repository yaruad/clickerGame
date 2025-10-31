using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class SaveData
{

}

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

    public int width; //최대 직원 수
    public float space;

    public GameObject moneyPrefab;
    public GameObject employeePrefab;
    public GameObject panelPrice;
    public GameObject panelRecruit;
    public GameObject moneyobj;
    public GameObject recruitobj;

    public Button buttonPrice;
    public Button buttonRecruit;

    public TextMeshProUGUI money_txt;
    public TextMeshProUGUI price_txt;
    public TextMeshProUGUI peson_txt;
    public TextMeshProUGUI recruit_txt;

    void Start()
    {
        moneyIncreaseAmount = 100;
        moneyIncreasePrice = 200;
        employeeIncreasePrice = 500;

    }

    private void Awake()
    {
        gm = this;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        UpdateUI();
        MoneyIncrease();
        UpdateUpgradePanel();
        ButtonActiveCheack();
        UpdateRecruitPanel();
    }

    void UpdateUI()
    {
        money_txt.text = $"{money:F0}원";

        peson_txt.text = $"{employeeCount:F0}명";
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

    public void UpgradeRecruit()
    {
        if (money >= employeeIncreasePrice)
        {
            money -= employeeIncreasePrice;
            employeeCount++;
            employeeIncreasePrice = employeeCount * 1000;

            CreateEmployee();

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
            buttonRecruit.interactable= false;
        }
    }

    public void MoneyPanelSwitch()
    {
        moneyobj.SetActive(!moneyobj.activeSelf);

    }

    public void RecruitPanelSwitch()
    {
        recruitobj.SetActive(!recruitobj.activeSelf);
    }

    void CreateEmployee()
    {
        Vector2 bossSpot = GameObject.Find("boss").transform.position;

        float employeeX = bossSpot.x + (employeeCount % width) * space;
        float employeeY = bossSpot.y - (employeeCount / width) * space;

        Instantiate(employeePrefab, new Vector2(employeeX,employeeY), Quaternion.identity);
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetString("MONEY", money.ToString());
    }

    void Save()
    {
        SaveData saveData = new SaveData();
    }

    void Load()
    {
        SaveData saveData = new SaveData();
    }

    void FillEmployee()
    {
        GameObject[] employees = GameObject.FindGameObjectsWithTag("Employee");
        if (employeeCount != employees.Length)
        {
            for (int i = employees.Length; i <= employeeCount; i++)
            {

            }
        }
    }

    
}
