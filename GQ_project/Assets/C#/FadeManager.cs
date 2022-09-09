using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//�Q�ƁFhttps://kenko-san.com/unity-fade/#toc4
//2022/5/21�X�V

/*�@�Z����̃V�[�����t�F�[�h�C���Ŏn�߂����ꍇ
 *    ���̃V�[�����ɂ��鉽�ꂩ�̃X�N���v�g��Start()���Ɉȉ���1�s��ǉ�
 *     FadeManager.FadeIn()�G
 *  
 *  �Z���݂̃V�[�����t�F�[�h�A�E�g�ŏI����āA���̃V�[���Ƀt�F�[�h�C�������ꍇ
 *    �C�ӂ̃^�C�~���O�ňȉ��̈�s��ǉ�
 *    FadeManager.FadeOut(�J�ڂ������V�[���̖��O);
 *    
 *    �V�[���J�ڂ������ɏo���܂��B
 */

public class FadeManager : MonoBehaviour
{
    //�t�F�[�h�p��Canvas��Image
    private static Canvas fadeCanvas;
    private static Image fadeImage;

    //�t�F�[�h�pImage�̓����x
    private static float alpha = 0.0f;

    //�t�F�[�h�C���A�E�g�̃t���O
    public static bool IsFadeIn = false;
    public static bool IsFadeOut = false;

    //�t�F�[�h�̒����i�P�ʂ͕b�j
    private static float fadeTime = 0.4f;

    //�J�ڐ�̃V�[����
    private static string nextScene;
    private static int nextSceneIndex;

    private static bool FadeIndex = false;

    //�t�F�[�h�p��Canvas��Image����
    static void Init()
    {
        //�t�F�[�h�p��Canvas����
        GameObject FadeCanvasObject = new GameObject("CanvasFade");
        fadeCanvas = FadeCanvasObject.AddComponent<Canvas>();
        FadeCanvasObject.AddComponent<GraphicRaycaster>();
        fadeCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
        FadeCanvasObject.AddComponent<FadeManager>();

        //�őO�ʂɂȂ�悤�K���ȃ\�[�g�I�[�_�[�ݒ�
        fadeCanvas.sortingOrder = 100;

        //�t�F�[�h�p��Image����
        fadeImage = new GameObject("ImageFade").AddComponent<Image>();
        fadeImage.transform.SetParent(fadeCanvas.transform, false);
        fadeImage.rectTransform.anchoredPosition = Vector3.zero;

        //Image�T�C�Y�͓K���ɑ傫���ݒ�
        fadeImage.rectTransform.sizeDelta = new Vector2(9999, 9999);
    }

    //�t�F�[�h�C���J�n
    public static void FadeIn()
    {
        if (fadeImage == null) Init();
        fadeImage.color = Color.black;
        IsFadeIn = true;
    }

    //�t�F�[�h�A�E�g�J�n
    //�����͑J�ڂ������V�[���̃V�[����
    public static void FadeOut(string SceneName)
    {
        FadeIndex = false;
        if (fadeImage == null) Init();
        nextScene = SceneName;
        fadeImage.color = Color.clear;
        fadeCanvas.enabled = true;
        IsFadeOut = true;
    }

    //�t�F�[�h�A�E�g�J�n
    //�����͑J�ڂ������V�[���̃V�[���ԍ�
    public static void FadeOut(int SceneNameIndex)
    {
        FadeIndex = true;
        if (fadeImage == null) Init();
        nextSceneIndex = SceneNameIndex;
        fadeImage.color = Color.clear;
        fadeCanvas.enabled = true;
        IsFadeOut = true;
    }

    void Update()
    {
        //�t���O�L���Ȃ疈�t���[���t�F�[�h�C��/�A�E�g����
        if (IsFadeIn)
        {
            //�o�ߎ��Ԃ��瓧���x�v�Z
            alpha -= Time.deltaTime / fadeTime;

            //�t�F�[�h�C���I������
            if (alpha <= 0.0f)
            {
                IsFadeIn = false;
                alpha = 0.0f;
                fadeCanvas.enabled = false;
            }

            //�t�F�[�h�pImage�̐F�E�����x�ݒ�
            fadeImage.color = new Color(0.0f, 0.0f, 0.0f, alpha);
        }
        else if (IsFadeOut)
        {
            //�o�ߎ��Ԃ��瓧���x�v�Z
            alpha += Time.deltaTime / fadeTime;

            //�t�F�[�h�A�E�g�I������
            if (alpha >= 1.0f)
            {
                IsFadeOut = false;
                alpha = 1.0f;

                //���̃V�[���֑J��
                if (FadeIndex == false)
                {
                    SceneManager.LoadScene(nextScene);
                }
                else
                {
                    SceneManager.LoadScene(nextSceneIndex);
                }
            }

            //�t�F�[�h�pImage�̐F�E�����x�ݒ�
            fadeImage.color = new Color(0.0f, 0.0f, 0.0f, alpha);
        }
    }
}