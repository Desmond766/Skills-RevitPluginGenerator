---
kind: property
id: P:Autodesk.Revit.DB.MultiReferenceAnnotationOptions.DimensionStyleType
source: html/2a8891de-4b66-96f9-76cf-bcb2ae75bfb9.htm
---
# Autodesk.Revit.DB.MultiReferenceAnnotationOptions.DimensionStyleType Property

The dimension style type to be used by the new MultiReferenceAnnotation.

## Syntax (C#)
```csharp
public DimensionStyleType DimensionStyleType { get; set; }
```

## Remarks
Only Linear and LinearFixed types are allowed.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: dimensionStyleType must be either Linear or LinearFixed to be used by MultiReferenceAnnotations.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration

