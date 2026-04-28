---
kind: method
id: M:Autodesk.Revit.DB.TableSectionData.GetCellFormatOptions(System.Int32,Autodesk.Revit.DB.Document)
source: html/6964d54a-219f-59df-1266-a6f619da51e3.htm
---
# Autodesk.Revit.DB.TableSectionData.GetCellFormatOptions Method

Returns a column's cell FormatOptions and if no FormatOptions exists for this column,
 it would come from the section.

## Syntax (C#)
```csharp
public FormatOptions GetCellFormatOptions(
	int nCol,
	Document dcument
)
```

## Parameters
- **nCol** (`System.Int32`)
- **dcument** (`Autodesk.Revit.DB.Document`)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given column number nCol is invalid.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

