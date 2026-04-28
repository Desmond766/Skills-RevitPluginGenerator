---
kind: method
id: M:Autodesk.Revit.DB.ViewSheetSetting.Delete
zh: 删除、移除
source: html/b58dedbe-d849-17ee-9d2a-be35b2214b18.htm
---
# Autodesk.Revit.DB.ViewSheetSetting.Delete Method

**中文**: 删除、移除

Delete the current view sheet set, and make the In-Session set as the current one.

## Syntax (C#)
```csharp
public bool Delete()
```

## Returns
False if Delete operation fails, otherwise True.

## Remarks
If the current view sheet set is In-Session, an InvalidOperationException
will be thrown.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the current view sheet set is In-Session.

