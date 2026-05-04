---
kind: method
id: M:Autodesk.Revit.DB.View.ShowActiveWorkPlane
zh: 视图
source: html/71eb322c-4781-2d86-1067-b6fe9648524f.htm
---
# Autodesk.Revit.DB.View.ShowActiveWorkPlane Method

**中文**: 视图

Show the active work plane of the view.

## Syntax (C#)
```csharp
public void ShowActiveWorkPlane()
```

## Remarks
If this method is invoked while the current work plane is hidden, only the outline of the updated work plane will be shown immediately. 
The updated sketch plane will be shown fully after the current transaction is committed. Therefore it is recommended the Add-On commits the transaction 
before performing UI operations (for example, PickPoint).

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when there is no active sketch plane, or when an error occurs during setting the sketch plane visibility.

