---
kind: method
id: M:Autodesk.Revit.DB.FilledRegionType.IsValidFillPatternId(Autodesk.Revit.DB.ElementId)
source: html/89d56b97-4909-03af-cda7-46e695394124.htm
---
# Autodesk.Revit.DB.FilledRegionType.IsValidFillPatternId Method

Check if the id is a FillPatternElement or an invalidElementId

## Syntax (C#)
```csharp
public bool IsValidFillPatternId(
	ElementId patternId
)
```

## Parameters
- **patternId** (`Autodesk.Revit.DB.ElementId`) - Element id of the FillPatternElement

## Returns
True if the id is InvalidElementId, or if the element is a FillPatternElement.
 False otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

