using OneSignalSDK;
using UnityEngine;

public class OneSignalTemplate : MonoBehaviour
{
    public string APP_ID;
    public static OneSignalTemplate Instance;
    [SerializeField] private bool _wasApprove = false;
    private void Awake()
    {
        Instance = this;

        if (PlayerPrefs.HasKey("InitPushes"))
            _wasApprove = true;
        else
            _wasApprove = false;
    }

    void Start()
    {
        if (_wasApprove)
            InitOneSignal();
    }

    public void InitOneSignalWithPrompPushes()
    {
        OneSignal.Initialize(APP_ID);
        OneSignal.Notifications.RequestPermissionAsync(true);
        PlayerPrefs.SetInt("InitPushes", 1);
    }
    public void InitOneSignal()
    {
        OneSignal.Initialize(APP_ID);
        
    }
}
