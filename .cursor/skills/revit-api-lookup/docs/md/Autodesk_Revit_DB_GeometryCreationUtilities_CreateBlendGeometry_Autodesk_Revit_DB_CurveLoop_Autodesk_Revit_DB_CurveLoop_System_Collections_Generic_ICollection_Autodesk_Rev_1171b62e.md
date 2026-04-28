---
kind: method
id: M:Autodesk.Revit.DB.GeometryCreationUtilities.CreateBlendGeometry(Autodesk.Revit.DB.CurveLoop,Autodesk.Revit.DB.CurveLoop,System.Collections.Generic.ICollection{Autodesk.Revit.DB.VertexPair},Autodesk.Revit.DB.SolidOptions)
source: html/3fde87b5-d0b6-1fb2-d051-ebe0dc977e76.htm
---
# Autodesk.Revit.DB.GeometryCreationUtilities.CreateBlendGeometry Method

Creates a solid by blending two closed curve loops lying in non-coincident planes.

## Syntax (C#)
```csharp
public static Solid CreateBlendGeometry(
	CurveLoop firstLoop,
	CurveLoop secondLoop,
	ICollection<VertexPair> vertexPairs,
	SolidOptions solidOptions
)
```

## Parameters
- **firstLoop** (`Autodesk.Revit.DB.CurveLoop`) - The first curve loop. The loop must be a closed planar loop without intersections or degeneracies. No orientation conditions are imposed. The loop must be a closed planar loop without intersections or degeneracies. No orientation conditions are imposed. The loop may not contain just one closed curve - split such a loop into two or more curves beforehand.
- **secondLoop** (`Autodesk.Revit.DB.CurveLoop`) - The second curve loop, satisfying the same conditions as the first loop.
 The planes of the first and second loops must not be coincident, but they need not be parallel.
- **vertexPairs** (`System.Collections.Generic.ICollection < VertexPair >`) - This input specifies how the two profile loops should be connected.
 If null, the function chooses vertex connections that will result in a geometrically reasonable blend.
- **solidOptions** (`Autodesk.Revit.DB.SolidOptions`) - The optional information to control the properties of the Solid.

## Returns
The requested solid.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The first profile CurveLoop do not satisfy the input requirements.
 -or-
 The second profile CurveLoop do not satisfy the input requirements.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

