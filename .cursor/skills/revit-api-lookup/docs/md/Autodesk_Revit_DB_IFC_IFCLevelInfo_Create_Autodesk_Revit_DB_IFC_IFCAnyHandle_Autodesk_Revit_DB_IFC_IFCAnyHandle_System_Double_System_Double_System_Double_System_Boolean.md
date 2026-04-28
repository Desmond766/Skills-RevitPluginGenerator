---
kind: method
id: M:Autodesk.Revit.DB.IFC.IFCLevelInfo.Create(Autodesk.Revit.DB.IFC.IFCAnyHandle,Autodesk.Revit.DB.IFC.IFCAnyHandle,System.Double,System.Double,System.Double,System.Boolean)
zh: 创建、新建、生成、建立、新增
source: html/f2a7063f-14d7-cd49-2778-d8ef676c5259.htm
---
# Autodesk.Revit.DB.IFC.IFCLevelInfo.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates an IFCLevelInfo.

## Syntax (C#)
```csharp
public static IFCLevelInfo Create(
	IFCAnyHandle buildingStorey,
	IFCAnyHandle localPlacement,
	double height,
	double elevation,
	double scaleFactor,
	bool isPrimaryLevel
)
```

## Parameters
- **buildingStorey** (`Autodesk.Revit.DB.IFC.IFCAnyHandle`) - The building storey handle (IfcBuildingStorey).
- **localPlacement** (`Autodesk.Revit.DB.IFC.IFCAnyHandle`) - The local placement handle (IfcLocalPlacement).
- **height** (`System.Double`) - The height of the level.
- **elevation** (`System.Double`) - The elevation of the level.
- **scaleFactor** (`System.Double`) - The scale factor.
- **isPrimaryLevel** (`System.Boolean`) - True if this is primary level, false otherwise.

## Returns
The IFCLevelInfo object.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

