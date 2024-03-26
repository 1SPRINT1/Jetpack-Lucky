using System.Threading.Tasks;
using UnityEngine;
using Firebase.Extensions;
using Firebase.RemoteConfig;

public class FirebaseTemplate : MonoBehaviour
{
    public Firebase.FirebaseApp app = null;
    public static FirebaseTemplate instance;
    public LoadScreenTemplate Loader;
    private void Awake()
    {
        instance = this;
        InitializeFirebase();
    }
    public async void InitializeFirebase()
    {
        await Firebase.FirebaseApp.CheckAndFixDependenciesAsync()
        .ContinueWithOnMainThread(
           async previousTask =>
           {
               var dependencyStatus = previousTask.Result;
               if (dependencyStatus == Firebase.DependencyStatus.Available)
               {
                   app = Firebase.FirebaseApp.DefaultInstance;
                   await FetchRemoteConfig();
               }
               else
               {
                   UnityEngine.Debug.LogError(
                 $"Could not resolve all Firebase dependencies: {dependencyStatus}\n" +
                 "Firebase Unity SDK is not safe to use here");
               }
           });
    }
    public async Task FetchRemoteConfig()
    {
        if (app == null)
        {
            return;
        }

        var remoteConfig = FirebaseRemoteConfig.DefaultInstance;
        await remoteConfig.FetchAsync(System.TimeSpan.Zero).ContinueWithOnMainThread(
           async previousTask =>
           {
               if (!previousTask.IsCompleted)
               {
                   return;
               }
               await ActivateRetrievedRemoteConfigValues();
           });
    }
    private async Task ActivateRetrievedRemoteConfigValues()
    {
        var remoteConfig = FirebaseRemoteConfig.DefaultInstance;
        var info = remoteConfig.Info;
        if (info.LastFetchStatus == LastFetchStatus.Success)
        {
            await remoteConfig.ActivateAsync().ContinueWithOnMainThread(
               async previousTask =>
               {
                   await Task.Delay(100);
                   Loader.ProcessDownloadStart();
               });
        }
    }

    public string GetStringByKey(string key)
    {
        return FirebaseRemoteConfig.DefaultInstance.GetValue(key).StringValue;
    }

    public bool GetBooleanByKey(string key)
    {
        return FirebaseRemoteConfig.DefaultInstance.GetValue(key).BooleanValue;
    }
}
