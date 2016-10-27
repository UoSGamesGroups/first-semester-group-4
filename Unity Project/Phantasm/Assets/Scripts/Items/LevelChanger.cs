using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{

    public SceneTransitioner sceneTransitioner;
    public int scene;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            sceneTransitioner.changeScene(scene);
        }
    }

}
