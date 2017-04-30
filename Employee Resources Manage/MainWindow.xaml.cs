using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using Employee_Resources_Manage.Domain;
using System.Windows.Controls.Primitives;
using System.Threading;
using MaterialDesignThemes.Wpf.Transitions;
using MahApps.Metro;
using MaterialDesignThemes.Wpf;
using Dragablz;

namespace Employee_Resources_Manage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            ListsAndGridsViewModel manageItems = new ListsAndGridsViewModel();
            manageItemsControl.DataContext = manageItems;
            manageItemsControl2.DataContext = manageItems;
        }

        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            //Close();
            contentControl.Content = null;
        }

        private void MetroWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.E && Keyboard.IsKeyDown(Key.LeftCtrl))
            {
                Close();
            }
        }

        private readonly Lazy<IEnumerable<PackIconKind>> _packIconKinds;

        private void UIElement_OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //until we had a StaysOpen glag to Drawer, this will help with scroll bars
            var dependencyObject = Mouse.Captured as DependencyObject;
            while (dependencyObject != null)
            {
                if (dependencyObject is ScrollBar) return;
                dependencyObject = VisualTreeHelper.GetParent(dependencyObject);
            }
            if (Transitioner.SelectedIndex == 0)
            {
                borderManageControl2.SetResourceReference(Border.BackgroundProperty, "PrimaryHueMidBrush");
                borderManageControl1.SetResourceReference(Border.BackgroundProperty, "PrimaryHueLightBrush");
                tbManage2.Text = ((SelectableViewModel)manageItemsControl.SelectedItem).Name;
                packIconListViewSelected2.Kind = (PackIconKind)((SelectableViewModel)manageItemsControl.SelectedItem).IconNum;
                Transitioner.SelectedIndex = 1;
            }
            else
            {
                borderManageControl1.SetResourceReference(Border.BackgroundProperty, "PrimaryHueMidBrush");
                borderManageControl2.SetResourceReference(Border.BackgroundProperty, "PrimaryHueLightBrush");
                packIconListViewSelected1.Kind = (PackIconKind)((SelectableViewModel)manageItemsControl.SelectedItem).IconNum;
                tbManage1.Text = ((SelectableViewModel)manageItemsControl.SelectedItem).Name;
                Transitioner.SelectedIndex = 0;
            }

            MenuToggleButton.IsChecked = false;
        }

        private void UIElementChild_OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //until we had a StaysOpen glag to Drawer, this will help with scroll bars
            var dependencyObject = Mouse.Captured as DependencyObject;
            while (dependencyObject != null)
            {
                if (dependencyObject is ScrollBar) return;
                dependencyObject = VisualTreeHelper.GetParent(dependencyObject);
            }
            TabItem tab = new TabItem();
            tab.Header = ((SelectableViewModel)manageItemsControl2.SelectedItem).Name;
            tabMain.Items.Add(tab);
        }

        bool tabHeaderFocus = false;

        private void UIElementCloseTab_OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var dependencyObject = Mouse.Captured as DependencyObject;
            while (dependencyObject != null)
            {
                if (dependencyObject is DragablzItemsControl)
                {
                    tabHeaderFocus = true;
                    break;
                }
                dependencyObject = VisualTreeHelper.GetParent(dependencyObject);
            }
            
            dependencyObject = Mouse.Captured as DependencyObject;
            while (dependencyObject != null)
            {
                if (dependencyObject is Button && tabHeaderFocus == true)
                {
                    if (tabMain.Items.Count == 1)
                    {
                        tabMain.Items.RemoveAt(0);
                    }
                    tabHeaderFocus = false;
                    return;
                }
                dependencyObject = VisualTreeHelper.GetParent(dependencyObject);
            }
            tabHeaderFocus = false;
        }

        bool IsChangedTheme = false;
        object palContent;

        private void MenuItemTheme_Click(object sender, RoutedEventArgs e)
        {
            TransitioningContent transitioningContent = new TransitioningContent();
            TransitionEffect effect = new TransitionEffect();
            effect.Kind = TransitionEffectKind.ExpandIn;
            transitioningContent.OpeningEffect = effect;

            if (IsChangedTheme == false)
            {
                palContent = new PaletteSelector();
                transitioningContent.Content = palContent;
                contentControl.Content = transitioningContent;
                IsChangedTheme = true;
            }
            else
            {
                transitioningContent.Content = palContent;
                contentControl.Content = transitioningContent;
            }
        }

        private void MenuItemChangePassword_Click(object sender, RoutedEventArgs e)
        {
            ChangePassword changePw = new ChangePassword();
            DialogHost.Show(changePw);
        }


        private void UIManageControl_OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MenuToggleButton.IsChecked = (MenuToggleButton.IsChecked == false) ? true : false;
        }

        bool collapseIsCheck = false;

        private void btnCollapse_Click(object sender, RoutedEventArgs e)
        {
            if (collapseIsCheck == false)
            {
                colChucNang.MinWidth = 40;
                colChucNang.MaxWidth = 40;
                packIconCollapse.Kind = PackIconKind.ChevronRight;
                collapseIsCheck = true;
            }
            else
            {
                colChucNang.MinWidth = 200;
                colChucNang.MaxWidth = 400;
                packIconCollapse.Kind = PackIconKind.ChevronLeft;
                collapseIsCheck = false;
            }
        }
    }
}
