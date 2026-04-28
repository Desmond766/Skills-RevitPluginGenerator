---
kind: method
id: M:Autodesk.Revit.DB.FilledRegionType.IsValidForegroundPatternId(Autodesk.Revit.DB.ElementId)
source: html/af2a14d3-08b4-76ae-f05d-57b840bc77fa.htm
---
# Autodesk.Revit.DB.FilledRegionType.IsValidForegroundPatternId Method

Check if the id is valid for a foreground pattern

## Syntax (C#)
```csharp
public bool IsValidForegroundPatternId(
	ElementId patternId
)
```

## Parameters
- **patternId** (`Autodesk.Revit.DB.ElementId`) - Element id of the FillPatternElement

## Returns
False if in a family, and the id is a FillPatternElement that targets 'Drafting'.
 True otherwise.

## Remarks
In a family the FillPatternElement must be a 'Drafting' pattern.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

