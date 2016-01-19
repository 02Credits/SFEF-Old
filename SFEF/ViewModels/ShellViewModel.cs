using Caliburn.Micro;
using Ninject;

namespace SFEF.ViewModels
{
    public interface IShellViewModel
    {
        IGameRendererViewModel MapRendererViewModel { get; }
    }

    public class ShellViewModel : PropertyChangedBase, IShellViewModel
    {
        public IGameRendererViewModel MapRendererViewModel { get; set; }
        public ISideBarViewModel SideBarViewModel { get; set; }

        public ShellViewModel(IGameRendererViewModelFactory gameRendererViewModelFactory, ISideBarViewModel sideBarViewModel)
        {
            MapRendererViewModel = gameRendererViewModelFactory.Create(new MapRenderer.MapRenderer());
            SideBarViewModel = sideBarViewModel;
        }
    }
}
