---
kind: method
id: M:Autodesk.Revit.DB.Analysis.SpatialFieldManager.AddSpatialFieldPrimitive(Autodesk.Revit.DB.Face,Autodesk.Revit.DB.Transform)
source: html/df9a1bc5-a719-e714-1ecd-0d88d6216000.htm
---
# Autodesk.Revit.DB.Analysis.SpatialFieldManager.AddSpatialFieldPrimitive Method

Creates empty analysis results primitive associated with a face and a transform.

## Syntax (C#)
```csharp
public int AddSpatialFieldPrimitive(
	Face face,
	Transform trf
)
```

## Parameters
- **face** (`Autodesk.Revit.DB.Face`) - Face to be associated with the primitive
- **trf** (`Autodesk.Revit.DB.Transform`) - Conformal Transform to be applied to %face%

## Returns
Unique index of primitive for future references

## Remarks
This method accepts a reference to a model face, and a transform to be applied to
 that face, allowing the display of analytical results on faces which are not
 strictly a part of the Revit model. This method should not be used if the transform is the identity transform,
 i.e. the intent is to display results on a face which is part of the Revit model.
 In that case, use the overload of this method which accepts
 a reference. If the input face is from the geometry of a symbol, the face will be considered to be
 in the location specified by its symbol geometry. If your intention is to transform the face
 relative to its location in the instance, your input transform must consist of the instance's
 transform left multiplied by the extra transform to get the results you expect.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - trf is not conformal.

