---
kind: method
id: M:Autodesk.Revit.DB.DirectShapeType.CanCreateParts
source: html/31cfdb04-e1ce-5859-0479-86acabc06d4a.htm
---
# Autodesk.Revit.DB.DirectShapeType.CanCreateParts Method

Indicates if it is possible to create parts from this DirectShapeType element.

## Syntax (C#)
```csharp
public bool CanCreateParts()
```

## Returns
True if it is possible to create parts from this DirectShapeType.

## Remarks
While it is generally possible to create parts from DirectShape elements, some characteristics make parts creation impossible.
 This property is re-evaluated every time the DirectShapeType's geometry is modified (via a call to SetShape or AppendShape).
 Invalid configurations include: DirectShapeTypes containing a polymesh, or an open geometry, as well as DirectShapeTypes
 not containing any solids and DirectShapeTypes configured as NotReferenceable (via a call to SetOptions).
 Finally, if a DirectShapeType has other DirectShapeType instances in its geometry, and one of those other DirectShapeTypes
 has a configuration that is incompatible with parts creation, the host DirectShapeType will also be incompatible
 with parts creation.

