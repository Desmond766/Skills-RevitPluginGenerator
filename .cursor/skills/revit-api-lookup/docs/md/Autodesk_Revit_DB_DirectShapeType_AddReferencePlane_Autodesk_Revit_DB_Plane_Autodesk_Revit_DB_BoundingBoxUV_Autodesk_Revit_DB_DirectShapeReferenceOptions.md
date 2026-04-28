---
kind: method
id: M:Autodesk.Revit.DB.DirectShapeType.AddReferencePlane(Autodesk.Revit.DB.Plane,Autodesk.Revit.DB.BoundingBoxUV,Autodesk.Revit.DB.DirectShapeReferenceOptions)
source: html/89bc8899-38bf-f736-fb5c-f3b8ad4c281f.htm
---
# Autodesk.Revit.DB.DirectShapeType.AddReferencePlane Method

Adds a reference plane to the DirectShapeType. The reference plane can either be bounded or unbounded.

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
- **boundingBoxUV** (`Autodesk.Revit.DB.BoundingBoxUV`) - If boundingBoxUV is set, the resulting reference plane that is added to the DirectShapeType will be displayed
 with those bounds. Note that the specified bounds must not be degenerate.
 If boundingBoxUV is not set, reasonable bounds are automatically calculated and applied to the input plane.
 The automatic bounds are based on the host direct shape's geometry.
- **options** (`Autodesk.Revit.DB.DirectShapeReferenceOptions`) - The options that are used to configure the new reference plane.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - boundingBoxUV cannot be used as a BoundingBoxUV for the reference plane surface.
 -or-
 options cannot be used to add a reference object to this DirectShapeType.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

