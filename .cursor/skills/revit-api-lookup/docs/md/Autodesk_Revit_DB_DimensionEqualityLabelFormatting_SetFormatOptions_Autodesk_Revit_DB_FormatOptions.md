---
kind: method
id: M:Autodesk.Revit.DB.DimensionEqualityLabelFormatting.SetFormatOptions(Autodesk.Revit.DB.FormatOptions)
source: html/d52aa799-a1a3-7e06-698b-4c0c8d09221a.htm
---
# Autodesk.Revit.DB.DimensionEqualityLabelFormatting.SetFormatOptions Method

Sets the format options used to show the parameter value.

## Syntax (C#)
```csharp
public void SetFormatOptions(
	FormatOptions formatOptions
)
```

## Parameters
- **formatOptions** (`Autodesk.Revit.DB.FormatOptions`) - The format options to be set.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This DimensionEqualityLabelFormatting uses a LabelType which does not support assignment of FormatOptions.

