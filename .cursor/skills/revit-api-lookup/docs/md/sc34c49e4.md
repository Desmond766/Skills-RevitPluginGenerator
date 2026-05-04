---
kind: method
id: M:Autodesk.Revit.DB.TessellatedShapeBuilder.Build
source: html/3b67078d-f8fd-83f4-ee2e-b83e8ec23a23.htm
---
# Autodesk.Revit.DB.TessellatedShapeBuilder.Build Method

Builds the designated geometrical objects from the stored face sets. Stores the result in this TessellatedShapeBuilder object.

## Syntax (C#)
```csharp
public void Build()
```

## Remarks
The behavior of this function is affected by Target, Fallback and GStyleId properties of this TessellatedShapeBuilder object.
 Currently only "Solid/Abort", "AnyGeometry/Mesh" and
 "Mesh/Salvage" target/fallback combinations are supported.
 Note that this function does not erase the face sets stored in the builder.
 If the same builder is used to construct geometrical objects for different
 collections of face sets, ( Clear () () () ) should be called
 while switching from one collection to another.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Throws if data in the stored face sets are so inconsistent, that
 they cannot be used in their entirety, or if an attempt is made to create unacceptable geometry
 with too many facets.

