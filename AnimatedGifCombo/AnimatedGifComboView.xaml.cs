using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AnimatedGifCombo
{
   
    public partial class AnimatedGifComboView : UserControl
    {


        public ObservableCollection<AnimatedCut> AnimatedCuts
        {
            get { return (ObservableCollection<AnimatedCut>)GetValue(AnimatedCutsProperty); }
            set { SetValue(AnimatedCutsProperty, value); }
        }
        public static readonly DependencyProperty AnimatedCutsProperty =
            DependencyProperty.Register("AnimatedCuts", typeof(ObservableCollection<AnimatedCut>), typeof(AnimatedGifComboView), new PropertyMetadata(null));


        

        public AnimatedGifComboView()
        {
            AnimatedCuts = new ObservableCollection<AnimatedCut>();
            InitializeComponent();
            loadAnimatedGifs();
        }

        private void loadAnimatedGifs()
        {
            var executingAssembly = Assembly.GetExecutingAssembly();
            var execName = executingAssembly.GetName().Name;

            var resourceManager = new ResourceManager($"{execName}.g", Assembly.GetExecutingAssembly());

            var resources = resourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            foreach (var res in resources)
            {
                var resource = ((DictionaryEntry)res).Key.ToString();
                Debug.Print(resource + "\n");
                if (resource.EndsWith(".gif"))
                {
                    var substrings = resource.Split('/', '.');
                    //string packUri = $"pack://application:,,,/AssemblyName;component/{resource}";
                    //packUri = $"pack://application:,,,/AssemblyName;component/CutAnimations/taglio.gif";
                    AnimatedCuts.Add(new AnimatedCut(substrings[1], resource));
                }
                
            }

            //string packUri = $"pack://application:,,,/AssemblyName;component/CutAnimations/taglio.gif";
            //img1.Source = new BitmapImage(new Uri(AnimatedCuts[0].Uri, UriKind.Relative));
            // https://stackoverflow.com/questions/210922/how-do-i-get-an-animated-gif-to-work-in-wpf

        }
    }
}
