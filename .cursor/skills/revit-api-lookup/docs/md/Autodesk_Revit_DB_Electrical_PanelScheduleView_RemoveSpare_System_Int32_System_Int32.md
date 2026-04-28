---
kind: method
id: M:Autodesk.Revit.DB.Electrical.PanelScheduleView.RemoveSpare(System.Int32,System.Int32)
source: html/0d177945-8abf-1557-1308-0eb33fae6c93.htm
---
# Autodesk.Revit.DB.Electrical.PanelScheduleView.RemoveSpare Method

Remove a spare at specific cell.

## Syntax (C#)
```csharp
public void RemoveSpare(
	int nRow,
	int nCol
)
```

## Parameters
- **nRow** (`System.Int32`) - Row Number
- **nCol** (`System.Int32`) - Column Number

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentsInconsistentException** - The row column combination does not represent a valid spare.

