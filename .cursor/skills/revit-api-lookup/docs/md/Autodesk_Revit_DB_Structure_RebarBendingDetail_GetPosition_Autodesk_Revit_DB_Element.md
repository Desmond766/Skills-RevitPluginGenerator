---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarBendingDetail.GetPosition(Autodesk.Revit.DB.Element)
source: html/c892be43-5a22-f8ea-5c11-39b19224f3b5.htm
---
# Autodesk.Revit.DB.Structure.RebarBendingDetail.GetPosition Method

Gets the position of the bending detail relative to its view.

## Syntax (C#)
```csharp
public static XYZ GetPosition(
	Element bendingDetail
)
```

## Parameters
- **bendingDetail** (`Autodesk.Revit.DB.Element`) - The bending detail for which we want to get the position.

## Returns
Returns the position of the bending detail relative to its view.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

