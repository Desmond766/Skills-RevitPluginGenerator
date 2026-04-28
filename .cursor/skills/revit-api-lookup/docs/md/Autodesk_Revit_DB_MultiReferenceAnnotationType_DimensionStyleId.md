---
kind: property
id: P:Autodesk.Revit.DB.MultiReferenceAnnotationType.DimensionStyleId
source: html/2849b4f5-70fd-747b-e31c-d286ee518645.htm
---
# Autodesk.Revit.DB.MultiReferenceAnnotationType.DimensionStyleId Property

The dimension style which will be used by the child dimension of the multi-reference annotation.

## Syntax (C#)
```csharp
public ElementId DimensionStyleId { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The dimension style is not allowed.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

