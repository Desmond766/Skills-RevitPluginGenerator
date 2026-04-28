---
kind: method
id: M:Autodesk.Revit.DB.TableSectionData.MergeCells(Autodesk.Revit.DB.TableMergedCell)
source: html/cc792f4a-ce9c-9f0c-f366-5176e72fc4b1.htm
---
# Autodesk.Revit.DB.TableSectionData.MergeCells Method

Merges cells for the given area.

## Syntax (C#)
```csharp
public void MergeCells(
	TableMergedCell mergedCell
)
```

## Parameters
- **mergedCell** (`Autodesk.Revit.DB.TableMergedCell`)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given TableMergedCell mergedCell is outside of acceptable range.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This operation is forbidden for cells in standard schedule body sections.

