using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KongregateApi : MonoBehaviour {

    private static KongregateApi instance;

    public void Start() {
        if (instance == null) {
            instance = this;
        }
        else if (instance != this) {
            Destroy(gameObject);
            return;
        }

        Object.DontDestroyOnLoad(gameObject);
        gameObject.name = "KongregateAPI";

        Application.ExternalEval(
          @"if(typeof(kongregateUnitySupport) != 'undefined'){
        kongregateUnitySupport.initAPI('KongregateAPI', 'OnKongregateAPILoaded');
      };"
        );
    }

    public void OnKongregateAPILoaded(string userInfoString) {
        OnKongregateUserInfo(userInfoString);
    }

    public void OnKongregateUserInfo(string userInfoString) {
        var info = userInfoString.Split('|');
        var userId = System.Convert.ToInt32(info[0]);
        var username = info[1];
        var gameAuthToken = info[2];
    }

    public static void SendStatistic(string statistic, int value) {
        GameObject api = GameObject.Find("KongregateAPI");

        if (api == null) {
            return;
        }

        api.GetComponent<KongregateApi>().SendAPIStatistic(statistic, value);
    }

    public void SendAPIStatistic(string statistic, int value) {
        Application.ExternalCall("kongregate.stats.submit", statistic, value);
    }
}
