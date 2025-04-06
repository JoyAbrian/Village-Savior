using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ButtonHoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Image buttonImage;
    public Sprite originalSprite;
    public Sprite hoverSprite;

    public TextMeshProUGUI buttonText;

    void Start()
    {
        buttonImage = GetComponent<Image>();

        if (buttonImage != null && originalSprite != null)
        {
            buttonImage.sprite = originalSprite;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (buttonImage != null && hoverSprite != null)
        {
            buttonImage.sprite = hoverSprite;
        }

        if (buttonText != null)
        {
            buttonText.fontStyle = FontStyles.Bold;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (buttonImage != null && originalSprite != null)
        {
            buttonImage.sprite = originalSprite;
        }

        if (buttonText != null)
        {
            buttonText.fontStyle = FontStyles.Normal;
        }
    }
}
