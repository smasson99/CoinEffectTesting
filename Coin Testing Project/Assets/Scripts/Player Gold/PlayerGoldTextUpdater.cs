using System;
using UnityEngine;
using UnityEngine.UI;

namespace Player_Gold
{
    public class PlayerGoldTextUpdater : MonoBehaviour
    {
        private Text goldText;

        [SerializeField]
        private PlayerGoldContainer playerGoldContainer;

        private void Awake()
        {
            InitializeComponents();
            VerifyComponents();
        }

        private void OnEnable()
        {
            playerGoldContainer.OnGoldPieceAdded += NotifyGoldAdded;
        }
        
        private void OnDisable()
        {
            playerGoldContainer.OnGoldPieceAdded -= NotifyGoldAdded;
        }

        private void InitializeComponents()
        {
            goldText = GetComponent<Text>();
        }

        private void VerifyComponents()
        {
            if (goldText == null)
            {
                throw new ArgumentException(typeof(Text).Name + " not found!");
            }
            if (playerGoldContainer == null)
            {
                throw new ArgumentException(typeof(PlayerGoldContainer).Name + " not found!");
            }
        }

        private void NotifyGoldAdded(int currentNumberOfGold)
        {
            goldText.text = "Gold: " + currentNumberOfGold;
        }
    }
}