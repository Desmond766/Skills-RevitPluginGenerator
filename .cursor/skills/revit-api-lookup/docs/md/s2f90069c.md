---
kind: method
id: M:Autodesk.Revit.DB.Architecture.Fascia.AddSegment(Autodesk.Revit.DB.Reference)
source: html/c8385a28-d05d-4553-3af4-713147e38406.htm
---
# Autodesk.Revit.DB.Architecture.Fascia.AddSegment Method

Add segments to the fascia.

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
 1. Input targetRef has already been added into the fascia.
 2. Internal code fails to create the segment object.
 3. Regeneration fails.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - This exception will be thrown if the reference is suitable for creating a fascia as required.
The reference allowed is :
 1. Model Line
2. Roof's horizontal edges
3. Soffit's horizontal edges
4. Other fascia's horizontal edges

