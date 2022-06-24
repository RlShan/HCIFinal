using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARInteract : MonoBehaviour
{
    public GameObject myItem,camPanel,menuPanel;
    public ARRaycastManager raycastManager;
    private GameObject currObj;


    public void ItemSelect(GameObject item)
    {
        myItem = item;
        menuPanel.SetActive(false);
        camPanel.SetActive(true);
    }
    public void OnClickBack()
    {
        menuPanel.SetActive(true);
        camPanel.SetActive(false);
        if (currObj != null)
        {
            Destroy(currObj);
            currObj = null;
        }
    }
    public void Touch()
    {
        List<ARRaycastHit> touches = new List<ARRaycastHit>();
        raycastManager.Raycast(Input.GetTouch(0).position, touches, UnityEngine.XR.ARSubsystems.TrackableType.Planes);
        if (touches.Count > 0)
        {
            currObj=GameObject.Instantiate(myItem, touches[0].pose.position, touches[0].pose.rotation);
        }
        /* if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
         {
             List<ARRaycastHit> touches = new List<ARRaycastHit>();
             raycastManager.Raycast(Input.GetTouch(0).position, touches, UnityEngine.XR.ARSubsystems.TrackableType.Planes);
             if (touches.Count > 0)
             {
                 GameObject.Instantiate(myItem, touches[0].pose.position, touches[0].pose.rotation);
             }
         }*/
    }
    public void Remove()
    {
        if (currObj != null)
        {
            Destroy(currObj);
            currObj = null;
            Debug.Log("Remove");

        }

    }
}