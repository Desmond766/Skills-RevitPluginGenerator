---
kind: method
id: M:Autodesk.Revit.DB.UV.IsAlmostEqualTo(Autodesk.Revit.DB.UV)
source: html/aeee896b-50bc-e60d-0814-f564abd400c9.htm
---
# Autodesk.Revit.DB.UV.IsAlmostEqualTo Method

Determines whether this 2-D vector and the specified 2-D vector are the same within the tolerance (1.0e-09).

## Syntax (C#)
```csharp
public bool IsAlmostEqualTo(
	UV source
)
```

## Parameters
- **source** (`Autodesk.Revit.DB.UV`) - The vector to compare with this vector.

## Returns
True if the vectors are the same; otherwise, false.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when left is Nothing nullptr a null reference ( Nothing in Visual Basic) .

