using DebuggerOptions;
using Infrastructure.Services.Analytics;
using Infrastructure.Services.AppInfo;
using Infrastructure.Services.AppInfo.Abstractions;
using Infrastructure.Services.DeviceData;
using Infrastructure.Services.DeviceData.Abstractions;
using Infrastructure.Services.Factories.Game;
using Infrastructure.Services.Factories.UIFactory;
using Infrastructure.Services.PersistenceProgress;
using Infrastructure.Services.StaticData;
using Infrastructure.Services.Window;
using Infrastructure.StateMachine;
using Infrastructure.StateMachine.Game;
using Infrastructure.StateMachine.Game.States;
using RunManGun.Infrastructure.Services.Window;
using UnityEngine;
using Zenject;
using Application = UnityEngine.Application;

namespace Infrastructure.Installers
{
    public class BootstrapInstaller : MonoInstaller
    {
        [SerializeField] private CoroutineRunner _coroutineRunner;
        [SerializeField] private LoadingCurtain _curtain;

        private RuntimePlatform Platform => Application.platform;

        public override void InstallBindings()
        {
            Debug.Log("Installer");

            BindMonoServices();
            BindServices();

            BindGameStateMachine();
            BindGameStates();

            BootstrapGame();
            
            InitializeDebugger();
        }

        private void BindServices()
        {
            BindStaticDataService();
            Container.Bind<IUIFactory>().To<UIFactory>().AsSingle();
            Container.Bind<IWindowService>().To<WindowService>().AsSingle();
            Container.Bind<IPersistenceProgressService>().To<PersistenceProgressService>().AsSingle(); 
            Container.Bind<IFPSMeter>().To<FPSMeter>().AsSingle();
            Container.Bind<IRandomService>().To<RandomService>().AsSingle();
            Container.Bind<IGameFactory>().To<GameFactory>().AsSingle();
            BindEnrichedAnalyticService<AnalyticService>();
            BindDeviceDataService(); 
            BindAppInfoService(); 
        }

        private void InitializeDebugger()
        {
            SRDebug.Init();
            
            var srOptions = Container.Instantiate<SROptionsContainer>();
            SRDebug.Instance.AddOptionContainer(srOptions);
        }

        
        private void BindDeviceDataService()
        {
            Container
                .Bind<IDeviceDataService>()
                .FromMethod(SelectImplementation<IDeviceDataService,
                    AndroidDeviceDataService,
                    IOSDeviceDataService,
                    EditorDeviceDataService>)
                .AsSingle();
        }

        private void BindAppInfoService()
        {
            Container
                .Bind<IAppInfoService>()
                .FromMethod(SelectImplementation<IAppInfoService,
                    AndroidAppInfoService,
                    IOSAppInfoService,
                    EditorAppInfoService>)
                .AsSingle();
        }

        private void BindMonoServices()
        {
            Container.Bind<ICoroutineRunner>().FromMethod(() => Container.InstantiatePrefabForComponent<ICoroutineRunner>(_coroutineRunner)).AsSingle();
            Container.Bind<ILoadingCurtain>().FromMethod(() => Container.InstantiatePrefabForComponent<ILoadingCurtain>(_curtain)).AsSingle();

            BindSceneLoader();
        }

        private void BindSceneLoader()
        {
            ISceneLoader sceneLoader = new SceneLoader(Container.Resolve<ICoroutineRunner>());
            Container.Bind<ISceneLoader>().FromInstance(sceneLoader).AsSingle();
        }

        private void BindStaticDataService()
        {
            IStaticDataService staticDataService = new StaticDataService();
            staticDataService.LoadData();
            Container.Bind<IStaticDataService>().FromInstance(staticDataService).AsSingle();
        }

        private void BindGameStateMachine()
        {
            Container.Bind<GameStateFactory>().AsSingle();
            Container.BindInterfacesTo<GameStateMachine>().AsSingle();
        }

        private void BindGameStates()
        {
            Container.Bind<BootstrapState>().AsSingle();
            Container.Bind<LoadProgressState>().AsSingle();
            Container.Bind<BootstrapAnalyticState>().AsSingle();
            Container.Bind<LoadLevelState>().AsSingle();
            Container.Bind<GameLoopState>().AsSingle();
        }

        private void BootstrapGame() => 
            Container.Resolve<IStateMachine<IGameState>>().Enter<BootstrapState>();

        private void BindEnrichedAnalyticService<TAnalytic>() where TAnalytic : IAnalyticService
        {
            Container.Bind<IAnalyticService>()
                .FromMethod(() => Container
                    .Instantiate<AnalyticEnrichService>(new object[]
                    {
                        Container.Instantiate<TAnalytic>()
                    }))
                .AsSingle();
        }

        private TOut SelectImplementation<TOut, TAndroid, TIos, TEditor>() 
            where TAndroid: TOut 
            where TIos: TOut 
            where TEditor: TOut
        {
            TOut implementation = Platform switch
            {
                RuntimePlatform.Android => Container.Instantiate<TAndroid>(),
                RuntimePlatform.IPhonePlayer => Container.Instantiate<TIos>(),
                _ => Container.Instantiate<TEditor>()
            };

            return implementation;
        }
    }
}