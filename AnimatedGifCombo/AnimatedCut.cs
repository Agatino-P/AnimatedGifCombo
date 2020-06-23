using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AnimatedGifCombo
{
    public class AnimatedCut : ViewModelBase
    {
        private string _name= string.Empty; public string Name { get => _name; set { Set(() => Name, ref _name, value); }}
        private string _uri; public string Uri { get => _uri; set { Set(() => Uri, ref _uri, value); }}


        public AnimatedCut(string name, string uri)
        {
            Name = name;
            Uri = uri;
        }


    }
}
