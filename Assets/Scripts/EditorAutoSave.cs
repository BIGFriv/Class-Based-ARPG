#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

[InitializeOnLoad]
public static class EditorAutoSave
{
    private static float timer = 300;
    public static float resetTimer = 1000; //Adjust value to determine on how many seconds you want to save every time.

    static EditorAutoSave()
    {
        EditorApplication.playModeStateChanged += SaveOnPlay;
        EditorApplication.update += SaveOnTime;
        EditorApplication.quitting += SaveOnClose;
    }

    public static void SaveOnPlay(PlayModeStateChange state)
    {
        if (state == PlayModeStateChange.ExitingEditMode)
        {
            Debug.Log("Auto Save : Exited Edit Mode");

            EditorSceneManager.SaveOpenScenes();
            AssetDatabase.SaveAssets();
        }
    }

    public static void SaveOnClose()
    {
        EditorSceneManager.SaveOpenScenes();
        AssetDatabase.SaveAssets();
    }

    [ExecuteInEditMode]
    public static void SaveOnTime()
    {
        if (timer > 0)
        {
            //To proves that this works, uncomment the log under here.
            //Debug.Log(timer);
            timer -= Time.deltaTime;
        }

        else if (timer <= 0 && !EditorApplication.isPlaying)
        {
            Debug.Log("Auto Save : Timed");

            EditorSceneManager.SaveOpenScenes();
            AssetDatabase.SaveAssets();
            timer = resetTimer;
        }
    }
}
#endif