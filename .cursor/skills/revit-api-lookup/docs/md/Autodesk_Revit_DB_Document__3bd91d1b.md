---
kind: type
id: T:Autodesk.Revit.DB.Document
zh: 文档、文件
source: html/db03274b-a107-aa32-9034-f3e0df4bb1ec.htm
---
# Autodesk.Revit.DB.Document

**中文**: 文档、文件

An object that represents an open Autodesk Revit project.

## Syntax (C#)
```csharp
public class Document : IDisposable
```

## Remarks
The Document object represents an Autodesk Revit project. Revit can have multiple
 projects open and multiple views to those projects. The active or top most view will be the
 active project and hence the active document which is available from the Application object.

