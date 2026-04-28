---
kind: method
id: M:Autodesk.Revit.DB.Electrical.PanelScheduleSheetInstance.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.View)
zh: 创建、新建、生成、建立、新增
source: html/fbf7861e-0b5e-3c66-56e1-87a18a28858b.htm
---
# Autodesk.Revit.DB.Electrical.PanelScheduleSheetInstance.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new instance of panel schedule on sheet and adds it to the document.

## Syntax (C#)
```csharp
public static PanelScheduleSheetInstance Create(
	Document ADoc,
	ElementId scheduleId,
	View DBView
)
```

## Parameters
- **ADoc** (`Autodesk.Revit.DB.Document`)
- **scheduleId** (`Autodesk.Revit.DB.ElementId`)
- **DBView** (`Autodesk.Revit.DB.View`)

## Returns
The newly created panel schedule sheet instance element.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

