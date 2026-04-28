---
kind: property
id: P:Autodesk.Revit.DB.Element.Document
zh: 文档、文件
source: html/9e530d25-61ca-3899-a531-cbcfd994358d.htm
---
# Autodesk.Revit.DB.Element.Document Property

**中文**: 文档、文件

Returns the Document in which the Element resides.

## Syntax (C#)
```csharp
public Document Document { get; }
```

## Remarks
All elements are contained within a document. An element can be retrieved from this
document by using the id that is returned by the element's id property.

