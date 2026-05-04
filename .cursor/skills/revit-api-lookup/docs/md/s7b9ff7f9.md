---
kind: method
id: M:Autodesk.Revit.DB.DirectShape.IsValidReferencePlaneBoundingBoxUV(Autodesk.Revit.DB.BoundingBoxUV)
source: html/fa8aa1c6-5bf2-ee0f-c264-509e53ac05b2.htm
---
# Autodesk.Revit.DB.DirectShape.IsValidReferencePlaneBoundingBoxUV Method

Validates that the input BoundingBoxUV is suitable for bounding a reference plane surface.
 The input BoundingBoxUV must be set and not degenerate.

## Syntax (C#)
```csharp
public static bool IsValidReferencePlaneBoundingBoxUV(
	BoundingBoxUV boundingBoxUV
)
```

## Parameters
- **boundingBoxUV** (`Autodesk.Revit.DB.BoundingBoxUV`) - The reference plane BoundingBoxUV to test.

## Returns
True if the input BoundingBoxUV is valid for reference plane surfaces, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

