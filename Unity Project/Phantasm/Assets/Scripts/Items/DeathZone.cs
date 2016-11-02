using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{

    public SceneTransitioner sceneTransitioner;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            sceneTransitioner.changeScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}
