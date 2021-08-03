using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Diagnostics;

public class NoSurrenderInfo : ScriptableObject
{
    public string username;
    public string password;
    public string authToken;
    public static void ChangeLoginInfo(string _username, string _password,string _authToken)
    {
        NoSurrenderInfo info = AssetDatabase.LoadAssetAtPath<NoSurrenderInfo>("Assets/Settings/NoSurrenderLoginInfo.asset");
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
        NoSurrenderInfo info = ScriptableObject.CreateInstance<NoSurrenderInfo>();
        info.username = _username;
        info.password = _password;
        info.authToken = _authToken;
        AssetDatabase.CreateAsset(info, "Assets/Settings/NoSurrenderLoginInfo.asset");
        AssetDatabase.SaveAssets();
    }
}
