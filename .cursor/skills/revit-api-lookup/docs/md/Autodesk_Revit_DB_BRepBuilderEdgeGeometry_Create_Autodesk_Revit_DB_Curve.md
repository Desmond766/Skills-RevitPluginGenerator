---
kind: method
id: M:Autodesk.Revit.DB.BRepBuilderEdgeGeometry.Create(Autodesk.Revit.DB.Curve)
zh: 创建、新建、生成、建立、新增
source: html/da8be410-f630-3384-e203-32b81cd0e90c.htm
---
# Autodesk.Revit.DB.BRepBuilderEdgeGeometry.Create Method

**中文**: 创建、新建、生成、建立、新增

Construct BRepBuilderEdgeGeometry based on any GCurve, including GLine and GArc.
 The curve will be simplified if possible, and the concrete type of the returned value will reflect
 that simplification: BRepBuilderLinearEdgeGeometry if the curve could be simplified to a line,
 BRepBuilderArcEdgeGeometry if it could be simplified to an arc, BRepBuilderGenericCurveEdgeGeometry
 otherwise.

## Syntax (C#)
```csharp
public static BRepBuilderEdgeGeometry Create(
	Curve curve
)
```

## Parameters
- **curve** (`Autodesk.Revit.DB.Curve`) - The 3D curve for this edge. This BRepBuilderEdgeGeometry stores a copy of the input curve.
 The use of isCurveOpenOrShort as a validator instead of isCurveOpen is a compromise to allow
 the creation of geometry that is normally considered unacceptable due to edges that are shorter
 than Revit allows.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input curve is not bound.
 -or-
 The curve is degenerate (its length is too close to zero).
 -or-
 The endpoints of the curve are close enough that Revit considers it a closed curve.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

