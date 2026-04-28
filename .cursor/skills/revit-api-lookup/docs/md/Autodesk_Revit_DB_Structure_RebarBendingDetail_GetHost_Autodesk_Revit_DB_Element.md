---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarBendingDetail.GetHost(Autodesk.Revit.DB.Element)
source: html/cd41fb18-2cb7-83a4-bb6c-9146665425f2.htm
---
# Autodesk.Revit.DB.Structure.RebarBendingDetail.GetHost Method

Gets a reference to the reinforcement element that this bending detail represent.

## Syntax (C#)
```csharp
public static Reference GetHost(
	Element bendingDetail
)
```

## Parameters
- **bendingDetail** (`Autodesk.Revit.DB.Element`) - The bending detail for which we want to get the host.

## Returns
Returns a reference pointing to the reinforcement element represented by the input bending detail.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

