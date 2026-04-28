---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarBendingDetail.SetHost(Autodesk.Revit.DB.Element,Autodesk.Revit.DB.Reference)
source: html/6cad3b9f-43d0-e005-1161-21ba22705d99.htm
---
# Autodesk.Revit.DB.Structure.RebarBendingDetail.SetHost Method

Sets the reinforcement element that will be represented by the input bending detail.

## Syntax (C#)
```csharp
public static void SetHost(
	Element bendingDetail,
	Reference reference
)
```

## Parameters
- **bendingDetail** (`Autodesk.Revit.DB.Element`) - The bending detail for which we want to set the host.
- **reference** (`Autodesk.Revit.DB.Reference`) - Reference pointing to the reinforcement element that will be represented by the input bending detail.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

