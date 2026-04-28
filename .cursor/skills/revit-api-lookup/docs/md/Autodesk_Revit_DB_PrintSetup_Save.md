---
kind: method
id: M:Autodesk.Revit.DB.PrintSetup.Save
source: html/ef2cf0c5-fce2-6fba-f3a9-8e49b5cde845.htm
---
# Autodesk.Revit.DB.PrintSetup.Save Method

Save the changes for the current print setting.

## Syntax (C#)
```csharp
public bool Save()
```

## Returns
False if save operation fails, otherwise True.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the current print setting is In-Session
or the current print setting has not changed.

