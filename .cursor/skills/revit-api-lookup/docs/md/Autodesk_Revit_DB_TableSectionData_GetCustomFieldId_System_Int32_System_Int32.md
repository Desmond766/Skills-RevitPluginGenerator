---
kind: method
id: M:Autodesk.Revit.DB.TableSectionData.GetCustomFieldId(System.Int32,System.Int32)
source: html/44f81306-f999-885d-0557-e8719eeb0cad.htm
---
# Autodesk.Revit.DB.TableSectionData.GetCustomFieldId Method

Gets custom field id from the cell.

## Syntax (C#)
```csharp
public Guid GetCustomFieldId(
	int row,
	int col
)
```

## Parameters
- **row** (`System.Int32`) - The row of the cell.
- **col** (`System.Int32`) - The column of the cell.

## Returns
Returns custom field id from the cell.
 If this cell is not of type CellType.CustomField it will return an empty Guid

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given row number row is invalid.
 -or-
 The given column number col is invalid.

