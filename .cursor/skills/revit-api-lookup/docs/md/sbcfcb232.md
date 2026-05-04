---
kind: method
id: M:Autodesk.Revit.DB.IFC.ExporterIFCUtils.GetInstanceCutoutFromWall(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Wall,Autodesk.Revit.DB.FamilyInstance,Autodesk.Revit.DB.XYZ@)
source: html/07529283-96a7-8aca-5edf-906d8ddd3b7d.htm
---
# Autodesk.Revit.DB.IFC.ExporterIFCUtils.GetInstanceCutoutFromWall Method

Gets the curve loop corresponding to the hole in the wall made by the instance.

## Syntax (C#)
```csharp
public static CurveLoop GetInstanceCutoutFromWall(
	Document pADoc,
	Wall pVWall,
	FamilyInstance pFamInst,
	out XYZ pCutDir
)
```

## Parameters
- **pADoc** (`Autodesk.Revit.DB.Document`) - The document.
- **pVWall** (`Autodesk.Revit.DB.Wall`) - The host wall.
- **pFamInst** (`Autodesk.Revit.DB.FamilyInstance`) - The hosted instance.
- **pCutDir** (`Autodesk.Revit.DB.XYZ %`) - The direction of the hole relative to the location of the curve loop.

## Returns
The opening in the wall.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

