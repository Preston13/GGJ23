using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Clock : MonoBehaviour
{
    public TextMeshProUGUI clockFace;
    [SerializeField]
    float hour;
    [SerializeField]
    float minute;
    [SerializeField]
    float second;
    FarmManager manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = GetComponent<FarmManager>();
    }

    // Update is called once per frame
    void Update()
    {
        second += Time.deltaTime * 2400;
        if (second >= 60)
        {
            minute++;
            second = 0;
        }
        if (minute >= 60)
        {
            hour++;
            minute = 0;
        }
        if (hour >= 24)
        {
            hour = 0;
            manager.UpdateMoney(-20);
        }
        clockFace.text = $"{hour.ToString("00")}:{minute.ToString("00")}";
    }
}
