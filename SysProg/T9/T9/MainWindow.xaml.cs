using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;

namespace T9 {
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window {
      private T9Helper objHelper = new T9Helper();

      public MainWindow() {
         InitializeComponent();
         objHelper.OpenSource("zdf-win.txt");
      }

      private void InitContextMenu(string[] strarrWords) {
         contextMenu.Items.Clear();

         for(int i = 0; i < strarrWords.Length; ++i) {
            var objMenuItem = new MenuItem() {
               Header = strarrWords[i]
            };
            objMenuItem.Click += MenuItem_Click;

            contextMenu.Items.Add(objMenuItem);
         }
      }

      private async void ContextMenuCommand_OnExecuted(object sender, ExecutedRoutedEventArgs args) {
         TextPointer objCaretPosition = richTextBox.CaretPosition;

         string strLastWord = richTextBox.CaretPosition.GetTextInRun(LogicalDirection.Backward).Split(' ').LastOrDefault();

         InitContextMenu(await objHelper.GetWordAsync(strLastWord));
         if(contextMenu.Items.Count == 0) {
            return;
         }

         contextMenu.PlacementTarget = richTextBox;
         contextMenu.Placement = PlacementMode.RelativePoint;
         Rect objRectPosition = objCaretPosition.GetCharacterRect(LogicalDirection.Forward);
         contextMenu.HorizontalOffset = objRectPosition.X;
         contextMenu.VerticalOffset = objRectPosition.Y;
         contextMenu.IsOpen = true;
      }

      private void MenuItem_Click(object sender, RoutedEventArgs e) {
         string strSelectedWord = (sender as MenuItem).Header as string;

         string strLastWord = richTextBox.CaretPosition.GetTextInRun(LogicalDirection.Backward).Split(' ').LastOrDefault();

         string strReplace = richTextBox.CaretPosition.GetTextInRun(LogicalDirection.Forward).TrimEnd(strLastWord.ToCharArray());

         richTextBox.CaretPosition.DeleteTextInRun(-strLastWord.Length);

         richTextBox.CaretPosition.InsertTextInRun(strReplace + strSelectedWord);
         richTextBox.CaretPosition = richTextBox.CaretPosition.DocumentEnd;
      }

      private void ContextMenuCommanc_OnCanExecute(object sender, CanExecuteRoutedEventArgs e) {
         e.CanExecute = true;
         e.Handled = true;
      }
   }
}