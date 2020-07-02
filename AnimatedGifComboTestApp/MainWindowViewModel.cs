using AnimatedGifCombo;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimatedGifComboTestApp
{
public     class MainWindowViewModel : ViewModelBase
    {
        private AnimatedCut _selectedCut;
        public AnimatedCut SelectedCut { 
            get => _selectedCut; 
            set { Set(() => SelectedCut, ref _selectedCut, value); }
        }

        public MainWindowViewModel()
        {
            SelectedCut = new AnimatedCut("Fake", "CutAnimations/taglio_blu.gif");
        }

    }
}
