using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class UIActiveSetting : MonoBehaviour
{
    public enum UIType
    {
        Error,
        Option,
        Information,
        Tutorial,
        ResultImage,
        GameOver,
        TrashSimpleInformation,
        TrashInformation,
        ItemInventory,
        ItemCreate
    }

    public UIType type;
    public bool initActive;
    public bool onClickActive = true;
    private Button button;

    public void Init()
    {
        button = GetComponent<Button>();
        if(button != null)
            gameObject.SetActive(true);

        switch (type)
        {
            case UIType.Error:

                if(button == null)
                {
                    UIManager.Instance.uiError = gameObject;
                    UIManager.Instance.ActiveError(initActive);
                }
                else
                {
                    button.onClick.AddListener(() => UIManager.Instance.ActiveError(onClickActive));
                }
                break;
            case UIType.Option:
                if (button == null)
                {
                    UIManager.Instance.uiOption = gameObject;
                    UIManager.Instance.ActiveOption(initActive);
                }
                else
                {
                    button.onClick.AddListener(() => UIManager.Instance.ActiveOption(onClickActive));
                }
                break;
            case UIType.Information:
                if (button == null)
                {
                    UIManager.Instance.uiInformation = gameObject;
                    UIManager.Instance.ActiveInformation(initActive);
                }
                else
                {
                    button.onClick.AddListener(() => UIManager.Instance.ActiveInformation(onClickActive));
                }
                break;
            case UIType.Tutorial:
                if (button == null)
                {
                    UIManager.Instance.uiTutorial = gameObject;
                    UIManager.Instance.ActiveTutorial(initActive);
                }
                else
                {
                    button.onClick.AddListener(() => UIManager.Instance.ActiveTutorial(onClickActive));
                }
                break;
            case UIType.ResultImage:
                break;
            case UIType.GameOver:
                if (button == null)
                {
                    UIManager.Instance.uiGameOver = gameObject;
                    UIManager.Instance.ActiveGameOver(initActive);
                }
                else
                {
                    button.onClick.AddListener(() => UIManager.Instance.ActiveGameOver(onClickActive));
                }
                break;
            case UIType.TrashSimpleInformation:
                if (button == null)
                {
                    UIManager.Instance.uiTrashSimpleInformation = gameObject;
                    UIManager.Instance.ActiveTrashSimpleInformation(initActive);
                }
                else
                {
                    button.onClick.AddListener(() => UIManager.Instance.ActiveTrashSimpleInformation(onClickActive));
                }
                break;
            case UIType.TrashInformation:
                if (button == null)
                {
                    UIManager.Instance.uiTrashInformation = gameObject;
                    UIManager.Instance.ActiveTrashInformation(initActive);
                }
                else
                {
                    button.onClick.AddListener(() => UIManager.Instance.ActiveTrashInformation(onClickActive));
                }
                break;
            case UIType.ItemInventory:
                if (button == null)
                {
                    UIManager.Instance.uiItemInventory = gameObject;
                    UIManager.Instance.ActiveItemInventory(initActive);
                }
                else
                {
                    button.onClick.AddListener(() => UIManager.Instance.ActiveItemInventory(onClickActive));
                }
                break;
            case UIType.ItemCreate:
                if (button == null)
                {
                    UIManager.Instance.uiItemCreate = gameObject;
                    UIManager.Instance.ActiveItemCreate(initActive);
                }
                else
                {
                    button.onClick.AddListener(() => UIManager.Instance.ActiveItemCreate(onClickActive));
                }
                break;
            default:
                break;
        }

        
    }
}
