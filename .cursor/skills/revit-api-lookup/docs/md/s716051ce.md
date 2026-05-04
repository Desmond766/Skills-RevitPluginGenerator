---
kind: method
id: M:Autodesk.Revit.DB.IFC.ExporterIFCUtils.GetAttachedColumns(Autodesk.Revit.DB.Wall)
source: html/d377b274-2327-08f8-8dad-859ff541903a.htm
---
# Autodesk.Revit.DB.IFC.ExporterIFCUtils.GetAttachedColumns Method

Obtains a list of columns known to Revit as intersecting with this wall.

## Syntax (C#)
```csharp
public static IList<FamilyInstance> GetAttachedColumns(
	Wall pWallElem
)
```

## Parameters
- **pWallElem** (`Autodesk.Revit.DB.Wall`) - The wall.

## Returns
The columns found.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

