---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarBarType.GetHookPermission(Autodesk.Revit.DB.ElementId)
source: html/bea2d183-cf94-dd90-97a0-04096f6c21a3.htm
---
# Autodesk.Revit.DB.Structure.RebarBarType.GetHookPermission Method

Identifies if a hook type is permitted for this bar type

## Syntax (C#)
```csharp
public bool GetHookPermission(
	ElementId hookId
)
```

## Parameters
- **hookId** (`Autodesk.Revit.DB.ElementId`) - id of the hook type

## Returns
True if the hook type is permitted for this bar type, otherwise false

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - the rebar hook type id hookId is not valid
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

