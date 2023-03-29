using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputController : MonoBehaviour
{
    private InputField inputField;
    public float doubleClickTime = 0.3f;

    private float lastClickTime = 0;

    private void Update()
    {
        
        /*if (Input.GetMouseButtonDown(0))
        {
            if (Time.time - lastClickTime < doubleClickTime)
            {
                inputField.ActivateInputField();
            }
            lastClickTime = Time.time;
        }*/
    }
    private void Awake()
    {
        inputField = GetComponent<InputField>();
       // inputField.onValueChanged.AddListener(OnValueChanged);
        inputField.DeactivateInputField();
    }

    private void OnValueChanged(string value)
    {
        TextGenerator textGenerator = inputField.textComponent.cachedTextGeneratorForLayout;

        TextGenerationSettings generationSettings = inputField.textComponent.GetGenerationSettings(inputField.textComponent.rectTransform.rect.size);
        float preferredHeight = textGenerator.GetPreferredHeight(value, generationSettings);

        // Add extra padding
        float padding = 10f;
        preferredHeight += padding;

        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, preferredHeight);
    }
}
