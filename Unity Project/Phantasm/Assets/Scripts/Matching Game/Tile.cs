using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Tile : MonoBehaviour {

    private Sprite sprBack, sprFront;
    private int id;

    private float flipSpeed, flipBackSpeed;
    private float startScale;

    private bool flipped;
    private bool flipping;
    private bool flippable;

    public void Start() {
        startScale = GetComponent<Transform>().localScale.x;
        flippable = true;
        flipSpeed = 0.5f;
        flipBackSpeed = 1.0f;
    }

    public void reset()
    {
        flippable = true;
        if (flipped)
        {
            flip();
        }
    }

    public void flip() {
        if (flippable && !flipping) {
            StartCoroutine(flipAnimation());
        }
    }

    public IEnumerator flipAnimation()
    {
        flipping = true;
        if (!flipped) {
            for (var i = startScale; i >= -startScale; i -= 0.01f) {
                GetComponent<Transform>().localScale = new Vector3(i, GetComponent<Transform>().localScale.y, GetComponent<Transform>().localScale.z);
                if (i <= 0) {
                    GetComponent<Image>().sprite = sprFront;
                }
                yield return new WaitForSeconds(flipSpeed * Time.deltaTime);
            }
            flipped = true;
        }
        else {
            for (var i = -startScale; i <= startScale; i += 0.01f) {
                GetComponent<Transform>().localScale = new Vector3(i, GetComponent<Transform>().localScale.y, GetComponent<Transform>().localScale.z);
                if (i >= 0) {
                    GetComponent<Image>().sprite = sprBack;
                }
                yield return new WaitForSeconds(flipBackSpeed * Time.deltaTime);
            }
            flipped = false;
        }
        flipping = false;
    }

    public bool isFlipped()
    {
        return flipped;
    }

    public void hold() {
        flippable = false;
    }

    public bool isHeld() {
        return !flippable;
    }

    public int getID()
    {
        return id;
    }

    public void setData(TileData tileData) {
        sprBack = tileData.sprBack;
        sprFront = tileData.sprFront;
        id = tileData.id;
    }

    public TileData getData() {
        var tileData = ScriptableObject.CreateInstance<TileData>();
        tileData.sprFront = sprFront;
        tileData.sprBack = sprBack;
        tileData.id = id;
        return tileData;
    }

}
