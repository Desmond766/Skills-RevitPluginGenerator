---
kind: method
id: M:Autodesk.Revit.DB.Document.GetSubelement(Autodesk.Revit.DB.Reference)
zh: 文档、文件
source: html/3dbd4eab-664f-0048-13a9-959c27fce729.htm
---
# Autodesk.Revit.DB.Document.GetSubelement Method

**中文**: 文档、文件

Gets the subelement referenced by the input reference.

## Syntax (C#)
```csharp
public Subelement GetSubelement(
	Reference reference
)
```

## Parameters
- **reference** (`Autodesk.Revit.DB.Reference`) - The reference that identifies element or subelement.

## Returns
The subelement referenced by the input argument.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - reference does not identify a valid element or subelement.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

