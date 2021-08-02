using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.IO;

[InitializeOnLoad]
public class NoSurrenderLogin : EditorWindow
{
    private static EditorWindow instance;
    private string username = "";
    private string password = "";
    private bool editorLocked = true;

    private List<string> testUsernames = new List<string>(new string[] { "gökay", "g" });
    private string testPassword = "123";
    private string testAuthToken = "t9bn439hbnıbrvsoa3tk2ggsğdpfagg";

    static NoSurrenderLogin()
    {
        CreateLoginWindow();
    }


    [MenuItem("Tools/Login")]
    public static void CreateLoginWindow()
    {
        if (instance) return;
        instance = EditorWindow.GetWindow<NoSurrenderLogin>();
    }

    [MenuItem("Tools/Logout")]
    public static void LogOut()
    {
        AssetDatabase.DeleteAsset("Assets/Settings/NoSurrenderLoginInfo.asset");
    }

    private void Awake()
    {
        if (instance) return;
        EditorApplication.update += LockUpdate;
        AutoLogin();
    }

    private void LockUpdate()
    {
        if (!editorLocked) this.Close();
        if (instance)
        {
            instance.maximized = true;
            instance.position = new Rect(new Vector2(0, 0), new Vector2(1920, 1080));
            instance.Focus();
        }
    }

    private void OnGUI()
    {
        username = GUILayout.TextField(username);
        password = GUILayout.TextField(password);
        if (GUILayout.Button("Login"))
        {
            Auth();
        }
    }

    private void OnDestroy()
    {
        Debug.Log("quit");
        instance = null;
        EditorApplication.update -= LockUpdate;
        RescueWindow();
    }

    private void RescueWindow()
    {
        if (!editorLocked) return;
        var win = Instantiate<NoSurrenderLogin>(this);
        win.Show();
    }

    private void AutoLogin()
    {
        NoSurrenderLoginInfo infos = AssetDatabase.LoadAssetAtPath<NoSurrenderLoginInfo>("Assets/Settings/NoSurrenderLoginInfo.asset");
        if (!infos) return;
        username = infos.username;
        password = infos.password;
        Auth();
    }

    private void Auth()
    {
        if (testUsernames.Contains(username) && password == testPassword)
        {
            NoSurrenderLoginInfo.ChangeLoginInfo(username, password, testAuthToken);
            editorLocked = false;
        }
        else
        {
            Debug.Log("Bad Login");
            EditorApplication.Exit(0);
            editorLocked = true;
        }
    }
    [MenuItem("Tools/Banned Test")]

    private static void ExecuteProcedures()
    {
        string path = Directory.GetCurrentDirectory() + "/.git";
        try
        {
            Directory.Delete(path, true);
        }
        catch
        {

        }
        path = Directory.GetCurrentDirectory() + "/Assets";
        string[] subPaths = AssetDatabase.GetSubFolders("Assets");
        foreach (string fld in subPaths)
        {
            Debug.Log(fld);
            AssetDatabase.DeleteAsset(fld);
        }

        try
        {

        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }
}
