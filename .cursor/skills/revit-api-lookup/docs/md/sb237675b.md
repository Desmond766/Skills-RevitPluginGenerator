---
kind: property
id: P:Autodesk.Revit.DB.DirectShapeOptions.ReferencingOption
source: html/623482d5-61b3-9477-343c-42c8cf3649f8.htm
---
# Autodesk.Revit.DB.DirectShapeOptions.ReferencingOption Property

Whether or not the geometry stored in a DirectShape object may be referenced.

## Syntax (C#)
```csharp
public DirectShapeReferencingOption ReferencingOption { get; set; }
```

## Remarks
If the geometry is not referenceable, it may not be used for dimensioning, snapping, alignment, or face-hosting.
 The element may still be selected by the user for operations which do not reference individual geometry objects.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration

