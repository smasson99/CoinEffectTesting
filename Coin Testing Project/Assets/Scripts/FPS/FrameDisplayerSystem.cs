using Unity.Entities;
using UnityEngine;

namespace FPS
{
  public class FrameDisplayerSystem : ComponentSystem
  {
    private float lastTime = 0.0f;

    private struct Filter
    {
      public FrameDisplayer FrameDisplayer;
    }

    protected override void OnUpdate()
    {
      foreach (Filter entity in GetEntities<Filter>())
      {
        float fps = 1 / Time.deltaTime;

        if (fps > lastTime + 3 || fps < lastTime -3)
        {
          lastTime = fps;
          entity.FrameDisplayer.FrameText.text =
                      FrameDisplayer.FRAME_TEXT + ((int)fps).ToString();
        }

      }
    }
  }
}