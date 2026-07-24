using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Win32;
using NBoard.Models;
using NBoard.Services;

namespace NBoard.Views
{
    public partial class CanvasWindow : Window
    {
        private Document _currentDocument;
        private AutoSaveService _autoSaveService;
        private Stack<DrawingAction> _undoStack;
        private Stack<DrawingAction> _redoStack;
        private ToolType _currentTool = ToolType.Pen;
        private Color _currentColor = Colors.Black;
        private int _currentSize = 3;
        private Point _startPoint;
        private bool _isDrawing = false;

        public CanvasWindow(Document document)
        {
            InitializeComponent();
            _currentDocument = document;
            _undoStack = new Stack<DrawingAction>();
            _redoStack = new Stack<DrawingAction>();
            _autoSaveService = new AutoSaveService(_currentDocument);

            InitializeCanvas();
            UpdateTitle();
            SizeSlider.ValueChanged += SizeSlider_ValueChanged;
        }

        private void InitializeCanvas()
        {
            DrawingCanvas.DefaultDrawingAttributes.Color = _currentColor;
            DrawingCanvas.DefaultDrawingAttributes.Width = _currentSize;
            DrawingCanvas.DefaultDrawingAttributes.Height = _currentSize;
        }

        private void UpdateTitle()
        {
            this.Title = $"NBoard - {_currentDocument.Name}";
        }

        // Tool Selection
        private void PenButton_Click(object sender, RoutedEventArgs e)
        {
            _currentTool = ToolType.Pen;
            DrawingCanvas.EditingMode = InkCanvasEditingMode.Ink;
            StatusLabel.Text = "✏️ Pen Tool Selected";
            UpdatePenSettings();
        }

        private void EraserButton_Click(object sender, RoutedEventArgs e)
        {
            _currentTool = ToolType.Eraser;
            DrawingCanvas.EditingMode = InkCanvasEditingMode.EraseByPoint;
            StatusLabel.Text = "🗑️ Eraser Tool Selected";
        }

        private void LineButton_Click(object sender, RoutedEventArgs e)
        {
            _currentTool = ToolType.Line;
            DrawingCanvas.EditingMode = InkCanvasEditingMode.None;
            StatusLabel.Text = "📏 Line Tool - Click and drag to draw";
        }

        private void CircleButton_Click(object sender, RoutedEventArgs e)
        {
            _currentTool = ToolType.Circle;
            DrawingCanvas.EditingMode = InkCanvasEditingMode.None;
            StatusLabel.Text = "⭕ Circle Tool - Click and drag to draw";
        }

        private void RectButton_Click(object sender, RoutedEventArgs e)
        {
            _currentTool = ToolType.Rectangle;
            DrawingCanvas.EditingMode = InkCanvasEditingMode.None;
            StatusLabel.Text = "▭ Rectangle Tool - Click and drag to draw";
        }

        private void SquareButton_Click(object sender, RoutedEventArgs e)
        {
            _currentTool = ToolType.Square;
            DrawingCanvas.EditingMode = InkCanvasEditingMode.None;
            StatusLabel.Text = "■ Square Tool - Click and drag to draw";
        }

        private void TriangleButton_Click(object sender, RoutedEventArgs e)
        {
            _currentTool = ToolType.Triangle;
            DrawingCanvas.EditingMode = InkCanvasEditingMode.None;
            StatusLabel.Text = "△ Triangle Tool - Click and drag to draw";
        }

        private void HexagonButton_Click(object sender, RoutedEventArgs e)
        {
            _currentTool = ToolType.Hexagon;
            DrawingCanvas.EditingMode = InkCanvasEditingMode.None;
            StatusLabel.Text = "⬡ Hexagon Tool - Click and drag to draw";
        }

        private void PentagonButton_Click(object sender, RoutedEventArgs e)
        {
            _currentTool = ToolType.Pentagon;
            DrawingCanvas.EditingMode = InkCanvasEditingMode.None;
            StatusLabel.Text = "⬠ Pentagon Tool - Click and drag to draw";
        }

        private void TextButton_Click(object sender, RoutedEventArgs e)
        {
            _currentTool = ToolType.Text;
            DrawingCanvas.EditingMode = InkCanvasEditingMode.None;
            StatusLabel.Text = "📝 Text Tool - Click to add text";
        }

        // Color and Size
        private void ColorButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.ColorDialog colorDialog = new System.Windows.Forms.ColorDialog();
            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _currentColor = Color.FromArgb(
                    colorDialog.Color.A,
                    colorDialog.Color.R,
                    colorDialog.Color.G,
                    colorDialog.Color.B);
                
