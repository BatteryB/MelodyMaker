using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickEvent : MonoBehaviour
{
    private Color activeColor = new Color32(90, 230, 255, 255);
    private Color commonColor = Color.white;
    private Renderer objRenderer;

    void Start()
    {
        objRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        if (isObjectClicked())
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (this.gameObject.tag == "default") 
                {
                    SetObjectState(activeColor, "active");
                }
                else
                {
                    SetObjectState(commonColor, "default");
                }
            }
        }
    }

    bool isObjectClicked()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject == gameObject)
            {
                return true;
            }
        }
        return false;
    }

    void SetObjectState(Color color, string tag)
    {
        objRenderer.material.color = color;
        this.gameObject.tag = tag;
    }
}
