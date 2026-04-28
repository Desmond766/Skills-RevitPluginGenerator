---
kind: method
id: M:Autodesk.Revit.DB.TableSectionData.InsertColumn(System.Int32)
source: html/2b50b8b1-8f93-2f94-1002-798ba385708a.htm
---
# Autodesk.Revit.DB.TableSectionData.InsertColumn Method

Inserts a new column at the specified index relative to the current set of columns.

## Syntax (C#)
```csharp
public void InsertColumn(
	int index
)
```

## Parameters
- **index** (`System.Int32`) - An integer index.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - index is invalid index.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This operation is forbidden for cells in standard schedule body sections.

