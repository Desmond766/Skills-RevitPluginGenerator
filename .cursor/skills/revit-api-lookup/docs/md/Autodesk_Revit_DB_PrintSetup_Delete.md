---
kind: method
id: M:Autodesk.Revit.DB.PrintSetup.Delete
zh: 删除、移除
source: html/8748eb34-b067-f058-1451-51eb342680ac.htm
---
# Autodesk.Revit.DB.PrintSetup.Delete Method

**中文**: 删除、移除

Delete the current print setting, and make the In-Session setting as the current one.

## Syntax (C#)
```csharp
public bool Delete()
```

## Returns
False if Delete operation fails, otherwise true.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the current print setting is In-Session.

