---
kind: method
id: M:Autodesk.Revit.DB.SlabEdge.AddSegment(Autodesk.Revit.DB.Reference)
source: html/3da4c84c-9a77-2996-99cf-040e057abbcd.htm
---
# Autodesk.Revit.DB.SlabEdge.AddSegment Method

Add segments to the slab edge.

## Syntax (C#)
```csharp
public override void AddSegment(
	Reference targetRef
)
```

## Parameters
- **targetRef** (`Autodesk.Revit.DB.Reference`) - Segment's reference on which want to be added.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - This exception will be thrown in following cases:
 1. Input targetRef is Nothing nullptr a null reference ( Nothing in Visual Basic) .
 2. Input targetRef is not Nothing nullptr a null reference ( Nothing in Visual Basic) but contains nothing.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This exception will be thrown in following cases:
 1. Input targetRef has already been added into the slab edge.
 2. Internal code fails to create the segment object.
 3. Regeneration fails.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - This exception will be thrown if the reference is suitable for creating a slab edge as required.
The reference allowed is :
 1. Model Line
2. Floor's horizontal edges
3. Other slab edge's horizontal edges

