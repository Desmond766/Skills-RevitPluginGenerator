---
kind: method
id: M:Autodesk.Revit.DB.DirectShapeType.AppendShape(Autodesk.Revit.DB.ShapeBuilder)
source: html/561c08af-0524-62b4-2df5-88eb17a221ab.htm
---
# Autodesk.Revit.DB.DirectShapeType.AppendShape Method

Append shape built by the supplied ShapeBuilderObject to shape representation stored in this DirectShapeType.
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
 will have teh correct appearance in Revit.
 This function will bypass extra geometry validation because the built geometry has already been validated by the ShapeBuilder.
 It is therefore slightly more efficient than the AppendShape() routine that accepts GeometryObjects directly as input.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

