---
kind: method
id: M:Autodesk.Revit.DB.MultiReferenceAnnotationOptions.IsAllowedDimensionStyleType(Autodesk.Revit.DB.DimensionStyleType)
source: html/967b5c93-8889-a9e6-e1e7-264c876812d5.htm
---
# Autodesk.Revit.DB.MultiReferenceAnnotationOptions.IsAllowedDimensionStyleType Method

Only Linear and LinearFixed dimension style types are allowed for new MultiReferenceAnnotations.

## Syntax (C#)
```csharp
public bool IsAllowedDimensionStyleType(
	DimensionStyleType dimensionStyleType
)
```

## Parameters
- **dimensionStyleType** (`Autodesk.Revit.DB.DimensionStyleType`) - The dimension style type to test.

## Returns
True if the type is allowed.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

