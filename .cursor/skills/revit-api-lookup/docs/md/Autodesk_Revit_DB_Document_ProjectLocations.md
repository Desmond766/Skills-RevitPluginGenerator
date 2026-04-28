---
kind: property
id: P:Autodesk.Revit.DB.Document.ProjectLocations
zh: 文档、文件
source: html/87be3885-b1aa-ba8c-f82e-a5a0f7455c3a.htm
---
# Autodesk.Revit.DB.Document.ProjectLocations Property

**中文**: 文档、文件

Retrieve all the project locations associated with this project

## Syntax (C#)
```csharp
public ProjectLocationSet ProjectLocations { get; }
```

## Remarks
This property returns all the locations of the project. A project can have one
site location but many project locations within that site. Each project location object
is an offset and rotation from the site location.

