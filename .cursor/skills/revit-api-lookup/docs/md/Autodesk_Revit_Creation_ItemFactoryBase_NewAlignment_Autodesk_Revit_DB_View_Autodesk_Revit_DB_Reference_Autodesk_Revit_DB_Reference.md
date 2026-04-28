---
kind: method
id: M:Autodesk.Revit.Creation.ItemFactoryBase.NewAlignment(Autodesk.Revit.DB.View,Autodesk.Revit.DB.Reference,Autodesk.Revit.DB.Reference)
source: html/b3c10008-aba6-9eee-99c9-7e05ace75796.htm
---
# Autodesk.Revit.Creation.ItemFactoryBase.NewAlignment Method

Add a new locked alignment into the Autodesk Revit document.

## Syntax (C#)
```csharp
public Dimension NewAlignment(
	View view,
	Reference reference1,
	Reference reference2
)
```

## Parameters
- **view** (`Autodesk.Revit.DB.View`) - The view that determines the orientation of the alignment.
- **reference1** (`Autodesk.Revit.DB.Reference`) - The first reference.
- **reference2** (`Autodesk.Revit.DB.Reference`) - The second reference.

## Returns
If creation was successful the new locked alignment dimension is returned, 
otherwise an exception with failure information will be thrown.

## Remarks
These two references must be one of the following combinations:
 2 planar faces planar face and reference plane 2 lines line and point line and reference plane 2 arcs 2 cylindrical faces 
These references must be already geometrically aligned (this function will
not force them to become aligned).

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input argument-"view" or "headerReference" or "otherReference"-is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the input argument-"headerReference" or "otherReference"-is invalid.

