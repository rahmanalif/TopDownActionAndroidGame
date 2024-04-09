using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private Image treshold;
    private Image touch;

    [HideInInspector]
    public Vector3 InputDir;

    public bool shoot;

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 position = Vector2.zero;

        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(treshold.rectTransform, eventData.position, eventData.pressEventCamera,out position))
        {
            position.x = (position.x / treshold.rectTransform.sizeDelta.x);
            position.y = (position.y / treshold.rectTransform.sizeDelta.y);

            float x = (treshold.rectTransform.pivot.x == 1f) ? position.x * 2 + 1 : position.x * 2 - 1;
            float y = (treshold.rectTransform.pivot.y == 1f) ? position.y * 2 + 1 : position.y * 2 - 1;

            InputDir = new Vector3(x, y, 0);
            InputDir = (InputDir.magnitude > 1) ? InputDir.normalized : InputDir;

            touch.rectTransform.anchoredPosition = new Vector3(InputDir.x * (treshold.rectTransform.sizeDelta.x / 2.5f), InputDir.y * (treshold.rectTransform.sizeDelta.y / 2.5f));
        }

        if (shoot)
            FindObjectOfType<weapon>().canShoot = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!shoot)
            InputDir = Vector3.zero;
        else
            FindObjectOfType<weapon>().canShoot = true;

        touch.rectTransform.anchoredPosition = Vector3.zero;
    }

    void Start()
    {
        treshold = GetComponent<Image>();
        touch = transform.GetChild(0).GetComponent<Image>();
        InputDir = Vector3.zero;
    }
}
