---
kind: method
id: M:Autodesk.Revit.DB.Architecture.Gutter.AddSegment(Autodesk.Revit.DB.Reference)
source: html/054a62e2-bd80-6a12-030c-16df798197f0.htm
---
# Autodesk.Revit.DB.Architecture.Gutter.AddSegment Method

Add segments to the gutter.

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
 1. Input targetRef is null.
 2. Input targetRef is not null but contains nothing.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This exception will be thrown in following cases:
 1. Input targetRef has already been added into the gutter.
 2. Internal code fails to create the segment object.
 3. Regeneration fails.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - This exception will be thrown if the reference is not suitable for creating a gutter as required.
The reference allowed is :
 1. Model Line
2. Roof's horizontal edges
3. Soffit's horizontal edges
4. Fascia's horizontal edges

