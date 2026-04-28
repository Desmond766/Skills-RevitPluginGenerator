---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarConstraint.Create(Autodesk.Revit.DB.Structure.RebarConstrainedHandle,System.Collections.Generic.IList{Autodesk.Revit.DB.Reference},System.Boolean,System.Double)
zh: 创建、新建、生成、建立、新增
source: html/dc2653ae-633a-a9ed-bf08-253c59e5bfd4.htm
---
# Autodesk.Revit.DB.Structure.RebarConstraint.Create Method

**中文**: 创建、新建、生成、建立、新增

This method creates a constraint for a given Rebar Constrained Handle Tag.
 Will throw exception if used for Shape Driven Rebar.

## Syntax (C#)
```csharp
public static RebarConstraint Create(
	RebarConstrainedHandle handle,
	IList<Reference> targetReferences,
	bool isConstraintToCover,
	double offsetValue
)
```

## Parameters
- **handle** (`Autodesk.Revit.DB.Structure.RebarConstrainedHandle`) - The handle of the rebar that will be constrained.
- **targetReferences** (`System.Collections.Generic.IList < Reference >`) - The references to which the rebar handle will be constrained.
 This collection must contain one or more references to faces of elements that can host rebar.
- **isConstraintToCover** (`System.Boolean`) - If true the RebarConstraintType will be set to ToCover, otherwise RebarConstraintType will be set to FixedDistanceToHostFace.
- **offsetValue** (`System.Double`) - The distance from references to the rebar handle.

## Returns
Returns the newly created RebarConstraint.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Constrained rebar is a shape driven rebar element.
 -or-
 handle is no longer valid.
 -or-
 targetReferences is empty.
 -or-
 targetReferences do not represent faces from structurals that can host rebar.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

