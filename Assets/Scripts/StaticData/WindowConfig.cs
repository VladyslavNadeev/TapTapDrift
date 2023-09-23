using System;
using RunManGun.Window;
using UnityEngine;

namespace StaticData
{
  [Serializable]
  public class WindowConfig
  {
    public WindowTypeId WindowTypeId;
    public GameObject Prefab;
  }
}