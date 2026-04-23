using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeDoorSymbolAngle
{
    public class DoorSymbolInfo : INotifyPropertyChanged
    {
        public FamilySymbol DoorSymbol { get; set; }
        public string FamilyName { get; set; }
        public string SymbolName { get; set; }
        public bool IsReadOnly { get; set; }
        public string IsReadOnlyToString { get; set; }
        public string ParaName { get; set; }

        private Parameter _angle;

        

        public Parameter Angle
        {
            get { return _angle; }
            set
            {
                if (_angle != value)
                {
                    _angle = value;
                    OnPropertyChanged(nameof(Angle));
                }
            }
        }
        private double _angleValue;
        public double AngleValue
        {
            get { return _angleValue; }
            set
            {
                if (_angleValue != value)
                {
                    _angleValue = value;
                    OnPropertyChanged(nameof(AngleValue));
                }
            }
        }
        public List<double> DefaultAngles { get; private set; } = new List<double>() { 0, 45, 90 };

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            // 展示数据变化
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }
}
