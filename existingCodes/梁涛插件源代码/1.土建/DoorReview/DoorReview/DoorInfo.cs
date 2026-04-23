using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DoorReview
{
    internal class DoorInfo : INotifyPropertyChanged
    {
        private string _doorName;
        public string DoorName
        {
            get { return _doorName; }
            set
            {
                if (_doorName != value)
                {
                    _doorName = value;
                    OnPropertyChanged(nameof(DoorName));
                }
            }
        }
        public FamilyInstance Door { get; set; }
        public ElementId DoorId { get; set; }
        public string NoteText { get; set; }
        private string _correct;
        public string Correct
        {
            get { return _correct; }
            set
            {
                if (_correct != value)
                {
                    _correct = value;
                    OnPropertyChanged(nameof(Correct));
                }
            }
        }
        private string _textColor;
        public string TextColor
        {
            get { return _textColor; }
            set
            {
                if (_textColor != value)
                {
                    _textColor = value;
                    OnPropertyChanged(nameof(TextColor));
                }
            }

        } // 文字颜色
        private string _textBackColor;
        public string TextBackColor
        {
            get { return _textBackColor; }
            set
            {
                if (_textBackColor != value)
                {
                    _textBackColor = value;
                    OnPropertyChanged(nameof(TextBackColor));
                }
            }
        } // 文字背景颜色
        private bool _isBold;
        public bool IsBold
        {
            get { return _isBold; }
            set
            {
                if (_isBold != value)
                {
                    _isBold = value;
                    OnPropertyChanged(nameof(IsBold));
                }
            }
        }
        public FamilySymbol FamilySymbol { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            // 展示数据变化
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }
    internal class DoorSymbolInfo
    {
        public string SymbolName { get; set; }
        public FamilySymbol FamilySymbol { get; set; }
    }
}
