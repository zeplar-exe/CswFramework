using System;
using System.Linq;

namespace CswFramework
{
    public class TextCaret
    {
        private string context;

        public int LineCount => context.Split(Environment.NewLine).Length;

        public int Line
        {
            get
            {
                var characterCount = 0;
                var split = context.Split(Environment.NewLine);
                
                for (var lineIndex = 0; lineIndex < split.Length; lineIndex++)
                {
                    if (characterCount >= Index)
                        return lineIndex;
                    
                    var line = split[lineIndex];
                    
                    characterCount += line.Length;
                }

                return 0;
            }
        }

        public int Column
        {
            get
            {
                var characterCount = 0;
                var split = context.Split('\n');
                var lineIndex = 0;
                
                for (; lineIndex < split.Length; lineIndex++)
                {
                    if (characterCount >= Index)
                        break;

                    var line = split[lineIndex];
                    
                    characterCount += line.Length;
                }

                for (var columnIndex = 0; columnIndex < split[lineIndex].Length; columnIndex++)
                {
                    if (characterCount + columnIndex == Index)
                        return columnIndex;
                }

                return 0;
            }
        }

        private int index;
        public int Index
        {
            get => index;
            private set
            {
                if (index == value)
                    return;

                index = value;
                IndexChanged?.Invoke(this, value);
            }
        }

        private TextSpan selected;
        public TextSpan Selected
        {
            get => selected;
            private set
            {
                if (selected == value)
                    return;

                selected = value;
                SelectionChanged?.Invoke(this, value);
            } 
        }

        public delegate void SelectionChangedHandler(TextCaret caret, TextSpan selected);
        public event SelectionChangedHandler SelectionChanged;
        
        public delegate void IndexChangedHandler(TextCaret caret, int index);
        public event IndexChangedHandler IndexChanged;
        
        public TextCaret(string text = "")
        {
            UpdateContext(text);
        }
        
        public void UpdateContext(string text)
        {
            context = text;
        }
        
        public void MoveNextLine()
        {
            
        }

        public void MovePreviousLine()
        {
            
        }

        public void MoveNextCharacter()
        {
            if (Index == context.Length - 1)
                return;

            Index++;
        }

        public void MovePreviousCharacter()
        {
            if (Index == 0)
                return;

            Index--;
        }

        public void Select(int start, int end)
        {
            Selected = new TextSpan(context.Skip(start).Take(end - start), start, end);
        }

        public void ClearSelection()
        {
            Selected = CreateEmptySelection();
        }

        private TextSpan CreateEmptySelection()
        {
            return new TextSpan("", Index, Index);
        }
    }
}