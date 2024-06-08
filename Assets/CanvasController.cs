using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public GameObject mainCanvas;
    public GameObject secondCanvas;

    void Start()
    {
        ShowMainCanvas();
    }

    public void ShowMainCanvas()
    {
        mainCanvas.SetActive(true);
        secondCanvas.SetActive(false);
    }

    public void ShowSecondCanvas()
    {
        mainCanvas.SetActive(false);
        secondCanvas.SetActive(true);
    }
}
