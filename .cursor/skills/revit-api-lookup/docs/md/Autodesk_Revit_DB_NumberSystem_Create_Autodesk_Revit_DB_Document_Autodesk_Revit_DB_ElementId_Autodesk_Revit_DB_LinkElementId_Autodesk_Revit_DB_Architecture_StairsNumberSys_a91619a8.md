---
kind: method
id: M:Autodesk.Revit.DB.NumberSystem.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.LinkElementId,Autodesk.Revit.DB.Architecture.StairsNumberSystemReferenceOption,Autodesk.Revit.DB.LinkElementId)
zh: 创建、新建、生成、建立、新增
source: html/9af6bd67-3f52-4b58-1807-c87d8805a7bf.htm
---
# Autodesk.Revit.DB.NumberSystem.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new instance of a NumberSystem associated to a host element, a view, and a reference level of stairs if in a multistory stairs.

## Syntax (C#)
```csharp
public static NumberSystem Create(
	Document document,
	ElementId viewId,
	LinkElementId hostElementId,
	StairsNumberSystemReferenceOption referenceOption,
	LinkElementId placementLevelId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **viewId** (`Autodesk.Revit.DB.ElementId`) - The view in which the NumberSystem will be created.
- **hostElementId** (`Autodesk.Revit.DB.LinkElementId`) - The host id on which the NumberSystem will be created.
- **referenceOption** (`Autodesk.Revit.DB.Architecture.StairsNumberSystemReferenceOption`) - The reference option of the NumberSystem.
- **placementLevelId** (`Autodesk.Revit.DB.LinkElementId`) - The id of the level on which the NumberSystem will be placed. The placement level must be one of the base levels of a stairs group members. It is suggested to
 get the level from MultistoryStairs.GetStairsPlacementLevels().

## Returns
The created NumberSystem.

## Remarks
In multistory stairs, a stairs element could be a stair group or individual stair.
 This method allows to add a NumberSystem for a run of an individual stairs or a stairs group member on the placementLevelId.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - viewId is not valid for placement of a NumberSystem (only floor plan views and elevation views are permitted).
 -or-
 hostElementId is not valid as a host for NumberSystem (only StairsRun elements are permitted in this release).
 -or-
 The reference option is not valid for a NumberSystem.
 -or-
 The placementLevelId is not one of the stairs base levels.
 -or-
 The hostElementId already has a number system.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

