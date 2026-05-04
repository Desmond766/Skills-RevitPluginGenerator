---
kind: method
id: M:Autodesk.Revit.DB.Document.GetWorksetId(Autodesk.Revit.DB.ElementId)
zh: 文档、文件
source: html/a8a13d95-549e-dffd-5ffe-8cef809c703b.htm
---
# Autodesk.Revit.DB.Document.GetWorksetId Method

**中文**: 文档、文件

Get Id of the Workset which owns the element.

## Syntax (C#)
```csharp
public WorksetId GetWorksetId(
	ElementId id
)
```

## Parameters
- **id** (`Autodesk.Revit.DB.ElementId`) - Id of the element.

## Returns
Id of the Workset which owns the element.

## Remarks
Each element belongs to one and only one workset.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

