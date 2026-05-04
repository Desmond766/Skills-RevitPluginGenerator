---
kind: method
id: M:Autodesk.Revit.DB.TableSectionData.RemoveRow(System.Int32)
source: html/99753a1f-3e91-2220-07ea-2dd0e2506f99.htm
---
# Autodesk.Revit.DB.TableSectionData.RemoveRow Method

Removes a row data at a specified index.

## Syntax (C#)
```csharp
public void RemoveRow(
	int nIndex
)
```

## Parameters
- **nIndex** (`System.Int32`) - An integer index.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The row can't be removed because it's an element in linked file, default zone
 or it's a row in body section of Material Quantity Take Off Schedule
 or it's the last row in header section of standard schedule
 or nIndex is invalid index.

