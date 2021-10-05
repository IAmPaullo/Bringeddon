using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CanvasMainMenu : MonoBehaviour
{
    [SerializeField] CanvasGroup logoImage;
    [SerializeField] CanvasGroup playButton;
    [SerializeField] CanvasGroup glossarioBtn;
    [SerializeField] SceneHandler sM;
    
    [SerializeField] int index;

    [Header("Time Configs")]
    public float animateTime = .6f;
    public float animateBtntime = .2f;
    public Ease easeType;


    private void Start()
    {
        Animate();
    }

    public void Animate()
    {
        logoImage.alpha = 0f;
        logoImage.DOFade(1f, animateTime).SetEase(easeType);
        logoImage.interactable = true;

        

    }


    private void Update()
    {
        if (logoImage.alpha == 1f && playButton.alpha == 0f)
        {
            playButton.alpha = 0f;
            playButton.DOFade(1f, animateTime).SetEase(easeType);
            playButton.interactable = true;

            glossarioBtn.alpha = 0f;
            glossarioBtn.DOFade(1f, animateTime).SetEase(easeType);
            glossarioBtn.interactable = true;

        }

    }

    public void ClickSize(Button btn)
    {
        btn.transform.DOScale(.35f, .2f).SetEase(easeType);
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(.3f);
        sM.LoadScene(index);

    }

    public void IndexValue(int indexValue)
    {
        index = indexValue;
    }


}
