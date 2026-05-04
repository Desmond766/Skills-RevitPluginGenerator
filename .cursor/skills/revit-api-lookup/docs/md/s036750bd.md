---
kind: method
id: M:Autodesk.Revit.DB.ViewDrafting.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
zh: 创建、新建、生成、建立、新增
source: html/93dbfef8-b014-3912-124d-812c10b8ebdb.htm
---
# Autodesk.Revit.DB.ViewDrafting.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new ViewDrafting in the model.

## Syntax (C#)
```csharp
public static ViewDrafting Create(
	Document document,
	ElementId viewFamilyTypeId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document in which the new drafting view will be created.
- **viewFamilyTypeId** (`Autodesk.Revit.DB.ElementId`) - The id of the ViewFamilyType that should be assigned to the new drafting view.

## Returns
The newly created drafting view.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - viewFamilyTypeId is not a valid ViewFamilyType for a drafting view.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

