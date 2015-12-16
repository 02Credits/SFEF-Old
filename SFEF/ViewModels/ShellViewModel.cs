using Caliburn.Micro;
using Ninject;

namespace SFEF.ViewModels
{
    public interface IShellViewModel
    {
        IMapRendererViewModel MapRendererViewModel { get; }
    }

    public class ShellViewModel : PropertyChangedBase, IShellViewModel
    {
        private IKernel kernel;
        private IMapRendererViewModel mapRendererViewModel;

        public IMapRendererViewModel MapRendererViewModel
        {
            get
            {
                return mapRendererViewModel;
            }

            private set
            {
                mapRendererViewModel = value;
            }
        }

        public ShellViewModel(IKernel kernel, IMapRendererViewModel mapRendererViewModel)
        {
            this.kernel = kernel;

            MapRendererViewModel = mapRendererViewModel;
        }
    }
}
