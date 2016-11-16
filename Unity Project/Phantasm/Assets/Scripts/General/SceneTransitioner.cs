using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneTransitioner : MonoBehaviour
{

    private const float fadeSpeed = 0.125f;

    public void changeScene(int sceneIndex)
    {
        StartCoroutine(fadeOut(sceneIndex));
    }

    private void Start()
    {
        StartCoroutine(fadeIn());
    }

    private IEnumerator fadeOut(int sceneIndex)
    {
        for (var i = 0.0f; i <= 1.0f; i += 0.02f)
        {
            GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.0f, 0.0f, i);
            yield return new WaitForSeconds(fadeSpeed * Time.deltaTime);
        }
        SceneManager.LoadScene(sceneIndex);
    }

    private IEnumerator fadeIn()
    {
        for (var i = 1f; i >= 0.0f; i -= 0.02f)
        {
            GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.0f, 0.0f, i);
            yield return new WaitForSeconds(fadeSpeed * Time.deltaTime);
        }
    }

}
