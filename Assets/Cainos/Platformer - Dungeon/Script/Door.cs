using UnityEngine;
using UnityEngine.SceneManagement;
using Cainos.LucidEditor;
using Cainos.CustomizablePixelCharacter;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
#endif


namespace Cainos.PixelArtPlatformer_Dungeon
{
    public class Door : MonoBehaviour, IInteractable
    {
        [FoldoutGroup("Reference")] public SpriteRenderer spriteRenderer;
        [FoldoutGroup("Reference")] public Sprite spriteOpened;
        [FoldoutGroup("Reference")] public Sprite spriteClosed;

        public Item key;

        // public GameObject Fading;

        public enum DoorWarpType
        {
            NONE,
            TRANSFORM,
            SCENE,
        }

        public DoorWarpType warpType;
        public Transform nextTarget; // 이동할 위치
        public string nextScene; // 씬 이름
        public Collider2D coll;

        private Animator Animator
        {
            get
            {
                if (animator == null ) animator = GetComponent<Animator>();
                return animator;
            }
        }
        private Animator animator;


        [FoldoutGroup("Runtime"), ShowInInspector]
        public bool IsOpened
        {
            get { return isOpened; }
            set
            {
                isOpened = value;

                #if UNITY_EDITOR
                if (Application.isPlaying == false)
                {
                    EditorUtility.SetDirty(this);
                    EditorSceneManager.MarkSceneDirty(gameObject.scene);
                }
                #endif


                if (Application.isPlaying)
                {
                    Animator.SetBool("IsOpened", isOpened);
                }
                else
                {
                    if(spriteRenderer) spriteRenderer.sprite = isOpened ? spriteOpened : spriteClosed;
                }

                if (coll) coll.enabled = !isOpened;
            }
        }
        [SerializeField,HideInInspector]
        private bool isOpened;


        private void Start()
        {
            Animator.Play(isOpened ? "Opened" : "Closed");
            IsOpened = isOpened;
            GameManager.OnPlayerDie.AddListener(()=>Close());
            

        }


        [FoldoutGroup("Runtime"), HorizontalGroup("Runtime/Button"), Button("Open")]
        public void Open()
        {
            if (IsOpened)
            {
                switch (warpType)
                {
                    case DoorWarpType.TRANSFORM:
                        if (nextTarget == null) break;
                        PixelCharacter.instance.transform.position = nextTarget.position;
                        break;
                    case DoorWarpType.SCENE:
                        if (nextScene == "") break;
                        // LoadingSceneManager.LoadScene(nextScene);
                        // Fading.GetComponent<Fading>().Morning_Stage1_down(nextScene);
                        Fading.Instance.Morning_Stage1_down(nextScene);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                IsOpened = true;
                
            }
        }



        [FoldoutGroup("Runtime"), HorizontalGroup("Runtime/Button"), Button("Close")]
        public void Close()
        {
            IsOpened = false;
        }

        public void InteractEnter()
        {

        }

        public void Interact()
        {
            if(key == null)
            {
                Open();
            }
            else
            {
                if (PixelCharacter.instance.inventory.IsContainItem(key))
                    Open();
                else
                    print($"{key.itemName}가 없습니다.");
            }
        }

        public void InteractExit()
        {

        }


    }
}
