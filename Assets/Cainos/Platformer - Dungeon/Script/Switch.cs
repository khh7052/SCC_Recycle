using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cainos.LucidEditor;
//using UnityEditor.SceneManagement;
using UnityEditor;

namespace Cainos.PixelArtPlatformer_Dungeon
{
    public class Switch : MonoBehaviour, IInteractable
    {
        [FoldoutGroup("Reference")] public Door target;
        [Space]
        [FoldoutGroup("Reference")] public SpriteRenderer spriteRenderer;
        [FoldoutGroup("Reference")] public Sprite spriteOn;
        [FoldoutGroup("Reference")] public Sprite spriteOff;

        private Animator Animator
        {
            get
            {
                if (animator == null) animator = GetComponent<Animator>();
                return animator;
            }
        }
        private Animator animator;

        private bool AnimationEnd
        {
            get
            {
                return Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f;
            }
        }

        private void Start()
        {
            Animator.SetBool("IsOn", isOn);
            IsOn = isOn;
            GameManager.OnPlayerDie.AddListener(()=>IsOn = false);
        }

        [FoldoutGroup("Runtime"), ShowInInspector]
        public bool IsOn
        {
            get { return isOn; }
            set
            {
                if (AnimationEnd == false) return; // 애니메이션 실행중이면 중단

                isOn = value;

                #if UNITY_EDITOR
                if (Application.isPlaying == false)
                {
                    EditorUtility.SetDirty(this);
                    //EditorSceneManager.MarkSceneDirty(gameObject.scene);
                }
                #endif

                if (target) target.IsOpened = isOn;

                if (Application.isPlaying )
                {
                    Animator.SetBool("IsOn", isOn);
                }
                else
                {
                    if (spriteRenderer) spriteRenderer.sprite = isOn ? spriteOn: spriteOff;
                }

                if (!GameManager.Instance.isPlayerDying)
                {
                    SoundManager.Instance.PlaySFX("Switch", transform.position);
                }
            }
        }
        [SerializeField, HideInInspector]
        private bool isOn;

        [FoldoutGroup("Runtime"), HorizontalGroup("Runtime/Button"), Button("Turn On")]
        public void TurnOn()
        {
            IsOn = true;
        }

        [FoldoutGroup("Runtime"), HorizontalGroup("Runtime/Button"), Button("Turn Off")]
        public void TurnOff()
        {
            IsOn = false;
        }

        public void InteractEnter()
        {
        }

        public void Interact()
        {
            IsOn = !IsOn;
        }

        public void InteractExit()
        {
        }
    }
}
