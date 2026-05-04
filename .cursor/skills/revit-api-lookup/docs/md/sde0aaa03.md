---
kind: method
id: M:Autodesk.Revit.DB.PrintManager.SelectNewPrintDriver(System.String)
source: html/7de58a88-684b-5bc2-f433-63bed6170dac.htm
---
# Autodesk.Revit.DB.PrintManager.SelectNewPrintDriver Method

Select a new printer.

## Syntax (C#)
```csharp
public void SelectNewPrintDriver(
	string strPrinterName
)
```

## Parameters
- **strPrinterName** (`System.String`) - The name string of new printer.

## Remarks
This property is the global print setting property for all documents.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input argument-strPrinterName-is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the assigned new printer is invalid,
or the print resource is occupied by others.

