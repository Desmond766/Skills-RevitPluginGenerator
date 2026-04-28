---
kind: method
id: M:Autodesk.Revit.DB.Parameter.GetUnitTypeId
zh: 参数、共享参数
source: html/fdcf8a82-e71b-ec72-4cd0-12e5de45517b.htm
---
# Autodesk.Revit.DB.Parameter.GetUnitTypeId Method

**中文**: 参数、共享参数

Gets the identifier of the unit quantifying the parameter value.

## Syntax (C#)
```csharp
public ForgeTypeId GetUnitTypeId()
```

## Returns
Identifier of the unit of the parameter.

## Remarks
The property only applies to parameters of value types.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown if this parameter is not of value type.

