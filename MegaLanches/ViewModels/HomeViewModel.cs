using System.Collections.Generic;
using MegaLanches.Models;

namespace MegaLanches.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Lanche> LanchesPreferidos { get; set; }
    }
}