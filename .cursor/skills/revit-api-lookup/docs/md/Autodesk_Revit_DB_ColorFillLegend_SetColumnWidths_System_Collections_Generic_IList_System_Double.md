---
kind: method
id: M:Autodesk.Revit.DB.ColorFillLegend.SetColumnWidths(System.Collections.Generic.IList{System.Double})
source: html/c1ea9e90-071a-f7ca-fe00-0fb566396b4d.htm
---
# Autodesk.Revit.DB.ColorFillLegend.SetColumnWidths Method

Sets array of column widths.

## Syntax (C#)
```csharp
public void SetColumnWidths(
	IList<double> widths
)
```

## Parameters
- **widths** (`System.Collections.Generic.IList < Double >`)

## Remarks
Input array length must be the same as what GetColumnWidths () () () returns. It can only contain positive values.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Array is not valid.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

