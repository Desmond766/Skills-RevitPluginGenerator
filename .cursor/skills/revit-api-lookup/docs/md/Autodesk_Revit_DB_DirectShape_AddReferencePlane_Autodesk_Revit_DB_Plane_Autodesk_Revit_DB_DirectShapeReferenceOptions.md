---
kind: method
id: M:Autodesk.Revit.DB.DirectShape.AddReferencePlane(Autodesk.Revit.DB.Plane,Autodesk.Revit.DB.DirectShapeReferenceOptions)
source: html/436a9374-049e-d2df-df83-d0a6c22aa7b6.htm
---
# Autodesk.Revit.DB.DirectShape.AddReferencePlane Method

Adds a reference plane to the DirectShape. The reference plane can either be bounded or unbounded.

## Syntax (C#)
```csharp
public void AddReferencePlane(
	Plane refPlane,
	DirectShapeReferenceOptions options
)
```

## Parameters
- **refPlane** (`Autodesk.Revit.DB.Plane`) - The geometry of the new reference plane.
- **options** (`Autodesk.Revit.DB.DirectShapeReferenceOptions`) - The options that are used to configure the new reference plane.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - options cannot be used to add a reference object to this DirectShape.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

