using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Windows;
using System.Windows.Controls;

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
            DependencyProperty.Register("AnimatedCuts",
                typeof(ObservableCollection<AnimatedCut>),
                typeof(AnimatedGifComboView),
                new PropertyMetadata(null)
                );

        public AnimatedCut SelectedCut
        {
            get { return (AnimatedCut)GetValue(SelectedCutProperty); }
            set { SetValue(SelectedCutProperty, value); }
        }

        
        public static readonly DependencyProperty SelectedCutProperty =
            DependencyProperty.Register("SelectedCut", 
                typeof(AnimatedCut), 
                typeof(AnimatedGifComboView), 
                new PropertyMetadata(null, OnSelectedCutChanged));

        private static void OnSelectedCutChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(d is AnimatedGifComboView agCV))
                return;
            
        }

        public AnimatedGifComboView()
        {
            AnimatedCuts = new ObservableCollection<AnimatedCut>();
            InitializeComponent();
        }
        
        private void accb_Loaded(object sender, RoutedEventArgs e)
        {
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
            SelectedCut = AnimatedCuts[0];

            //string packUri = $"pack://application:,,,/AssemblyName;component/CutAnimations/taglio.gif";
            //img1.Source = new BitmapImage(new Uri(AnimatedCuts[0].Uri, UriKind.Relative));
            // https://stackoverflow.com/questions/210922/how-do-i-get-an-animated-gif-to-work-in-wpf

        }

    }
}
