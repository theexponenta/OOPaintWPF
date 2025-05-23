﻿using System;
using System.Threading;
using System.Windows.Media.Imaging;
using OOPaint.Shapes;
using System.Windows.Input;
using OOPaint.Tools;
using Shared;


namespace OOPaint
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Forms;
    using System.Windows.Input;
    using System.Windows.Media;

    using MessageBox = System.Windows.Forms.MessageBox;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {

        private OOPaintApp app;
        
        public MainWindow()
        {
            InitializeComponent();
            
            app = new OOPaintApp(DrawCanvas);
            app.AddTool(new LineTool(app));
            app.AddTool(new PolylineTool(app));
            app.AddTool(new RectangleTool(app));
            app.AddTool(new PolygonTool(app));
            app.AddTool(new EllipseTool(app));

            DrawCanvas.App = app;
        }

        public void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            app.DispatchEvent(EventType.MOUSEDOWN, sender, e);
        }

        public void Canvas_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            app.DispatchEvent(EventType.MOUSEMOVE, sender, e);
        }

        public void Canvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            app.DispatchEvent(EventType.MOUSEUP, sender, e);
            DrawCanvas.InvalidateVisual();
        }

        public void Canvas_MouseClick(object sender, MouseButtonEventArgs e)
        {
            app.DispatchEvent(EventType.MOUSECLICK, sender, e);
        }

        private void ToolComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (app != null)
            {
                app.SelectedToolIndex = ToolComboBox.SelectedIndex;
            }
        }

        private void LineWidthSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (app != null)
            {
                app.SelectedLineWidth = (int)LineWidthSlider.Value;
            }
            
        }

        private Color SelectColor(Color fallbackColor)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return Color.FromArgb(dialog.Color.A, dialog.Color.R, dialog.Color.G, dialog.Color.B);
            }

            return fallbackColor;
        }

        private void StrokeColorButton_Click(object sender, RoutedEventArgs e)
        {
            Color color = SelectColor(((SolidColorBrush)StrokeColorButton.Background).Color);
            Brush brush = new SolidColorBrush(color);
            StrokeColorButton.Background = brush;
            app.SelectedStrokeColor = color;
        }


        private void FillColorButton_Click(object sender, RoutedEventArgs e)
        {
            Color color = SelectColor(((SolidColorBrush)FillColorButton.Background).Color);
            Brush brush = new SolidColorBrush(color);
            FillColorButton.Background = brush;
            app.SelectedFillColor = color;
        }

        public void UndoButton_Click(object sender, RoutedEventArgs e)
        {
            app.Undo();
            app.Redraw();
        }

        public void RedoButton_Click(object sender, RoutedEventArgs e)
        {
            app.Redo();
            app.Redraw();
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Z && e.KeyboardDevice.Modifiers.HasFlag(ModifierKeys.Control))
            {
                if (e.KeyboardDevice.Modifiers.HasFlag(ModifierKeys.Alt))
                    app.Redo();
                else
                    app.Undo();

                app.Redraw();
            }
            
            app.DispatchEvent(EventType.KEYDOWN, sender, e);
        }

        public void SaveAsButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                app.SaveToFile(saveFileDialog.FileName);
            }
        }

        public void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                app.LoadFromFile(openFileDialog.FileName);
                app.Redraw();
            }
        }

        private void AddToolButton(string toolName)
        {
            /*Image image = new Image
            {
                Source = new BitmapImage(new Uri("pack://application:,,,/res/oval_tool.png")),
                Margin = new Thickness(0, 0, 10, 0),
                Width = 16, // при необходимости
                Height = 16
            };*/

            TextBlock textBlock = new TextBlock();
            textBlock.Text = toolName;

            StackPanel stackPanel = new StackPanel();
            stackPanel.Orientation = System.Windows.Controls.Orientation.Horizontal;
            //stackPanel.Children.Add(image);
            stackPanel.Children.Add(textBlock);

            ComboBoxItem comboBoxItem = new ComboBoxItem();
            comboBoxItem.Content = stackPanel;

            ToolComboBox.Items.Add(comboBoxItem);
        }

        private void LoadPlugin_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                IPlugin plugin = PluginLoader.GetPlugin(openFileDialog.FileName);
                if (plugin == null)
                {
                    MessageBox.Show("Ошибка загрузки плагина");
                    return;
                }

                app.AddTool(plugin.GetTool(app));
                AddToolButton(plugin.Name);
            }
        }
    }
}