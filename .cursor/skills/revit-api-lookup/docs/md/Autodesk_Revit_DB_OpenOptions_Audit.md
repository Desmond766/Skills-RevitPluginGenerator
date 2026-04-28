---
kind: property
id: P:Autodesk.Revit.DB.OpenOptions.Audit
zh: 检查、审查、校验
source: html/61fd9502-777d-a946-aead-24974c8ac3f2.htm
---
# Autodesk.Revit.DB.OpenOptions.Audit Property

**中文**: 检查、审查、校验

Specifies whether to expand all elements in order to check for corruption.

## Syntax (C#)
```csharp
public bool Audit { get; set; }
```

## Remarks
The default is false. Setting this to true will increase the time and memory required to open the file.

