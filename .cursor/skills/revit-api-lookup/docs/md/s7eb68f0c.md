---
kind: method
id: M:Autodesk.Revit.DB.DirectShapeType.IsValidReferencePlaneBoundingBoxUV(Autodesk.Revit.DB.BoundingBoxUV)
source: html/22b216a0-6212-1379-1cc7-2656b395feca.htm
---
# Autodesk.Revit.DB.DirectShapeType.IsValidReferencePlaneBoundingBoxUV Method

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

