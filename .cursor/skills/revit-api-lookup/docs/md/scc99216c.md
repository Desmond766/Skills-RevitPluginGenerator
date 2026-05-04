---
kind: method
id: M:Autodesk.Revit.DB.FilledRegionType.IsValidSolidFillPatternId(Autodesk.Revit.DB.ElementId)
source: html/6daab179-221d-8844-0677-f256de956add.htm
---
# Autodesk.Revit.DB.FilledRegionType.IsValidSolidFillPatternId Method

Checks if the id is valid for a background pattern

## Syntax (C#)
```csharp
public bool IsValidSolidFillPatternId(
	ElementId patternId
)
```

## Parameters
- **patternId** (`Autodesk.Revit.DB.ElementId`) - Element id of the FillPatternElement

## Returns
False if in a family and the id is a solid fill pattern and 'isMasking' is masking is false.
 True otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

