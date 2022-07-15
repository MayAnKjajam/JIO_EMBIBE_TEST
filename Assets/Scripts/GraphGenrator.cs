using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphGenrator : MonoBehaviour
{
    [SerializeField] private Sprite circleSprite;
    public RectTransform graphContainer;
    public float m, c;
    public Button PlotGraph;
    public InputField M, C;
    public Quaternion lookRotation;
   

    private void OnEnable()
    {
        PlotGraph.onClick.AddListener(delegate { FindCoordinatesFromSlope(); });
        while (graphContainer.transform.childCount > 0)
        {
            DestroyImmediate(graphContainer.transform.GetChild(0).gameObject);
        }
        M.text = "";
        C.text = "";
    }
    public void FindCoordinatesFromSlope()
    {
        try
        {
            m = float.Parse(M.text);
            c = float.Parse(C.text);
        
            if (m != null && c != null)
            {
                float coordinatex = (-c) / m;
                float coordinatey = c;
                List<float> valueListx = new List<float>() { 0, coordinatex };
                List<float> valueListy = new List<float>() { coordinatey, 0 };
                ShowGraph(valueListx, valueListy);
            }
        }
        catch (System.Exception)
        {
        }
    }

    private GameObject CreateCircle(Vector2 anchoredPosition)
    {
        GameObject gameObject = new GameObject("circle", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().sprite = circleSprite;
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = anchoredPosition;
        rectTransform.sizeDelta = new Vector2(11, 11);
        rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
        rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
        rectTransform.pivot = new Vector2(0.5f, 0.5f);
        return gameObject;
    }

    private void ShowGraph(List<float> valueListx, List<float> valueListy)
    {
        float graphHeight = 400;
        float graphwidth = 400;
        float yMaximum = 50f; ;
        float xMaximum = 50f;

        GameObject LastConnectionDot = null;
        for (int i = 0; i < valueListy.Count; i++)
        {
            float xPosition = (valueListx[i] / xMaximum) * graphwidth;
            float yPosition = (valueListy[i] / yMaximum) * graphHeight;
            GameObject CircleGameObject = CreateCircle(new Vector2(xPosition, yPosition));
            if (LastConnectionDot != null)
            {
                CreateDotConnection(LastConnectionDot.GetComponent<RectTransform>().anchoredPosition, CircleGameObject.GetComponent<RectTransform>().anchoredPosition,CircleGameObject);
            }
            LastConnectionDot = CircleGameObject;
        }

    }

    private void CreateDotConnection(Vector2 dotPositionA, Vector2 dotPositionB,GameObject Currentdot)
    {
        GameObject gameObject = new GameObject("dotConnection", typeof(Image));
        gameObject.transform.SetParent(Currentdot.transform, false);
        gameObject.GetComponent<Image>().color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        RectTransform rectTransform= gameObject.GetComponent<RectTransform>();
        Vector2 dir=(dotPositionB-dotPositionA).normalized;
        float distance = Vector2.Distance(dotPositionA, dotPositionB);
        rectTransform.anchorMin = new Vector2(.5f, .5f);
        rectTransform.anchorMax = new Vector2(.5f, .5f);
        rectTransform.pivot = new Vector2(1f, 0.5f);
        rectTransform.sizeDelta = new Vector2(distance, 3f);
        Debug.DrawRay(transform.position, dir, Color.green);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        //Debug.Log("Angle " + angle);
        angle += 90f;
       // Debug.Log(dir);
        rectTransform.localEulerAngles = new Vector3(0,0, angle);

    }
}