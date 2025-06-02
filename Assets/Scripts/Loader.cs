using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{
    public static int targetSceneIndex;

    public static void Load(string targetSceneName)
    {
        SceneManager.LoadScene(targetSceneName);
    }
}
