---
kind: property
id: P:Autodesk.Revit.DB.MultiReferenceAnnotationType.TagTypeId
source: html/27b53b40-5506-9a4a-321a-cd8db9b09ceb.htm
---
# Autodesk.Revit.DB.MultiReferenceAnnotationType.TagTypeId Property

The tag type which will be used by the child tag the multi-reference annotation.

## Syntax (C#)
```csharp
public ElementId TagTypeId { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The tag type is not allowed.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

