---
kind: method
id: M:Autodesk.Revit.DB.TableSectionData.InsertImage(System.Int32,System.Int32,Autodesk.Revit.DB.ElementId)
source: html/a6c93026-735c-dda0-2596-90f4f3c53624.htm
---
# Autodesk.Revit.DB.TableSectionData.InsertImage Method

Inserts a image in the given cell.

## Syntax (C#)
```csharp
public void InsertImage(
	int nRow,
	int nColumn,
	ElementId imageSymbolId
)
```

## Parameters
- **nRow** (`System.Int32`) - The given row index.
- **nColumn** (`System.Int32`) - The given column index.
- **imageSymbolId** (`Autodesk.Revit.DB.ElementId`) - The element id of the image symbol.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given row number nRow is invalid.
 -or-
 The given column number nColumn is invalid.
 -or-
 The image symbol id doesn't represent a valid image symbol element.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

