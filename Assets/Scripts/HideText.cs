using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HideText : MonoBehaviour, IPointerEnterHandler

{
    public Text[] WhateverTextThingy;
    public AudioSource audioSource;
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
            WhateverTextThingy[3].text = "";
        }

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        audioSource.Play();
        WhateverTextThingy[0].text = textoo;
        WhateverTextThingy[1].text = "COMENZAR";
        WhateverTextThingy[2].text = "MULTIJUGADOR";
        WhateverTextThingy[3].text = "SALIR";
        timeCont = 0f;
    }

    
}
