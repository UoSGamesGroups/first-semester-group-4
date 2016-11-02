using UnityEngine;
using System.Collections;

public class DialogTrigger : MonoBehaviour
{

    public DialogBox dialogBox;
    public string dialogText;

    public bool singleUse, dominant;
    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    { 

        if (collision.gameObject.tag == "Player")
        {
            if ((!triggered || !singleUse) && (!dialogBox.isVisible() || dominant))
            {
                dialogBox.showDialog(dialogText);
                triggered = true;
            }


        }

    }

}
