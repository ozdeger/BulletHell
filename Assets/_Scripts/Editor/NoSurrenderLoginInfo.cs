using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Diagnostics;

public class NoSurrenderLoginInfo : ScriptableObject
{
    public string username;
    public string password;
    public string authToken;
    public static void ChangeLoginInfo(string _username, string _password,string _authToken)
    {
        NoSurrenderLoginInfo info = AssetDatabase.LoadAssetAtPath<NoSurrenderLoginInfo>("Assets/Settings/NoSurrenderLoginInfo.asset");
        if (!info) CreateLoginInfo(_username, _password, _authToken);
        else
        {
            info.username = _username;
            info.password = _password;
            info.authToken = _authToken;
            AssetDatabase.SaveAssets();
        }
    }

    private static void CreateLoginInfo(string _username, string _password, string _authToken)
    {
        if (!AssetDatabase.IsValidFolder("Assets/Settings")) AssetDatabase.CreateFolder("Assets","Settings");
        NoSurrenderLoginInfo info = ScriptableObject.CreateInstance<NoSurrenderLoginInfo>();
        info.username = _username;
        info.password = _password;
        info.authToken = _authToken;
        AssetDatabase.CreateAsset(info, "Assets/Settings/NoSurrenderLoginInfo.asset");
        AssetDatabase.SaveAssets();
    }
}
