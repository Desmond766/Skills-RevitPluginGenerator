---
kind: method
id: M:Autodesk.Revit.DB.FamilySizeTable.GetColumnHeader(System.Int32)
source: html/47c651f5-1306-1f1a-157c-be56737a1b16.htm
---
# Autodesk.Revit.DB.FamilySizeTable.GetColumnHeader Method

Gets a column of the table at at given index.

## Syntax (C#)
```csharp
public FamilySizeTableColumn GetColumnHeader(
	int index
)
```

## Parameters
- **index** (`System.Int32`) - Index of the column.

## Returns
The column at the given index.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The column index is out of range.

