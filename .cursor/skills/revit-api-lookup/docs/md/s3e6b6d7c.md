---
kind: method
id: M:Autodesk.Revit.DB.DirectShapeType.AddReferencePlane(Autodesk.Revit.DB.Plane,Autodesk.Revit.DB.DirectShapeReferenceOptions)
source: html/1657e034-4bde-914e-35c7-e928d81a1e77.htm
---
# Autodesk.Revit.DB.DirectShapeType.AddReferencePlane Method

Adds a reference plane to the DirectShapeType. The reference plane can either be bounded or unbounded.

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
- **Autodesk.Revit.Exceptions.ArgumentException** - options cannot be used to add a reference object to this DirectShapeType.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

