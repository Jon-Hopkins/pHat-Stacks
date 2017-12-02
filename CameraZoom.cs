using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour {


    public int hatNum = 0;      //number of hats
    public int zoom1 = 70;
    public int zoom2 = 80;
    public int zoom3 = 90;
    public int zoom4 = 100;
    public int normal = 60;
    float smooth = 5;           //smoothes camera transition

    void Zoom()
    {
        switch (hatNum)
        {

            case 0:
            case 1:
            case 2:
            case 3:
            case 4:
                GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, normal, Time.deltaTime * smooth);
                break;
            case 5:
            case 6:
            case 7:
            case 8:
            case 9:
                GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, zoom1, Time.deltaTime * smooth);
                break;
            case 10:
            case 11:
            case 12:
            case 13:
            case 14:
                GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, zoom2, Time.deltaTime * smooth);
                break;
            case 15:
            case 16:
            case 17:
            case 18:
            case 19:
                GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, zoom3, Time.deltaTime * smooth);
                break;
            case 20:
                GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, zoom4, Time.deltaTime * smooth);
                break;
            default:
                print("Invalid number of hats, something went wrong.");
                break;
        }
    }
}