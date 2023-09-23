using RunManGun.Window;
using UnityEngine;

namespace Infrastructure.Services.Factories.UIFactory
{
  public interface IUIFactory
  {
    void CreateUiRoot();
    RectTransform CrateWindow(WindowTypeId windowTypeId);
  }
}