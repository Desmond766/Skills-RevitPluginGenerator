---
kind: method
id: M:Autodesk.Revit.DB.UV.IsAlmostEqualTo(Autodesk.Revit.DB.UV,System.Double)
source: html/bfe26827-3047-f7c4-c00d-c5ef94adc35b.htm
---
# Autodesk.Revit.DB.UV.IsAlmostEqualTo Method

Determines whether this 2-D vector and the specified 2-D vector are the same within a specified tolerance.

## Syntax (C#)
```csharp
public bool IsAlmostEqualTo(
	UV source,
	double tolerance
)
```

## Parameters
- **source** (`Autodesk.Revit.DB.UV`) - The vector to compare with this vector.
- **tolerance** (`System.Double`) - The tolerance for equality check.

## Returns
True if the vectors are the same; otherwise, false.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when source is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when tolerance is less than 0.

