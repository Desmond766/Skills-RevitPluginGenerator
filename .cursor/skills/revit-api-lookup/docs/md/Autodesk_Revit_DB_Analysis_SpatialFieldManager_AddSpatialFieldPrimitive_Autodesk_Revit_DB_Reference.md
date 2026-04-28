---
kind: method
id: M:Autodesk.Revit.DB.Analysis.SpatialFieldManager.AddSpatialFieldPrimitive(Autodesk.Revit.DB.Reference)
source: html/8c45a315-8d28-7a02-f4e9-7e524ae05832.htm
---
# Autodesk.Revit.DB.Analysis.SpatialFieldManager.AddSpatialFieldPrimitive Method

Creates an empty analysis results primitive associated with a reference.

## Syntax (C#)
```csharp
public int AddSpatialFieldPrimitive(
	Reference reference
)
```

## Parameters
- **reference** (`Autodesk.Revit.DB.Reference`) - Reference pointing to the curve or face to be associated with the primitive

## Returns
Unique index of primitive for future references

## Remarks
There can be multiple primitives associated with one reference, normally they would be shown with different results.
 However this is justified only if they have different sets of domain points.
 Otherwise one primitive can be used to display values for different results.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - reference points to neither face nor curve
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

