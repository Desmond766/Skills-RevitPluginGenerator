---
kind: property
id: P:Autodesk.Revit.DB.Connector.IsValidObject
zh: 连接件、接口
source: html/d363c1d1-0985-a1ba-7c1e-151bb3edad8a.htm
---
# Autodesk.Revit.DB.Connector.IsValidObject Property

**中文**: 连接件、接口

Specifies whether the .NET object represents a valid Revit entity.

## Syntax (C#)
```csharp
public bool IsValidObject { get; }
```

## Returns
True if the API object holds a valid Revit native object, false otherwise.

## Remarks
If the corresponding Revit native object is destroyed, or creation of the corresponding object is undone,
 a managed API object containing it is no longer valid. API methods cannot be called on invalidated wrapper objects.

