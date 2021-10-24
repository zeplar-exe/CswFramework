using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CswFramework
{
    public partial class DynamicTextBox : UserControl
    {
        private readonly StringBuilder textBuilder = new();
        private List<DynamicMetric> metrics; // TODO: Figure out how to implement these

        public readonly TextCaret Caret = new();

        public Typeface Typeface { get; set; }
        public int TextLineHeight { get; set; }
        public int TextFontSize { get; set; }
        
        public DynamicTextBox()
        {
            InitializeComponent();
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            var formatted = CreateFormattedText(textBuilder.ToString());
            drawingContext.DrawText(formatted, new Point());
        }

        private FormattedText CreateFormattedText(string text)
        {
            return new FormattedText(
                textBuilder.ToString(),
                CultureInfo.CurrentCulture, 
                FlowDirection.LeftToRight, 
                Typeface, TextFontSize, 
                Brushes.White, Dip )
            {
                LineHeight = TextLineHeight
            };
        }
        
        private double Dip => VisualTreeHelper.GetDpi(this).PixelsPerDip;
    }
}