---
kind: method
id: M:Autodesk.Revit.DB.ViewSheetSetting.Save
source: html/29c7297b-3a8c-e06d-1936-0e7b177608c6.htm
---
# Autodesk.Revit.DB.ViewSheetSetting.Save Method

Save the changes for the current view sheet set.

## Syntax (C#)
```csharp
public bool Save()
```

## Returns
False if save operation fails, otherwise True.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the current view sheet set is In-Session or the current view sheet set is unchanged.

