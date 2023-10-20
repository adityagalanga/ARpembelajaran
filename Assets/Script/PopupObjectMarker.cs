using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupObjectMarker : MonoBehaviour
{
    public List<PopupObjectSO> ObjectDataMarker;
    public RawImage PopupImage;
    public TextMeshProUGUI PopupTitle;
    public TextMeshProUGUI PopupContent;
    public ScrollRect ScrollView;

    public void ShowPopupData(ObjectLasID SelectedID)
    {
        PopupObjectSO data = ObjectDataMarker.Find(currentID => currentID.ID == SelectedID);
        PopupImage.texture = data.PopupTexture;
        PopupTitle.text = data.PopupTitle;
        PopupContent.text = data.PopupText.ToString();
        this.gameObject.SetActive(false);
        this.gameObject.SetActive(true);
        ScrollView.verticalNormalizedPosition = 1;
    }

    public void ClosePopup()
    {
        this.gameObject.SetActive(false);
    }
}