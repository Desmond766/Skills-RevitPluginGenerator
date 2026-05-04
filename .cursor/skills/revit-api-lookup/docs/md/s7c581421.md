---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarBarType.SetHookLength(Autodesk.Revit.DB.ElementId,System.Double)
source: html/d8a83bf6-d0ad-4bb2-d5b2-c7b026a4d4de.htm
---
# Autodesk.Revit.DB.Structure.RebarBarType.SetHookLength Method

Identifies the hook length for a hook type

## Syntax (C#)
```csharp
public void SetHookLength(
	ElementId hookId,
	double hookLength
)
```

## Parameters
- **hookId** (`Autodesk.Revit.DB.ElementId`) - id of the hook type
- **hookLength** (`System.Double`) - The hook length for a hook type

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - the rebar hook type id hookId is not valid
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

