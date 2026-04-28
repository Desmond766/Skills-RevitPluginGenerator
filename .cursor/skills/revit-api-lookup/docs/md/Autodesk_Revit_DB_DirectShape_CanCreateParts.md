---
kind: method
id: M:Autodesk.Revit.DB.DirectShape.CanCreateParts
source: html/00584d60-2960-36ab-f305-d2f4dda220f8.htm
---
# Autodesk.Revit.DB.DirectShape.CanCreateParts Method

Indicates if it is possible to create parts from this DirectShape element.

## Syntax (C#)
```csharp
public bool CanCreateParts()
```

## Returns
True if it is possible to create parts from this DirectShape.

## Remarks
While it is generally possible to create parts from DirectShape elements, some characteristics make parts creation impossible.
 This property is re-evaluated every time the element's geometry is modified (via a call to SetShape or AppendShape).
 Invalid configurations include: DirectShape elements containing a polymesh, or an open geometry, as well as DirectShape elements
 not containing any solids and DirectShape elements configured as NotReferenceable (via a call to SetOptions).
 Finally, if a DirectShape element has DirectShapeType instances in its geometry, and one of those DirectShapeTypes has a configuration
 that is incompatible with parts creation, the DirectShape element will also be incompatible with parts creation.

