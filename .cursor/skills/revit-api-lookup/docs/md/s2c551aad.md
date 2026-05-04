---
kind: method
id: M:Autodesk.Revit.DB.DirectShape.SetShape(Autodesk.Revit.DB.ShapeBuilder)
source: html/6196577c-91d1-a8b2-8937-1fa75e40200b.htm
---
# Autodesk.Revit.DB.DirectShape.SetShape Method

Sets the shape of this object to the one accumulated in the supplied Builder object.
 If the new shape is identical to the old one, the old shape will be kept.

## Syntax (C#)
```csharp
public void SetShape(
	ShapeBuilder pBuilder
)
```

## Parameters
- **pBuilder** (`Autodesk.Revit.DB.ShapeBuilder`) - A ShapeBuilder object that was used to successfully build geometry to store in this DirectShape.
 The built shape will be transferred to the DirectShape, and the ShapeBuilder object will be reset.

## Remarks
This function will bypass extra geometry validation because the built geometry has already been validated by the ShapeBuilder.
 It is therefore slightly more efficient than the SetShape() routine that accepts GeometryObjects directly as input.
 Supplying a ViewShapeBuilder object as argument will cause the view-specific shape of this DirectShape to be updated.
 Supplying other ShapeBuilder types will update the model shape.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

