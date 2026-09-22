using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class SecretScript : MonoBehaviour
{
    // Tbf, if you already know how to open a GitHub repo and look through scripts
    // and can parse this code without downloading the Unity project, kudos to you!

    private static readonly int[] shift = { 5, 9, 9, 7, 14, 9, 25, 19, 25, 8, 13, 16, 14, 9, 19, 25 };

    void Start()
    {
        GameObject canvasObj = new GameObject("SecretCanvas");
        Canvas canvas = canvasObj.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvasObj.AddComponent<CanvasScaler>();
        canvasObj.AddComponent<GraphicRaycaster>();

        GameObject textObj = new GameObject("SecretText");
        textObj.transform.SetParent(canvasObj.transform);
        Text text = textObj.AddComponent<Text>();
        text.text = Decode();
        text.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
        text.fontSize = 36;
        text.alignment = TextAnchor.MiddleCenter;
        text.color = Color.white;

        RectTransform rect = textObj.GetComponent<RectTransform>();
        rect.anchorMin = Vector2.zero;
        rect.anchorMax = Vector2.one;
        rect.offsetMin = Vector2.zero;
        rect.offsetMax = Vector2.zero;

        // But please make sure that installation works. You can delete this project after. :')
    }

    private string Decode()
    {
        StringBuilder sb = new StringBuilder();
        char prev = 'a';
        foreach (int s in shift)
        {
            char c = (char)('a' + ((s + (prev - 'a')) % 26));
            sb.Append(c);
            prev = c;
        }
        string raw = sb.ToString();
        return raw.Insert(5, " ").Insert(10, " ").Insert(14, " ");
    }
}
