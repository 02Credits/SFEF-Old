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
    public interface IGameRendererViewModelFactory
    {
        IGameRendererViewModel Create(IGameModule gameModule);
    }

    public interface IGameRendererViewModel
    {
        IGameModule GameModule { get; set; }
    }

    public class GameRendererViewModel : PropertyChangedBase, IGameRendererViewModel
    {
        public IGameModule GameModule { get; set; }

        public GameRendererViewModel(IGameModule gameModule)
        {
            GameModule = gameModule;
        }
    }
}
