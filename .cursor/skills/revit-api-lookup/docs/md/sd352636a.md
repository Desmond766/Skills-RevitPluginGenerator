---
kind: type
id: T:Autodesk.Revit.Creation.Document
zh: 文档、文件
source: html/ab1718f9-45fb-b3d3-827e-32ff81cf929c.htm
---
# Autodesk.Revit.Creation.Document

**中文**: 文档、文件

The Document Creation object is used to create new instances of elements within the
Autodesk Revit project.

## Syntax (C#)
```csharp
public class Document : ItemFactoryBase
```

## Remarks
The Document Creation object is a utility object that is used to create new
instances of elements within the Autodesk Revit project. This object, available from the
Document.Create property should be used to create elements instead of using New. This
object ensures that the elements created are added to the document correctly.

