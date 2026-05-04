---
kind: method
id: M:Autodesk.Revit.DB.FilledRegionType.IsValidBackgroundPatternId(Autodesk.Revit.DB.ElementId)
source: html/b28e67d3-68ed-d50f-59e8-c0436a41d25f.htm
---
# Autodesk.Revit.DB.FilledRegionType.IsValidBackgroundPatternId Method

Check if the id is valid for a background pattern

## Syntax (C#)
```csharp
public bool IsValidBackgroundPatternId(
	ElementId patternId
)
```

## Parameters
- **patternId** (`Autodesk.Revit.DB.ElementId`) - Element id of the FillPatternElement

## Returns
False if the FillPatternElement is a model pattern.
 True otherwise.

## Remarks
The FillPatternElement must be a 'Drafting' pattern.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

