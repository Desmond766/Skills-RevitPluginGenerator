---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarBendingDetail.GetRotation(Autodesk.Revit.DB.Element)
source: html/d69182dd-a423-c07d-9c37-ed91385251f3.htm
---
# Autodesk.Revit.DB.Structure.RebarBendingDetail.GetRotation Method

Gets the rotation angle in radians for the bending detail relative to its view.

## Syntax (C#)
```csharp
public static double GetRotation(
	Element bendingDetail
)
```

## Parameters
- **bendingDetail** (`Autodesk.Revit.DB.Element`) - The bending detail for which we want to get the rotation.

## Returns
Returns the rotation angle in radians for the bending detail relative to its view.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

