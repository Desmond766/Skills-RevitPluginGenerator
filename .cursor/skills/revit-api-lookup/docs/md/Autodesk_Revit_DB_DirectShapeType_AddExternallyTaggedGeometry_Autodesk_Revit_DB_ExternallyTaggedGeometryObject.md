---
kind: method
id: M:Autodesk.Revit.DB.DirectShapeType.AddExternallyTaggedGeometry(Autodesk.Revit.DB.ExternallyTaggedGeometryObject)
source: html/39c80387-f1ef-b57c-67d1-0231d0ec5068.htm
---
# Autodesk.Revit.DB.DirectShapeType.AddExternallyTaggedGeometry Method

Adds the externally tagged geometry object to the DirectShapeType.

## Syntax (C#)
```csharp
public void AddExternallyTaggedGeometry(
	ExternallyTaggedGeometryObject externallyTaggedGeometry
)
```

## Parameters
- **externallyTaggedGeometry** (`Autodesk.Revit.DB.ExternallyTaggedGeometryObject`) - The externally tagged geometry that should be added to the DirectShapeType.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input shape does not satisfy DirectShapeType validation criteria.
 -or-
 The input geometry does not have a permitted usage.
 -or-
 The externallyTaggedGeometry has already been added to this DirectShapeType.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

