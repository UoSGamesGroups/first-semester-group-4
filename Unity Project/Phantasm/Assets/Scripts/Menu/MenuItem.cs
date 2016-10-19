using UnityEngine;
using UnityEngine.UI;

public abstract class MenuItem : MonoBehaviour {

    public Sprite Spr_Idle, Spr_Selected;
    private bool Selected;

    void Start() {
        Selected = false;
    }

    public virtual void Set_Selected(bool _State) {
        Selected = _State;
    }

    public virtual void Update() {
        GetComponent<Image>().sprite = Selected ? Spr_Selected : Spr_Idle;
    }

    public abstract void Execute();

}
