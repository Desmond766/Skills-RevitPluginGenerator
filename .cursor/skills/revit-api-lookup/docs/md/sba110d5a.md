---
kind: method
id: M:Autodesk.Revit.DB.Electrical.PanelScheduleTemplate.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Electrical.PanelScheduleType,Autodesk.Revit.DB.Electrical.PanelConfiguration,System.String)
zh: 创建、新建、生成、建立、新增
source: html/e8890707-6930-e739-1f09-8690885410de.htm
---
# Autodesk.Revit.DB.Electrical.PanelScheduleTemplate.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new instance of a panel schedule template.

## Syntax (C#)
```csharp
public static PanelScheduleTemplate Create(
	Document document,
	PanelScheduleType type,
	PanelConfiguration config,
	string strName
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document where the element will be created and added.
- **type** (`Autodesk.Revit.DB.Electrical.PanelScheduleType`) - The panel schedule type.
- **config** (`Autodesk.Revit.DB.Electrical.PanelConfiguration`) - The panel configuration type.
- **strName** (`System.String`) - The name of the panel schedule template to be created.

## Returns
The newly created panel schedule template element.

## Remarks
If the given name has already been used by existing panel schedule templates,
 a unique name will be used for the newly created template.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The type is not valid for this element.
 -or-
 The config is not valid for panel schedule type type of this template.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

