---
kind: method
id: M:Autodesk.Revit.DB.Analysis.SpatialFieldManager.AddSpatialFieldPrimitive(Autodesk.Revit.DB.Curve,Autodesk.Revit.DB.Transform)
source: html/5cbf5a07-7043-e8b3-def5-6ea4380c22a9.htm
---
# Autodesk.Revit.DB.Analysis.SpatialFieldManager.AddSpatialFieldPrimitive Method

Creates empty analysis results primitive associated with a curve and a transform.

## Syntax (C#)
```csharp
public int AddSpatialFieldPrimitive(
	Curve curve,
	Transform trf
)
```

## Parameters
- **curve** (`Autodesk.Revit.DB.Curve`) - Curve to be associated with the primitive.
 %curve% does NOT correspond to actual Revit geometry, i.e. it cannot be associated with reference;
 otherwise the other overload of the method must be used (taking "reference" as the input)
- **trf** (`Autodesk.Revit.DB.Transform`) - Conformal Transform to be applied to %curve%.

## Returns
Unique index of primitive for future references

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input curve points to a helical curve and is not supported for this operation.
 -or-
 Argument trf is not a conformal transform (see property Revit::DB::Transform::IsConformal)
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

