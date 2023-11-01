using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasDestroy : MonoBehaviour
{
    public static CanvasDestroy canvas;

    private void Awake()
    {
        if (CanvasDestroy.canvas == null)
        {
            canvas = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(CanvasDestroy.canvas.gameObject);
        }
    }

    public void Reset()
    {
        canvas.gameObject.SetActive(false);
    }
}
