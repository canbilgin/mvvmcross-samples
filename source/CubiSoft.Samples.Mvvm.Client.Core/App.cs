using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.IoC;

namespace CubiSoft.Samples.Mvvm.Client.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
				
            RegisterAppStart<ViewModels.HubPageViewModel>();
        }
    }
}