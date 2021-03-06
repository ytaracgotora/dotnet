using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml;

namespace FindGeneratedItems
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : System.Windows.Window
    {

        public Window1()
        {
            InitializeComponent();
        }

        private void ControlTemplateFindElement(object sender, RoutedEventArgs e)
        {
            //<SnippetCTFindElement>
            // Finding the grid that is generated by the ControlTemplate of the Button
            Grid gridInTemplate = (Grid)myButton1.Template.FindName("grid", myButton1);

            // Do something to the ControlTemplate-generated grid
            MessageBox.Show("The actual width of the grid in the ControlTemplate: "
                + gridInTemplate.GetValue(Grid.ActualWidthProperty).ToString());
            //</SnippetCTFindElement>
        }

        private void DataTemplateFindElement(object sender, RoutedEventArgs e)
        {
            // <SnippetDTFindElement>
            // Getting the currently selected ListBoxItem
            // Note that the ListBox must have
            // IsSynchronizedWithCurrentItem set to True for this to work
            ListBoxItem myListBoxItem =
                (ListBoxItem)(myListBox.ItemContainerGenerator.ContainerFromItem(myListBox.Items.CurrentItem));

            // Getting the ContentPresenter of myListBoxItem
            ContentPresenter myContentPresenter = FindVisualChild<ContentPresenter>(myListBoxItem);

            // Finding textBlock from the DataTemplate that is set on that ContentPresenter
            DataTemplate myDataTemplate = myContentPresenter.ContentTemplate;
            TextBlock myTextBlock = (TextBlock)myDataTemplate.FindName("textBlock", myContentPresenter);

            // Do something to the DataTemplate-generated TextBlock
            MessageBox.Show("The text of the TextBlock of the selected list item: "
                + myTextBlock.Text);
            // </SnippetDTFindElement>
        }

        // <SnippetFVC>
        private childItem FindVisualChild<childItem>(DependencyObject obj)
            where childItem : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is childItem)
                {
                    return (childItem)child;
                }
                else
                {
                    childItem childOfChild = FindVisualChild<childItem>(child);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
        }
        // </SnippetFVC>
    }
}