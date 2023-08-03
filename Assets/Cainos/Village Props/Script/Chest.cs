using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cainos.LucidEditor;

namespace Cainos.PixelArtPlatformer_VillageProps
{
    public class Chest : MonoBehaviour
    {
        [FoldoutGroup("Reference")]
        public Animator animator;

        [FoldoutGroup("Runtime"), ShowInInspector, DisableInEditMode]
        public bool IsOpened
        {
            get { return isOpened; }
            set
            {
                isOpened = value;
                
                animator.SetBool("IsOpened", isOpened);

                if (isOpened)
                {
                    SoundManager.Instance.PlaySFX("ChestOpen", transform.position);
                    enabled = false;
                }
            }
        }
        private bool isOpened;

        [FoldoutGroup("Runtime"),Button("Open"), HorizontalGroup("Runtime/Button")]
        public void Open()
        {
            IsOpened = true;
        }

        [FoldoutGroup("Runtime"), Button("Close"), HorizontalGroup("Runtime/Button")]
        public void Close()
        {
            IsOpened = false;
        }

        public void Start()
        {
            GameManager.OnPlayerDie.AddListener(() => Close());
        }

        public void Interact()
        {
            if (IsOpened) return;
            IsOpened = true;
        }

        public void InteractEnter()
        {
        }

        public void InteractExit()
        {
        }
    }
}
