using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{

    [SerializeField] public GameObject sceneLoadingGame, sceneLoadingTutorial;    

    public void sceneGame()
    {
        SceneManager.LoadScene(1);
    }

    public void sceneMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void sceneOptions()
    {
        SceneManager.LoadScene(2);
    }
    public void LoadingGame()
    {
        StartCoroutine(waitScene(1));
        sceneLoadingGame.SetActive(true);
    }

    public void LoadingTutorial()
    {
        StartCoroutine(waitScene(3));
        sceneLoadingTutorial.SetActive(true);
    }

    IEnumerator waitScene(int sceneNum)
    {       
        yield return new WaitForSeconds(2);

        AsyncOperation loadGame = SceneManager.LoadSceneAsync(sceneNum);

        while (!loadGame.isDone)
        {
            yield return null;
        }
    }
}
 