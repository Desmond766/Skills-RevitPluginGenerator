---
kind: method
id: M:Autodesk.Revit.DB.DirectShapeType.AddReferencePlane(Autodesk.Revit.DB.Plane,Autodesk.Revit.DB.BoundingBoxUV)
source: html/0861063f-2f61-cce9-9954-3f8b8606b4bb.htm
---
# Autodesk.Revit.DB.DirectShapeType.AddReferencePlane Method

Adds a reference plane to the DirectShapeType. The reference plane can either be bounded or unbounded.

## Syntax (C#)
```csharp
public void AddReferencePlane(
	Plane refPlane,
	BoundingBoxUV boundingBoxUV
)
```

## Parameters
- **refPlane** (`Autodesk.Revit.DB.Plane`) - The geometry of the new reference plane.
- **boundingBoxUV** (`Autodesk.Revit.DB.BoundingBoxUV`) - If boundingBoxUV is set, the resulting reference plane that is added to the DirectShapeType will be displayed
 with those bounds. Note that the specified bounds must not be degenerate.
 If boundingBoxUV is not set, reasonable bounds are automatically calculated and applied to the input plane.
 The automatic bounds are based on the host direct shape's geometry.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - boundingBoxUV cannot be used as a BoundingBoxUV for the reference plane surface.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

