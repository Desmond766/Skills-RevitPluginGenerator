---
kind: method
id: M:Autodesk.Revit.DB.FabricationRodInfo.SetRodEndPosition(System.Int32,Autodesk.Revit.DB.XYZ)
source: html/acb96d05-ad50-8da4-215d-0417fe015fcb.htm
---
# Autodesk.Revit.DB.FabricationRodInfo.SetRodEndPosition Method

Sets the position of the rod end. The method is applicable only for bearer hanger.

## Syntax (C#)
```csharp
public void SetRodEndPosition(
	int rodIndex,
	XYZ position
)
```

## Parameters
- **rodIndex** (`System.Int32`) - The index of the rod.
- **position** (`Autodesk.Revit.DB.XYZ`) - The position of the rod end.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Invalid rod position.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - the index rodIndex is should be in range of rod count.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The hanger is not a bearer hanger.

