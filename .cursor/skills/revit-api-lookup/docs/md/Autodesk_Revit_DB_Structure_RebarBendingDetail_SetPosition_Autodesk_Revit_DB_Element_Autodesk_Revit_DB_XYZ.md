---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarBendingDetail.SetPosition(Autodesk.Revit.DB.Element,Autodesk.Revit.DB.XYZ)
source: html/8bcc31d2-6052-8a1e-d8c7-31650bc52870.htm
---
# Autodesk.Revit.DB.Structure.RebarBendingDetail.SetPosition Method

Sets the position for this bending detail relative to its view.

## Syntax (C#)
```csharp
public static void SetPosition(
	Element bendingDetail,
	XYZ position
)
```

## Parameters
- **bendingDetail** (`Autodesk.Revit.DB.Element`) - The bending detail for which we want to get the position.
- **position** (`Autodesk.Revit.DB.XYZ`) - The new position for this bending detail relative to its view.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

