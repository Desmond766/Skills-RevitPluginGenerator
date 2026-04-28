---
kind: method
id: M:Autodesk.Revit.DB.DimensionType.SetEqualityFormula(System.Collections.Generic.IList{Autodesk.Revit.DB.DimensionEqualityLabelFormatting})
source: html/1fbbcd04-ce47-e054-6ed7-706171f97ec0.htm
---
# Autodesk.Revit.DB.DimensionType.SetEqualityFormula Method

Sets an ordered list of the entries to use in the equality formula definition.

## Syntax (C#)
```csharp
public void SetEqualityFormula(
	IList<DimensionEqualityLabelFormatting> formattingArr
)
```

## Parameters
- **formattingArr** (`System.Collections.Generic.IList < DimensionEqualityLabelFormatting >`) - An ordered list of the entries to use in the equality formula definition.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input equality formula entries are not valid for use in the given DimensionType.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

