---
kind: method
id: M:Autodesk.Revit.DB.Electrical.PanelScheduleView.RemoveSpace(System.Int32,System.Int32)
source: html/0dfffdde-2f03-ff21-ddb3-3a8c34842cb5.htm
---
# Autodesk.Revit.DB.Electrical.PanelScheduleView.RemoveSpace Method

Remove a space at specific cell.

## Syntax (C#)
```csharp
public void RemoveSpace(
	int nRow,
	int nCol
)
```

## Parameters
- **nRow** (`System.Int32`) - Row Number
- **nCol** (`System.Int32`) - Column Number

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentsInconsistentException** - The row column combination does not represent a valid space.

