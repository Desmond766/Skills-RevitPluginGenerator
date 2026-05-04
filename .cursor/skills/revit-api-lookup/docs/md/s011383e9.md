---
kind: method
id: M:Autodesk.Revit.Creation.Document.NewAreas(System.Collections.Generic.List{Autodesk.Revit.Creation.AreaCreationData})
zh: 文档、文件
source: html/2db91e82-ef02-6193-7872-ec64884d437e.htm
---
# Autodesk.Revit.Creation.Document.NewAreas Method

**中文**: 文档、文件

Creates new areas

## Syntax (C#)
```csharp
public ElementSet NewAreas(
	List<AreaCreationData> dataList
)
```

## Parameters
- **dataList** (`System.Collections.Generic.List < AreaCreationData >`) - A list of AreaCreationData which wraps the creation arguments of the areas to be created.

## Returns
If successful an Element Set which contains the areas should be returned, otherwise the exception will be thrown.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - If AreaCreationData's areaPoint is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.InvalidOperationException** - If the area cannot be created successfully or the phase is invalid or regeneration fails at the end of the batch creation.

