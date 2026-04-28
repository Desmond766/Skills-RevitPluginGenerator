---
kind: method
id: M:Autodesk.Revit.DB.TableSectionData.RemoveColumn(System.Int32)
source: html/dc0342a0-4707-30f8-bfa2-285caad5bcfd.htm
---
# Autodesk.Revit.DB.TableSectionData.RemoveColumn Method

Removes a column data at a specified index.

## Syntax (C#)
```csharp
public void RemoveColumn(
	int nIndex
)
```

## Parameters
- **nIndex** (`System.Int32`) - An integer index

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - nIndex is invalid index.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This operation is forbidden for cells in standard schedule body sections.

