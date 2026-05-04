---
kind: method
id: M:Autodesk.Revit.DB.MultiReferenceAnnotationType.IsAllowedDimensionStyle(Autodesk.Revit.DB.ElementId)
source: html/d55188f4-3723-7444-8086-5c23e58333ed.htm
---
# Autodesk.Revit.DB.MultiReferenceAnnotationType.IsAllowedDimensionStyle Method

Checks if the dimension style can be used with multi-reference annotations.

## Syntax (C#)
```csharp
public bool IsAllowedDimensionStyle(
	ElementId dimensionStyleId
)
```

## Parameters
- **dimensionStyleId** (`Autodesk.Revit.DB.ElementId`) - The dimension style to check.

## Returns
True if the dimension style can be used by multi-reference annotations.

## Remarks
Only linear dimension styles are allowed.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

