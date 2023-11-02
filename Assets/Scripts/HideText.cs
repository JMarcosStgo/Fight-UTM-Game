using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HideText : MonoBehaviour, IPointerEnterHandler

{
    public Text[] WhateverTextThingy; 

    private float timeCont = 0f;
    private string textoo;

    private void Start()
    {
        textoo = WhateverTextThingy[0].text;
    }

    private void Update()
    {
        timeCont += Time.deltaTime;
        if (timeCont>=10)
        {
            WhateverTextThingy[0].text = "";
            WhateverTextThingy[1].text = "";
            WhateverTextThingy[2].text = "";

        }

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        WhateverTextThingy[0].text = textoo;
        WhateverTextThingy[1].text = "COMENZAR";
        WhateverTextThingy[2].text = "MULTIJUGADOR";
        timeCont = 0f;
    }

    
}
