using IPA;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DarthMaulCompetitive
{
    public class Plugin : IBeatSaberPlugin
    {
        public const string assemblyName = "DarthMaulCompetitive";
        private const string MenuScene = "MenuCore";
        private const string GameScene = "GameCore";

        private static DarthMaulCompetitiveBehavior darthMaulBehavior;

        public void OnActiveSceneChanged(Scene prevScene, Scene nextScene)
        {
            if (nextScene.name == GameScene)
            {
                SharedCoroutineStarter.instance.StartCoroutine(WaitForGameScene());
            }
        }

        public void OnApplicationQuit()
        {
        }

        public void OnApplicationStart()
        {
            PersistentSingleton<ConfigOptions>.TouchInstance();
        }

        public void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
        {
            if (scene.name == MenuScene)
            {
                DarthMaulCompetitiveUI.CreateUI();
            }
        }

        public void OnSceneUnloaded(Scene scene)
        {
        }

        private static IEnumerator WaitForGameScene()
        {
            yield return new WaitForSecondsRealtime(0.1f);
            if (darthMaulBehavior == null) darthMaulBehavior = new GameObject(nameof(DarthMaulCompetitiveBehavior)).AddComponent<DarthMaulCompetitiveBehavior>();
            darthMaulBehavior.BeginGameCoreScene();
        }

        public void OnUpdate()
        {
        }

        public void OnFixedUpdate()
        {
        }
    }
}
