using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SeparateManager : Singleton<SeparateManager>
{
    public TrashSpawner spawner;
    public RecycleActType currentActType;
    private Trash currentTrash;
    private GameObject currentTrashObject;
    public Sprite correctSprite;
    public Sprite incorrectSprite;

    private Dictionary<Trash, int> correctTrash = new(); // 분리수거 성공한 쓰레기들
    private Dictionary<Trash, int> incorrectTrash = new(); // 분리수거 실패한 쓰레기들

    public Transform correctContent;
    public Transform incorrectContent;
    public TMP_Text correctText;
    public TMP_Text incorrectText;
    public SeparateResultTrashButton separateResultTrashButton;
    

    private ActButton[] actButtons;

    public override void Awake()
    {
        base.Awake();
        actButtons = FindObjectsOfType<ActButton>();
        SaveManager.OnLoad.AddListener(GameStart);
    }

    private void GameStart(SaveFile saveFile)
    {
        if(saveFile.GetTrashNum() == 0)
        {
            UIManager.Instance.ActiveError(true);
        }
        else
        {
            UIManager.Instance.ActiveError(false);
            spawner.SpawnStart(saveFile);
        }
    }
    
    public void TrashUpdate(Trash trash, GameObject trashObject)
    {
        currentTrash = trash;
        currentTrashObject = trashObject;

        foreach (var actButton in actButtons)
        {
            actButton.Init();
        }
    }

    public void SuccessCheck()
    {
        Debug.Log(currentActType + " " + currentTrash.recycleActType);

        // 쓰레기에 필요한 행동과 똑같은지 비교
        if (currentActType == currentTrash.recycleActType)
        {
            // 쓰레기 스폰
            UIManager.Instance.ResultImageUpdate(correctSprite);
            SoundManager.Instance.PlaySFX("Correct");

            if (correctTrash.ContainsKey(currentTrash))
                correctTrash[currentTrash]++;
            else
                correctTrash.Add(currentTrash, 1);
        }
        // 다를 때
        else
        {
            UIManager.Instance.ResultImageUpdate(incorrectSprite);
            SoundManager.Instance.PlaySFX("Incorrect");

            SaveManager.SaveFile.RemoveTrash(currentTrash.trashSaveName); // 틀린 쓰레기는 저장하지 않음
            
            if (incorrectTrash.ContainsKey(currentTrash))
                incorrectTrash[currentTrash]++;
            else
                incorrectTrash.Add(currentTrash, 1);
        }
        
        currentTrashObject.gameObject.SetActive(false);
        spawner.OnSpawnToggle();
    }
    
    
    // 분리 끝나고 나온 결과 생성
    public void SeparateResultUpdate()
    {
        correctText.text = $"성공 : {correctTrash.Values.Sum()}";
        incorrectText.text = $"실패 : {incorrectTrash.Values.Sum()}";
        
        // correct trash
        foreach (var resultInfo in correctTrash)
        {
            SeparateResultTrashButton sr = Instantiate(separateResultTrashButton, correctContent);
            sr.Init(resultInfo.Key, resultInfo.Value);
        }
        
        // incorrect trash
        foreach (var resultInfo in incorrectTrash)
        {
            SeparateResultTrashButton sr = Instantiate(separateResultTrashButton, incorrectContent);
            sr.Init(resultInfo.Key, resultInfo.Value);
        }
    }
}
