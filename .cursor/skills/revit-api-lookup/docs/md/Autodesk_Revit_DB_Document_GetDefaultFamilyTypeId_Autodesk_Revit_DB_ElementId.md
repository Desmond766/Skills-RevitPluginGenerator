---
kind: method
id: M:Autodesk.Revit.DB.Document.GetDefaultFamilyTypeId(Autodesk.Revit.DB.ElementId)
zh: 文档、文件
source: html/34d20683-dfea-b1f8-14cf-750611b218ed.htm
---
# Autodesk.Revit.DB.Document.GetDefaultFamilyTypeId Method

**中文**: 文档、文件

Gets the default family type id with the given family category id.

## Syntax (C#)
```csharp
public ElementId GetDefaultFamilyTypeId(
	ElementId familyCategoryId
)
```

## Parameters
- **familyCategoryId** (`Autodesk.Revit.DB.ElementId`) - The family category id.

## Returns
The default family type id.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

