---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarBendingDetail.SetRotation(Autodesk.Revit.DB.Element,System.Double)
source: html/8f892d80-8339-5815-a6d0-23c51cde3e98.htm
---
# Autodesk.Revit.DB.Structure.RebarBendingDetail.SetRotation Method

Sets the rotation angle in radians for the bending detail relative to its view.

## Syntax (C#)
```csharp
public static void SetRotation(
	Element bendingDetail,
	double rotation
)
```

## Parameters
- **bendingDetail** (`Autodesk.Revit.DB.Element`) - The bending detail for which we want to get the rotation.
- **rotation** (`System.Double`) - The new rotation angle of the bending detail relative to its view.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - -or-
 The given value for rotation is not a number
 -or-
 The given value for rotation is not finite
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

