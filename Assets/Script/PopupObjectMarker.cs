using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupObjectMarker : MonoBehaviour
{
    public List<DataPopup> DataObjectPopup = new List<DataPopup>();
    public RawImage PopupImage;
    public TextMeshProUGUI PopupTitle;
    public TextMeshProUGUI PopupContent;
    public ScrollRect ScrollView;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ShowPopupData(ObjectLasID.regulator);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            ShowPopupData(ObjectLasID.weldinggun);
        }
    }
    public void ShowPopupData(ObjectLasID SelectedID)
    {
        ShowContent(SelectedID);
        this.gameObject.SetActive(false);
        this.gameObject.SetActive(true);
        ScrollView.verticalNormalizedPosition = 1;
    }
    public void ShowContent(ObjectLasID ID)
    {
        foreach(DataPopup data in DataObjectPopup)
        {
            if(data.ID == ID)
            {
                data.PopupGame.SetActive(true);
            }
            else
            {
                data.PopupGame.SetActive(false);
            }
        }
    }
    
    public void ClosePopup()
    {
        this.gameObject.SetActive(false);
    }

    [System.Serializable]
    public struct DataPopup
    {
        public ObjectLasID ID;
        public GameObject PopupGame;
    }
}