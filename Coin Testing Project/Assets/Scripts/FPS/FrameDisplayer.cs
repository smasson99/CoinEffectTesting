using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrameDisplayer : MonoBehaviour
{
  [Tooltip("The speed to apply when the object rotates.")]
  [SerializeField]
  private Text frameText = null;

  public Text FrameText
  {
    get => frameText;
    private set => frameText = value;
  }

  public const string FRAME_TEXT = "FPS: ";
}