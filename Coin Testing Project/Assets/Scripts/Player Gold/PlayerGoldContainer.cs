using UnityEngine;

namespace Player_Gold
{
    //todo when merging: destroy this file
    public delegate void OnGoldPieceAdded(int currentNumberOfGold);
    
    public class PlayerGoldContainer : MonoBehaviour
    {
        private int numberOfGoldPieces;

        public event OnGoldPieceAdded OnGoldPieceAdded;
        
        private void Awake()
        {
            InitializeValues();
        }

        private void InitializeValues()
        {
            numberOfGoldPieces = 0;
        }

        private void NotifyGoldPieceAdded()
        {
            OnGoldPieceAdded?.Invoke(numberOfGoldPieces);
        }

        public void AddGold(int numberToAdd)
        {
            numberOfGoldPieces += numberToAdd;
            NotifyGoldPieceAdded();
        }
    }
    //
}