using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{

    public SceneTransitioner sceneTransitioner;
    public int scene;
    public float timeBeforeChanging;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Animator>().SetBool("Portal", true);
            StartCoroutine(changeLevel(timeBeforeChanging));
        }
    }

    private IEnumerator changeLevel(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        sceneTransitioner.changeScene(scene);

    }

}
