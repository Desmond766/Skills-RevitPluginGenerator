---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarBendingDetail.IsBendingDetail(Autodesk.Revit.DB.Element)
source: html/58afee1c-e3ea-a6e2-15b9-488559308bef.htm
---
# Autodesk.Revit.DB.Structure.RebarBendingDetail.IsBendingDetail Method

Checks if the input element is a bending detail.

## Syntax (C#)
```csharp
public static bool IsBendingDetail(
	Element bendingDetail
)
```

## Parameters
- **bendingDetail** (`Autodesk.Revit.DB.Element`) - The element that will be checked.

## Returns
Returns true if the input element is a bending detail, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The bendingDetail should be a bending detail.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

