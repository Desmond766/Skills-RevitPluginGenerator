---
kind: property
id: P:Autodesk.Revit.DB.Parameter.Definition
zh: 参数、共享参数
source: html/dc30c65f-cfc4-244e-5a5c-bc333d7cd4c5.htm
---
# Autodesk.Revit.DB.Parameter.Definition Property

**中文**: 参数、共享参数

Returns the Definition object that describes the data type, name and other details of the
parameter.

## Syntax (C#)
```csharp
public Definition Definition { get; }
```

## Remarks
This will always be an InternalDefinition object. 
If you want the Guid for a shared parameter, use GUID .

