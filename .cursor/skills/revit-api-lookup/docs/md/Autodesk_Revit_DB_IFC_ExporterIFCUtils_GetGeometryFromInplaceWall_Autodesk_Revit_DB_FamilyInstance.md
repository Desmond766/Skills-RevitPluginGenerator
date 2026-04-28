---
kind: method
id: M:Autodesk.Revit.DB.IFC.ExporterIFCUtils.GetGeometryFromInplaceWall(Autodesk.Revit.DB.FamilyInstance)
source: html/55de1471-1b27-1bc8-9a91-dd3c3aa50812.htm
---
# Autodesk.Revit.DB.IFC.ExporterIFCUtils.GetGeometryFromInplaceWall Method

Obtains a special snapshot of the geometry of an in-place wall element suitable for export.

## Syntax (C#)
```csharp
public static GeometryElement GetGeometryFromInplaceWall(
	FamilyInstance pFamInstWallElem
)
```

## Parameters
- **pFamInstWallElem** (`Autodesk.Revit.DB.FamilyInstance`) - The in-place wall instance.

## Returns
The in-place wall geometry. Returns Nothing nullptr a null reference ( Nothing in Visual Basic) if there is no special
 geometry for the wall needed for export; the standard geometry of the wall can be used.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

