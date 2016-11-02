using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogBox : MonoBehaviour
{

    public Image image;
    public Text text;

    public KeyCode keyAction;

    private bool visible;

    public bool isVisible()
    {
        return visible;
    }

    public void showDialog(string text)
    {
        setText(text);
        showDialog();
    }
   
    private void setText(string text)
    {
        this.text.text = text;
    }

    private void showDialog()
    {
        GetComponent<Animator>().SetBool("Visible", true);
        visible = true;
    }

    private void hideDialog()
    {
        GetComponent<Animator>().SetBool("Visible", false);
        visible = false;
    }

    private void Update()
    {
        if (visible && Input.GetKeyDown(keyAction))
        {
            hideDialog();
        }
    }
    
}
