---
kind: method
id: M:Autodesk.Revit.DB.Revision.Create(Autodesk.Revit.DB.Document)
zh: 创建、新建、生成、建立、新增
source: html/c51bd862-ded1-f5cc-0c5e-44554e145e39.htm
---
# Autodesk.Revit.DB.Revision.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new Revision in the project.

## Syntax (C#)
```csharp
public static Revision Create(
	Document document
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document of the new Revision.

## Returns
The newly created Revision.

## Remarks
The new Revision will be added at the end of the sequence of existing Revisions.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - document is not a project document.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

