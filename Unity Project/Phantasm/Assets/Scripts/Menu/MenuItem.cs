using UnityEngine;
using UnityEngine.UI;

public abstract class MenuItem : MonoBehaviour
{

    public Sprite sprIdle, sprSelected;
    private bool selected;

    private void Start()
    {
        selected = false;
    }

    public virtual void setSelected(bool state)
    {
        selected = state;
    }

    public virtual void Update()
    {
        GetComponent<Image>().sprite = selected ? sprSelected : sprIdle;
    }

    public abstract void execute();

}
