---
kind: method
id: M:Autodesk.Revit.DB.DirectShape.AppendShape(Autodesk.Revit.DB.ShapeBuilder)
source: html/0271f20a-5245-141f-77fe-e0cc0659bf42.htm
---
# Autodesk.Revit.DB.DirectShape.AppendShape Method

Appends shape built by the supplied ShapeBuilderObject to shape representation stored in this DirectShape.
 The data stored in the supplied ShapeBuilder object will be cleared.

## Syntax (C#)
```csharp
public void AppendShape(
	ShapeBuilder ShapeBuilder
)
```

## Parameters
- **ShapeBuilder** (`Autodesk.Revit.DB.ShapeBuilder`) - The ShapeBuilder object that was used to build the shape to be appended.

## Remarks
The existing shape will not be cleared by this function, and intersecting or overlapped geometry will not be
 joined with the appended geometry. It is up to the caller to ensure that the combination of geometry
 will have the correct appearance in Revit.
 This function will bypass extra geometry validation because the built geometry has already been validated by the ShapeBuilder.
 It is therefore slightly more efficient than the AppendShape() routine that accepts GeometryObjects directly as input.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

