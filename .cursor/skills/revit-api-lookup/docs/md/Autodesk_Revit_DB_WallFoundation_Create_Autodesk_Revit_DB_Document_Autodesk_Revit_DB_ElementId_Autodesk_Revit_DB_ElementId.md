---
kind: method
id: M:Autodesk.Revit.DB.WallFoundation.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
zh: 创建、新建、生成、建立、新增
source: html/d5c7ab19-d10f-36e9-6aa2-581a28a55cb5.htm
---
# Autodesk.Revit.DB.WallFoundation.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new wall foundation within the project.

## Syntax (C#)
```csharp
public static WallFoundation Create(
	Document document,
	ElementId typeId,
	ElementId wallId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **typeId** (`Autodesk.Revit.DB.ElementId`) - The id of the wall foundation type of the newly created wall foundation.
- **wallId** (`Autodesk.Revit.DB.ElementId`) - The id of the host wall of the newly created wall foundation.

## Returns
If successful, returns the newly created wall foundation, Nothing nullptr a null reference ( Nothing in Visual Basic) otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - typeId is not a valid WallFoundationType id.
 -or-
 wallId does not refer to a valid wall.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

