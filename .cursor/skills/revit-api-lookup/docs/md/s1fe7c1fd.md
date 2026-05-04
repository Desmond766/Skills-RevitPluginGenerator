---
kind: method
id: M:Autodesk.Revit.DB.DirectShape.AddReferencePlane(Autodesk.Revit.DB.Plane,Autodesk.Revit.DB.BoundingBoxUV,Autodesk.Revit.DB.DirectShapeReferenceOptions)
source: html/4f235c9c-730f-dd05-4eb5-2b95166019ae.htm
---
# Autodesk.Revit.DB.DirectShape.AddReferencePlane Method

Adds a reference plane to the DirectShape. The reference plane can either be bounded or unbounded.

## Syntax (C#)
```csharp
public void AddReferencePlane(
	Plane refPlane,
	BoundingBoxUV boundingBoxUV,
	DirectShapeReferenceOptions options
)
```

## Parameters
- **refPlane** (`Autodesk.Revit.DB.Plane`) - The geometry of the new reference plane.
- **boundingBoxUV** (`Autodesk.Revit.DB.BoundingBoxUV`) - If boundingBoxUV is set, the resulting reference plane that is added to the DirectShape will be displayed
 with those bounds. Note that the specified bounds must not be degenerate.
 If boundingBoxUV is not set, reasonable bounds are automatically calculated and applied to the input plane.
 The automatic bounds are based on the host direct shape's geometry.
- **options** (`Autodesk.Revit.DB.DirectShapeReferenceOptions`) - The options that are used to configure the new reference plane.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - boundingBoxUV cannot be used as a BoundingBoxUV for the reference plane surface.
 -or-
 options cannot be used to add a reference object to this DirectShape.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

