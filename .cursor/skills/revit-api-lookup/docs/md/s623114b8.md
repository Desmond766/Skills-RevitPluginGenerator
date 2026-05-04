---
kind: method
id: M:Autodesk.Revit.DB.Analysis.SpatialFieldManager.AddSpatialFieldPrimitive(Autodesk.Revit.DB.Reference,Autodesk.Revit.DB.Analysis.SpatialFieldPrimitiveHideMode)
source: html/cf1ad636-45f1-1649-29b6-7dc2b6400dbb.htm
---
# Autodesk.Revit.DB.Analysis.SpatialFieldManager.AddSpatialFieldPrimitive Method

Creates an empty analysis results primitive associated with a reference, with the option to control how the reference element is hidden.

## Syntax (C#)
```csharp
public int AddSpatialFieldPrimitive(
	Reference reference,
	SpatialFieldPrimitiveHideMode hidingMode
)
```

## Parameters
- **reference** (`Autodesk.Revit.DB.Reference`) - Reference pointing to the curve or face to be associated with the primitive
- **hidingMode** (`Autodesk.Revit.DB.Analysis.SpatialFieldPrimitiveHideMode`) - The mode used to hide the original model element

## Returns
Unique index of primitive for future references

## Remarks
There can be multiple primitives associated with one reference, normally they would be shown with different results.
 However this is justified only if they have different sets of domain points.
 Otherwise one primitive can be used to display values for different results.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - reference points to neither face nor curve
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

