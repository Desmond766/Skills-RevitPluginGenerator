---
kind: method
id: M:Autodesk.Revit.DB.Frame.CanDefineRevitGeometry(Autodesk.Revit.DB.Frame)
source: html/49a621dd-b76c-d0b2-7850-a846a14edbfe.htm
---
# Autodesk.Revit.DB.Frame.CanDefineRevitGeometry Method

Tests whether the supplied Frame object may be used to define a Revit curve or surface.
 In order to satisfy the requirements the Frame must be orthonormal
 and its origin is expected to lie within the Revit design limits IsWithinLengthLimits(XYZ) .

## Syntax (C#)
```csharp
public static bool CanDefineRevitGeometry(
	Frame frameOfReference
)
```

## Parameters
- **frameOfReference** (`Autodesk.Revit.DB.Frame`) - Frame to be validated.

## Returns
True if this Frame may be used as a local frame of reference, false otherwise.

## Remarks
Certain Revit curve and surface types are defined using a local frame of reference.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