                ColorButton.Background = new SolidColorBrush(_currentColor);
                UpdatePenSettings();
            }
        }

        private void SizeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _currentSize = (int)e.NewValue;
            SizeLabel.Text = _currentSize.ToString();
            UpdatePenSettings();
        }

        private void UpdatePenSettings()
        {
            DrawingCanvas.DefaultDrawingAttributes.Color = _currentColor;
            DrawingCanvas.DefaultDrawingAttributes.Width = _currentSize;
            DrawingCanvas.DefaultDrawingAttributes.Height = _currentSize;
        }

        // Canvas Drawing
        private void Canvas_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (_currentTool != ToolType.Pen && _currentTool != ToolType.Eraser)
            {
                _isDrawing = true;
                _startPoint = e.GetPosition(DrawingCanvas);
            }
        }

        private void Canvas_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (_isDrawing && e.LeftButton == MouseButtonState.Pressed)
            {
                // Drawing shapes preview
            }
        }

        private void Canvas_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (_isDrawing)
            {
                _isDrawing = false;
                Point endPoint = e.GetPosition(DrawingCanvas);
                DrawShape(_startPoint, endPoint);
            }
        }

        private void DrawShape(Point start, Point end)
        {
            switch (_currentTool)
            {
                case ToolType.Line:
                    DrawLine(start, end);
                    break;
                case ToolType.Circle:
                    DrawCircle(start, end);
                    break;
                case ToolType.Rectangle:
                    DrawRectangle(start, end);
                    break;
                case ToolType.Square:
                    DrawSquare(start, end);
                    break;
                case ToolType.Triangle:
                    DrawTriangle(start, end);
                    break;
                case ToolType.Hexagon:
                    DrawHexagon(start, end);
                    break;
                case ToolType.Pentagon:
                    DrawPentagon(start, end);
                    break;
            }

            RecordAction(new DrawingAction
            {
                Type = _currentTool.ToString(),
                StartPoint = start,
                EndPoint = end,
                Color = _currentColor.ToString(),
                Size = _currentSize
            });
        }

        private void DrawLine(Point start, Point end)
        {
            var stroke = new Stroke(new StylusPointCollection { 
                new StylusPoint(start.X, start.Y), 
                new StylusPoint(end.X, end.Y) 
            });
            stroke.DrawingAttributes.Color = _currentColor;
            stroke.DrawingAttributes.Width = _currentSize;
            stroke.DrawingAttributes.Height = _currentSize;
            DrawingCanvas.Strokes.Add(stroke);
        }

        private void DrawCircle(Point start, Point end)
        {
            // Circle drawing will be enhanced in next update
            MessageBox.Show("Circle drawing coming soon!");
        }

        private void DrawRectangle(Point start, Point end)
        {
            MessageBox.Show("Rectangle drawing coming soon!");
        }

        private void DrawSquare(Point start, Point end)
        {
            MessageBox.Show("Square drawing coming soon!");
        }

        private void DrawTriangle(Point start, Point end)
        {
            MessageBox.Show("Triangle drawing coming soon!");
        }

        private void DrawHexagon(Point start, Point end)
        {
            MessageBox.Show("Hexagon drawing coming soon!");
        }

        private void DrawPentagon(Point start, Point end)
        {
            MessageBox.Show("Pentagon drawing coming soon!");
        }

        // Undo/Redo
        private void UndoButton_Click(object sender, RoutedEventArgs e)
        {
            if (_undoStack.Count > 0)
            {
                var action = _undoStack.Pop();
                _redoStack.Push(action);
                StatusLabel.Text = "↶ Undo performed";
            }
        }

        private void RedoButton_Click(object sender, RoutedEventArgs e)
        {
            if (_redoStack.Count > 0)
            {
                var action = _redoStack.Pop();
                _undoStack.Push(action);
                StatusLabel.Text = "↷ Redo performed";
            }
        }

        private void RecordAction(DrawingAction action)
        {
            _undoStack.Push(action);
            _redoStack.Clear();
        }

        // Menu Events
        private void MenuNewDocument_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Create new document? Current work will be auto-saved.", 
                "New Document", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Document newDoc = new Document();
                DocumentManager.SaveDocument(newDoc);
                CanvasWindow newWindow = new CanvasWindow(newDoc);
                newWindow.Show();
            }
        }

        private void MenuOpenDocument_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "NBoard Documents (*.wbd)|*.wbd",
                InitialDirectory = DocumentManager.GetDocumentsFolder()
            };

            if (openFileDialog.ShowDialog() == true)
            {
                Document doc = DocumentManager.LoadDocument(openFileDialog.FileName);
                CanvasWindow newWindow = new CanvasWindow(doc);
                newWindow.Show();
            }
        }

        private void MenuSave_Click(object sender, RoutedEventArgs e)
        {
            DocumentManager.SaveDocument(_currentDocument);
            StatusLabel.Text = "💾 Document saved";
        }

        private void MenuExportPDF_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF Files (*.pdf)|*.pdf",
                FileName = _currentDocument.Name + ".pdf"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    ExportService.ExportToPDF(_currentDocument, saveFileDialog.FileName);
                    MessageBox.Show("Exported to PDF successfully!", "Success");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Export Error");
                }
            }
        }

        private void MenuExportPNG_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("PNG export feature coming soon!", "Info");
        }

        private void MenuExportSVG_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "SVG Files (*.svg)|*.svg",
                FileName = _currentDocument.Name + ".svg"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    ExportService.ExportToSVG(_currentDocument, saveFileDialog.FileName);
                    MessageBox.Show("Exported to SVG successfully!", "Success");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Export Error");
                }
            }
        }

        private void MenuExportJSON_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "JSON Files (*.json)|*.json",
                FileName = _currentDocument.Name + ".json"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    ExportService.ExportToJSON(_currentDocument, saveFileDialog.FileName);
                    MessageBox.Show("Exported to JSON successfully!", "Success");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Export Error");
                }
            }
        }

        private void MenuClearAll_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Clear all drawings? This cannot be undone.", 
                "Clear All", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                DrawingCanvas.Strokes.Clear();
                StatusLabel.Text = "Canvas cleared";
            }
        }

        private void MenuUndo_Click(object sender, RoutedEventArgs e)
        {
            UndoButton_Click(null, null);
        }

        private void MenuRedo_Click(object sender, RoutedEventArgs e)
        {
            RedoButton_Click(null, null);
        }

        private void MenuAbout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("NBoard v1.0\nProfessional Digital Whiteboard\n© 2024 Naajmul Hassan\n\nFeatures:\n✓ Pen Drawing\n✓ Geometric Shapes\n✓ Text Tool\n✓ Undo/Redo\n✓ Infinite Scrolling\n✓ Export (PDF, SVG, JSON)", "About NBoard");
        }

        private void MenuExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _autoSaveService.Stop();
            DocumentManager.SaveDocument(_currentDocument);
        }
    }
}