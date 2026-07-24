using System;
using System.Collections.ObjectModel;
using System.Windows;
using Microsoft.Win32;
using NBoard.Models;
using NBoard.Services;

namespace NBoard.Views
{
    public partial class StartScreen : Window
    {
        public ObservableCollection<Document> RecentDocuments { get; set; }

        public StartScreen()
        {
            InitializeComponent();
            RecentDocuments = new ObservableCollection<Document>();
            this.DataContext = this;
            LoadRecentDocuments();
        }

        private void LoadRecentDocuments()
        {
            try
            {
                RecentDocuments.Clear();
                var documents = DocumentManager.GetRecentDocuments();
                foreach (var doc in documents)
                {
                    RecentDocuments.Add(doc);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading recent documents: {ex.Message}", "Error");
            }
        }

        private void NewDocumentButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Document doc = new Document("Untitled Document");
                DocumentManager.SaveDocument(doc);
                OpenCanvasWindow(doc);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating document: {ex.Message}", "Error");
            }
        }

        private void OpenDocument_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string filePath = (sender as Button).Tag.ToString();
                Document doc = DocumentManager.LoadDocument(filePath);
                OpenCanvasWindow(doc);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening document: {ex.Message}", "Error");
            }
        }

        private void DeleteDocument_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string filePath = (sender as Button).Tag.ToString();
                if (MessageBox.Show("Are you sure you want to delete this document? This cannot be undone.", 
                    "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    DocumentManager.DeleteDocument(filePath);
                    LoadRecentDocuments();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting document: {ex.Message}", "Error");
            }
        }

        private void OpenFileButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = "NBoard Documents (*.wbd)|*.wbd|All Files (*.*)|*.*",
                    InitialDirectory = DocumentManager.GetDocumentsFolder()
                };

                if (openFileDialog.ShowDialog() == true)
                {
                    Document doc = DocumentManager.LoadDocument(openFileDialog.FileName);
                    OpenCanvasWindow(doc);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening file: {ex.Message}", "Error");
            }
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Settings feature coming soon!\n\nCurrent Settings:\n- Auto-save: Every 30 seconds\n- Location: Documents/NBoard/", "Settings");
        }

        private void OpenCanvasWindow(Document document)
        {
            CanvasWindow canvasWindow = new CanvasWindow(document);
            canvasWindow.Show();
        }
    }
}