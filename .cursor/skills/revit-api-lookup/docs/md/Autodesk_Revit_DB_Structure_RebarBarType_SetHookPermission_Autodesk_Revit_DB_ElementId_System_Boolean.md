---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarBarType.SetHookPermission(Autodesk.Revit.DB.ElementId,System.Boolean)
source: html/7895d053-e52a-3c16-d39f-e1ae26d505e9.htm
---
# Autodesk.Revit.DB.Structure.RebarBarType.SetHookPermission Method

Identifies if a hook type is permitted for this bar type

## Syntax (C#)
```csharp
public void SetHookPermission(
	ElementId hookId,
	bool permission
)
```

## Parameters
- **hookId** (`Autodesk.Revit.DB.ElementId`) - id of the hook type
- **permission** (`System.Boolean`) - True if the hook type should be permitted for this bar type, otherwise false

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - the rebar hook type id hookId is not valid
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

