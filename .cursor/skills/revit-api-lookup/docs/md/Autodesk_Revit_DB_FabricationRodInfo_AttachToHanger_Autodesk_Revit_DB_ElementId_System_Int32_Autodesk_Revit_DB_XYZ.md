---
kind: method
id: M:Autodesk.Revit.DB.FabricationRodInfo.AttachToHanger(Autodesk.Revit.DB.ElementId,System.Int32,Autodesk.Revit.DB.XYZ)
source: html/083c7ab0-9885-cd48-a8c4-3fa40d64c52b.htm
---
# Autodesk.Revit.DB.FabricationRodInfo.AttachToHanger Method

Attaches the hanger rod to another bearer hanger.

## Syntax (C#)
```csharp
public void AttachToHanger(
	ElementId hangerId,
	int rodIndex,
	XYZ position
)
```

## Parameters
- **hangerId** (`Autodesk.Revit.DB.ElementId`) - Identifier of the bearer hanger to which the rod attaches.
- **rodIndex** (`System.Int32`) - The index of the rod.
- **position** (`Autodesk.Revit.DB.XYZ`) - The position of the rod end. It should be on bearer centerline.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The hanger is not a bearer hanger.
 -or-
 The point is not on hanger bearer centerline.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - the index rodIndex is should be in range of rod count.

