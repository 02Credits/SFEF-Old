using MonoGame.Interop.Modules;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapRenderer;
using Caliburn.Micro;

namespace SFEF.ViewModels
{
    public interface IMapRendererViewModel
    {
        IGameModule GameModule { get; set; }
    }

    public class MapRendererViewModel : PropertyChangedBase, IMapRendererViewModel
    {
        private IKernel kernel;
        private IGameModule gameModule;

        public IGameModule GameModule
        {
            get
            {
                return gameModule;
            }
            set
            {
                gameModule = value;
            }
        }

        public MapRendererViewModel(IKernel kernel)
        {
            this.kernel = kernel;
            GameModule = new MapRenderer.MapRenderer();
        }
    }
}
