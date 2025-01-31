using System.Collections.ObjectModel;
using System.Windows.Input;
using _2vdm_spec_generator.Models;
using CommunityToolkit.Maui.Behaviors;

namespace _2vdm_spec_generator.Controls
{
    public partial class TreeView : ContentView
    {
        public static readonly BindableProperty ItemsProperty =
            BindableProperty.Create(nameof(Items), typeof(ObservableCollection<FileSystemItem>),
                typeof(TreeView), null);
        
        public static readonly BindableProperty ProjectRootPathProperty =
            BindableProperty.Create(nameof(ProjectRootPath), typeof(string),
                typeof(TreeView), string.Empty);

        public static readonly BindableProperty ItemTappedCommandProperty =
            BindableProperty.Create(nameof(ItemTappedCommand), typeof(ICommand),
                typeof(TreeView), null);

        public static readonly BindableProperty FontSizeProperty =
            BindableProperty.Create(nameof(FontSize), typeof(double),
                typeof(TreeView), 14.0);

        public ObservableCollection<FileSystemItem> Items
        {
            get => (ObservableCollection<FileSystemItem>)GetValue(ItemsProperty);
            set => SetValue(ItemsProperty, value);
        }
        
        public string ProjectRootPath
        {
            get => (string)GetValue(ProjectRootPathProperty);
            set => SetValue(ProjectRootPathProperty, value);
        }

        public ICommand ItemTappedCommand
        {
            get => (ICommand)GetValue(ItemTappedCommandProperty);
            set => SetValue(ItemTappedCommandProperty, value);
        }

        public double FontSize
        {
            get => (double)GetValue(FontSizeProperty);
            set => SetValue(FontSizeProperty, value);
        }

        public TreeView()
        {
            InitializeComponent();
            
            // TouchBehaviorの設定
            var touchBehavior = new TouchBehavior
            {
                HoveredBackgroundColor = Colors.AliceBlue,
                PressedBackgroundColor = Colors.LightGray,
                DefaultBackgroundColor = Colors.Transparent
            };
        }
    }
}