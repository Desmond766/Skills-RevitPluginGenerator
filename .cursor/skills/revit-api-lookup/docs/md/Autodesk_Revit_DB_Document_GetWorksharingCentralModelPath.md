---
kind: method
id: M:Autodesk.Revit.DB.Document.GetWorksharingCentralModelPath
zh: 文档、文件
source: html/6d42ee05-5738-8685-2165-57f9809f3161.htm
---
# Autodesk.Revit.DB.Document.GetWorksharingCentralModelPath Method

**中文**: 文档、文件

Gets the central model path of the worksharing model.

## Syntax (C#)
```csharp
public ModelPath GetWorksharingCentralModelPath()
```

## Returns
The central model path, or null if the document is not workshared.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This Document is not a workshared document.

