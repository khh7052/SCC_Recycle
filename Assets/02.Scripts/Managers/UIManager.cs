using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class UIManager : Singleton<UIManager>
{
    [Header("Common")]
    public GameObject uiOption;
    public GameObject uiInformation;
    public GameObject uiTutorial;
    public FadeText errorText;
    

    [Header("Collect Game")]
    public GameObject uiGameOver;
    public Image timeBar;
    public TMP_Text scoreText;
    public TMP_Text maxScoreText;

    [Header("SperateEmission")]
    public GameObject uiSeparateError;
    public GameObject uiSeparateGameEnd;
    public GameObject uiTrashInformation;
    public GameObject uiTrashSimpleInformation;
    
    public TrashInformationText trashNameTextSimple;
    public TrashInformationImage trashTypeImageSimple;
    
    public TrashInformationText trashNameText;
    public TrashInformationText trashDescriptionText;
    public TrashInformationImage trashImage;
    public TrashInformationImage trashTypeImage;

    
    
    [Header("Recycle")]
    public GameObject uiItemInventory;
    public GameObject uiItemCreate;
    public ItemButton createItemButton;
    public MakeButton makeButton;


    public override void Awake()
    {
        base.Awake();
        SaveManager.OnLoad.AddListener(Init);
    }

    private void Start()
    {
        // Common
        ActiveOption(false);
        ActiveInformation(false);
        ActiveTutorial(false);
        ErrorTextUpdate("");

        // Collect
        ActiveGameOver(false);

        // SeparateEmission
        ActiveSeparateGameEnd(false);
        ActiveTrashSimpleInformation(false);
        ActiveTrashInformation(false);

        // Recycle
        ActiveItemInventory(true);
        ActiveItemCreate(false);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void GameExit()
    {
        Application.Quit();
    }

    public void Continue()
    {
        ActiveOption(false);
    }
    
    public void Init(SaveFile saveFile)
    {
        MaxScoreTextUpdate(saveFile.maxScore);
    }


    #region Common
    public void ActiveOption(bool active)
    {
        if (!uiOption) return;

        uiOption.SetActive(active);
        Time.timeScale = active ? 0f : 1f;
    }

    public void ActiveInformation(bool active)
    {
        if (!uiInformation) return;

        uiInformation.SetActive(active);
    }
    public void ActiveTutorial(bool active)
    {
        if (!uiTutorial) return;

        uiTutorial.SetActive(active);
        Time.timeScale = active ? 0f : 1f;
    }


    public void ErrorTextUpdate(string text)
    {
        if (!errorText) return;
        errorText.TextUpdate(text);
        errorText.StartFade();

        if(text != "")
            SoundManager.Instance.PlaySFX("Error");
    }
    #endregion

    #region Collect
    public void ActiveGameOver(bool active)
    {
        if (!uiGameOver) return;

        uiGameOver.SetActive(active);
    }
    public void TimeBarUpdate(float amount)
    {
        if (!timeBar) return;
        timeBar.fillAmount = amount;
    }
    public void ScoreTextUpdate(float amount)
    {
        if (!scoreText) return;
        scoreText.text = amount.ToString("N0");
    }
    public void MaxScoreTextUpdate(float amount)
    {
        if (!maxScoreText) return;
        maxScoreText.text = amount.ToString("N0");
    }
    #endregion

    #region SperateEmission
    public void ActiveSeparateError(bool active)
    {
        if (!uiSeparateError) return;

        uiSeparateError.SetActive(active);
    }
    public void ActiveSeparateGameEnd(bool active)
    {
        if (!uiSeparateGameEnd) return;

        uiSeparateGameEnd.SetActive(active);
    }
    
    public void ActiveTrashSimpleInformation(bool active)
    {
        if (!uiTrashSimpleInformation) return;

        uiTrashSimpleInformation.SetActive(active);
    }
    
    public void ActiveTrashInformation(bool active)
    {
        if (!uiTrashInformation) return;

        uiTrashInformation.SetActive(active);
    }
    
    public void TrashSimpleInformationUpdate(Trash trash)
    {
        if (trash == null) return;

        if (trashNameTextSimple) trashNameTextSimple.TextUpdate(trash);
        if (trashTypeImageSimple) trashTypeImageSimple.ImageUpdate(trash);
    }
    
    public void TrashInformationUpdate(Trash trash)
    {
        if (trash == null) return;

        if (trashNameText) trashNameText.TextUpdate(trash);
        if (trashDescriptionText) trashDescriptionText.TextUpdate(trash);
        if (trashImage) trashImage.ImageUpdate(trash);
        if (trashTypeImage) trashTypeImage.ImageUpdate(trash);
    }
    #endregion

    #region Recycle
    public void ActiveItemInventory(bool active)
    {
        if (!uiItemInventory) return;

        uiItemInventory.SetActive(active);
    }
    public void ActiveItemCreate(bool active)
    {
        if (!uiItemCreate) return;

        uiItemCreate.SetActive(active);
    }

    public void ItemButtonUpdate(Item item)
    {
        if (createItemButton == null) return;
        if (item == null) return;

        createItemButton.CreateCostUI(item);
        makeButton.item = item;
    }

    public void OnRecycleBackButton()
    {
        ActiveItemInventory(true);
        ActiveItemCreate(false);
    }

    #endregion

}
