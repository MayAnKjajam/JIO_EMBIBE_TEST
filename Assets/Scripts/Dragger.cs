using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragger : MonoBehaviour
{
    public GameObject selecteditem;
    public Vector3 StartingPosition;
    public GameObject CorrectPanel, IncorrectPanel, Cube1, Cylinder, Cube2;

    public void OnEnable()
    {
        
        IncorrectPanel.SetActive(false);
        CorrectPanel.SetActive(false);
        Cube1.SetActive(true);
        Cylinder.SetActive(true);
        Cube2.SetActive(false);
        Cube1.transform.position = StartingPosition;
        Cube1.GetComponent<IsPlacedCorrect>().isCorrect = false;
    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (selecteditem == null)
            {
                RaycastHit hit =CastRay();

                if (hit.collider != null)
                {
                    if (!hit.collider.CompareTag("drag"))
                    {
                        return;
                    }
                    selecteditem = hit.collider.gameObject;
                    StartingPosition = selecteditem.transform.position;
                }
            }
            else
            {
                if (!selecteditem.GetComponent<IsPlacedCorrect>().isCorrect)
                {
                    selecteditem.transform.position = StartingPosition;
                    IncorrectPanel.SetActive(true);
                }
                else 
                {
                    Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selecteditem.transform.position).z);
                    Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
                    selecteditem.transform.position = new Vector3(worldPosition.x, 0f, worldPosition.z);
                    CorrectPanel.SetActive(true);
                    Cube1.SetActive(false);
                    Cylinder.SetActive(false);
                    Cube2.SetActive(true);
                }
                selecteditem = null;

            }
        }
        if (selecteditem != null) {
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selecteditem.transform.position).z);
            Vector3 WorldPosition = Camera.main.ScreenToWorldPoint(position);
            selecteditem.transform.position = new Vector3(WorldPosition.x, .15f, WorldPosition.z);
        }
    }

    public RaycastHit CastRay()
    {
        Vector3 screenMousePosFar = new Vector3(Input.mousePosition.x,Input.mousePosition.y,Camera.main.farClipPlane);
        Vector3 screenMousePosNear = new Vector3(Input.mousePosition.x,Input.mousePosition.y,Camera.main.nearClipPlane);
        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);
        RaycastHit hit;
        Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit);
        return hit;
    } 
}