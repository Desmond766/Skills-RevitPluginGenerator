---
kind: method
id: M:Autodesk.Revit.DB.FamilyManager.DeleteCurrentType
source: html/9ba3e824-e354-943b-141c-89b5c5e8cea2.htm
---
# Autodesk.Revit.DB.FamilyManager.DeleteCurrentType Method

Remove the current family type.

## Syntax (C#)
```csharp
public void DeleteCurrentType()
```

## Remarks
If successfully removed, the first available type will become the current type,
otherwise an exception with failure information will be thrown.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when there is only one family type in current document.

