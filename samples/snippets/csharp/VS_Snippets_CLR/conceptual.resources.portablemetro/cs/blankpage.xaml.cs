// <Snippet1>
using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using MyCompany.Employees;

namespace ConsumerCS
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BlankPage : Page
    {
        public BlankPage()
        {
            this.InitializeComponent();
         }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
           Example.DisplayData(outputBlock);
       }
    }
}

public class Example
{
    static public void DisplayData(Windows.UI.Xaml.Controls.TextBlock outputBlock)
    {
        // Get the data from some data source.
        var employees = InitializeData();
        outputBlock.FontFamily = new FontFamily("Courier New");
        // Display application title.
        string title = UILibrary.GetTitle();
        outputBlock.Text += title + Environment.NewLine + Environment.NewLine;

        // Retrieve resources.
        string[] fields = UILibrary.GetFieldNames();
        int[] lengths = UILibrary.GetFieldLengths();
        string fmtString = String.Empty;
        // Create format string for field headers and data.
        for (int ctr = 0; ctr < fields.Length; ctr++)
            fmtString += String.Format("{{{0},-{1}{2}{3}   ", ctr, lengths[ctr], ctr >= 2 ? ":d" : "", "}");

        // Display the headers.
        outputBlock.Text += String.Format(fmtString, fields) + Environment.NewLine + Environment.NewLine;
        // Display the data.
        foreach (var e in employees)
            outputBlock.Text += String.Format(fmtString, e.Item1, e.Item2, e.Item3, e.Item4) + Environment.NewLine;
    }

    private static List<Tuple<String, String, DateTime, DateTime>> InitializeData()
    {
        List<Tuple<String, String, DateTime, DateTime>> employees = new List<Tuple<String, String, DateTime, DateTime>>();
        var t1 = Tuple.Create("John", "16302", new DateTime(1954, 8, 18), new DateTime(2006, 9, 8));
        employees.Add(t1);
        t1 = Tuple.Create("Alice", "19745", new DateTime(1995, 5, 10), new DateTime(2012, 10, 17));
        employees.Add(t1);
        return employees;
    }
}
// </Snippet1>
