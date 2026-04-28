# Sample Snippet: ChangeDoorSymbolAngle

Source project: `existingCodes\梁涛插件源代码\1.土建\ChangeDoorSymbolAngle\ChangeDoorSymbolAngle`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeDoorSymbolAngle
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            var doorSymbols = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Doors).WhereElementIsElementType().Cast<FamilySymbol>()
                .Where(ds => ds.Family.FamilyCategory.Name == "门");
            List<DoorSymbolInfo> doors = new List<DoorSymbolInfo>();
            foreach (var symbol in doorSymbols)
            {
                foreach (Parameter para in symbol.Parameters)
                {
                    if (para.Definition.Name.Contains("角度") && para.StorageType == StorageType.Double)
                    {
                        DoorSymbolInfo symbolInfo = new DoorSymbolInfo()
                        {
                            SymbolName = symbol.Name,
                            FamilyName = symbol.FamilyName,
                            DoorSymbol = symbol,
                            IsReadOnly = para.IsReadOnly,
                            IsReadOnlyToString = para.IsReadOnly == true ? "是" : "否",
                            ParaName = para.Definition.Name,
                            AngleValue = para.AsDouble() * 180 / Math.PI,
                            Angle = para
                        };
                        doors.Add(symbolInfo);
                    }
                }
            }
            //doors.ForEach(ds => ds.IsReadOnly = true);
            doors = doors.OrderBy(ds => ds.FamilyName).ToList();
            MainWindow mainWindow = new MainWindow(doors);
            //mainWindow.dataGrid.ItemsSource = doors;
            mainWindow.ShowDialog();

            if (mainWindow.DialogResult == false)
            {
                return Result.Cancelled;
            }
            using (Transaction t = new Transaction(doc, "门类型角度批量修改"))
            {
                t.Start();

                foreach (var symbol in doors)
                {
                    if (symbol.IsReadOnly == false && symbol.AngleValue != symbol.Angle.AsDouble() * 180 / Math.PI)
                    {
                        symbol.Angle.Set(symbol.AngleValue * Math.PI / 180);
                    }
                }

                t.Commit();
            }

            return Result.Succeeded;
        }
    }
}

```

## DoorSymbolInfo.cs

```csharp
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

```

