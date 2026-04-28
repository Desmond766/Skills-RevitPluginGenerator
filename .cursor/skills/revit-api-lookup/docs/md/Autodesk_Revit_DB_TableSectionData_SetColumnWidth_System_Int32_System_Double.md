---
kind: method
id: M:Autodesk.Revit.DB.TableSectionData.SetColumnWidth(System.Int32,System.Double)
source: html/357aecb6-b093-192a-a95d-421363704c3e.htm
---
# Autodesk.Revit.DB.TableSectionData.SetColumnWidth Method

Sets a column's width in feet

## Syntax (C#)
```csharp
public void SetColumnWidth(
	int nCol,
	double width
)
```

## Parameters
- **nCol** (`System.Int32`)
- **width** (`System.Double`)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given column number nCol is invalid.
 -or-
 The column width is outside of acceptable range.

