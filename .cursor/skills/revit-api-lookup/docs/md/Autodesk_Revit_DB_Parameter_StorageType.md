---
kind: property
id: P:Autodesk.Revit.DB.Parameter.StorageType
zh: 参数、共享参数
source: html/9315853a-9210-6111-acba-8bd53913eec2.htm
---
# Autodesk.Revit.DB.Parameter.StorageType Property

**中文**: 参数、共享参数

Describes the type that is used internally within the parameter to store its value.

## Syntax (C#)
```csharp
public StorageType StorageType { get; }
```

## Remarks
The property will return one of the following possibilities: String, Integer, Double
or ElementId. Based on the value of this property the correct access and set methods should be used
to retrieve and set the parameter's data value.

