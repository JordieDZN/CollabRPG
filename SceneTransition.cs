using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{ 
    public string sceneToLoad;
    public Vector2 playerPosition;
    public NewVector playerStorage;
    public GameObject fadeInPannel;
    public GameObject fadeOutPannel;
    public float fadeWait;

    private void Awake()
    {
        if (fadeInPannel != null)
        {
            GameObject pannel = Instantiate(fadeInPannel, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(pannel, 1);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerStorage.initalValue = playerPosition;
            StartCoroutine(FadeCo());
            //SceneManager.LoadScene(sceneToLoad);

        }
    }

    public IEnumerator FadeCo()
    {
        if (fadeOutPannel != null)
        {
            Instantiate(fadeOutPannel, Vector3.zero, Quaternion.identity);
        }
        yield return new WaitForSeconds(fadeWait);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneToLoad);
        while(!asyncOperation.isDone)
        {
            yield return null;
        }
    }
}
