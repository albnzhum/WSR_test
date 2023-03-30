using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputController : MonoBehaviour
{
    private InputField inputField;
    private Vector2 originalSize;
    private RectTransform rectTransform;

    private void Awake()
    {
        inputField = GetComponent<InputField>();
        rectTransform = GetComponent<RectTransform>();
        originalSize = rectTransform.sizeDelta;
        inputField.onValueChanged.AddListener(OnValueChanged);
        
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
