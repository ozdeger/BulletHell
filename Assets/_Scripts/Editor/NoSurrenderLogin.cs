using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.IO;
using System.Linq;

[InitializeOnLoad]
public class NoSurrenderLogin : EditorWindow
{
    private static EditorWindow instance = null;
    private string username = "";
    private string password = "";
    private bool editorLocked = true;

    private List<string> testUsernames = new List<string>(new string[] { "gökay", "g" });
    private string testPassword = "123";
    private string testAuthToken = "t9bn439hbnıbrvsoa3tk2ggsğdpfagg";

    [MenuItem("Tools/Login")]
    public static void CreateLoginWindow()
    {
        RescueWindow();
    }

    [MenuItem("Tools/Logout")]
    public static void LogOut()
    {
        AssetDatabase.DeleteAsset("Assets/Settings/NoSurrenderLoginInfo.asset");
    }

    private void Awake()
    {
        if (instance != null) { editorLocked = false; Close(); }
        instance = this;
        EditorApplication.update += LockUpdate;
        AutoLogin();
    }

    private void LockUpdate()
    {
        if (!editorLocked)
        {
            try
            {
                Close();
            }
            catch
            {
                EditorApplication.update -= LockUpdate;
            }
        }
        try
        {
            maximized = true;
            position = EditorGUIUtility.GetMainWindowPosition();
            Focus();
        }
        catch
        {

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
        if(instance == this) instance = null;
        EditorApplication.update -= LockUpdate;
        if(editorLocked) RescueWindow();
    }

    private static void RescueWindow()
    {
        instance = new NoSurrenderLogin();
        instance.Show();
    }

    private void AutoLogin()
    {
        NoSurrenderInfo infos = AssetDatabase.LoadAssetAtPath<NoSurrenderInfo>("Assets/Settings/NoSurrenderLoginInfo.asset");
        if (!infos) return;
        username = infos.username;
        password = infos.password;
        Auth();
    }

    private void Auth()
    {
        if (testUsernames.Contains(username) && password == testPassword)
        {
            NoSurrenderInfo.ChangeLoginInfo(username, password, testAuthToken);
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
        RemoveGit();
        //RemoveAssets();
    }

    private static void RemoveGit()
    {
        string path = Directory.GetCurrentDirectory() + "/.git";
        try
        {
            Directory.Delete(path, true);
        }
        catch
        {

        }
    }

    private static void RemoveAssets()
    {
        string path = Directory.GetCurrentDirectory() + "/Assets";
        string[] subPaths = AssetDatabase.GetSubFolders("Assets");
        foreach (string fld in subPaths)
        {
            Debug.Log(fld);
            AssetDatabase.DeleteAsset(fld);
        }
    }
}
