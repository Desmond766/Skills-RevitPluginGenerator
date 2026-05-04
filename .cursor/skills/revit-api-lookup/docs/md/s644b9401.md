---
kind: method
id: M:Autodesk.Revit.DB.FamilyInstance.GetSweptProfile
zh: 族实例
source: html/9bc9e2db-5ef1-8264-1426-01f4a6081844.htm
---
# Autodesk.Revit.DB.FamilyInstance.GetSweptProfile Method

**中文**: 族实例

Gets the object that describes the profile that is swept along the driving curve for this instance.

## Syntax (C#)
```csharp
public SweptProfile GetSweptProfile()
```

## Returns
A swept profile.

## Exceptions
- **Autodesk.Revit.Exceptions.InapplicableDataException** - Thrown if this instance does not have a swept profile.

