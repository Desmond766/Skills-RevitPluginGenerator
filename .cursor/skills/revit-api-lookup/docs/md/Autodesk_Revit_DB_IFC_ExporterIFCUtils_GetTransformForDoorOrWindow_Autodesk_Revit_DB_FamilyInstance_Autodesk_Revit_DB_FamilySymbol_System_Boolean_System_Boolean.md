---
kind: method
id: M:Autodesk.Revit.DB.IFC.ExporterIFCUtils.GetTransformForDoorOrWindow(Autodesk.Revit.DB.FamilyInstance,Autodesk.Revit.DB.FamilySymbol,System.Boolean,System.Boolean)
source: html/9c376c1a-f193-d845-ae3a-fe5029ac6012.htm
---
# Autodesk.Revit.DB.IFC.ExporterIFCUtils.GetTransformForDoorOrWindow Method

Obtains the transform for the door or window instance.

## Syntax (C#)
```csharp
public static Transform GetTransformForDoorOrWindow(
	FamilyInstance familyInstance,
	FamilySymbol familySymbol,
	bool flippedX,
	bool flippedY
)
```

## Parameters
- **familyInstance** (`Autodesk.Revit.DB.FamilyInstance`) - The family instance.
- **familySymbol** (`Autodesk.Revit.DB.FamilySymbol`) - The family symbol.
- **flippedX** (`System.Boolean`) - Is the door or window flipped in X?
- **flippedY** (`System.Boolean`) - Is the door or window flipped in Y?

## Returns
The transform.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

