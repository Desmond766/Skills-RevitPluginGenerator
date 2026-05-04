---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarBarType.GetAutoCalcHookLengths(Autodesk.Revit.DB.ElementId)
source: html/d31c3a4a-7ba2-0ed8-db11-65fa480c6f45.htm
---
# Autodesk.Revit.DB.Structure.RebarBarType.GetAutoCalcHookLengths Method

Identifies if the hook lengths of a hook type are automatically calculated for this bar type

## Syntax (C#)
```csharp
public bool GetAutoCalcHookLengths(
	ElementId hookId
)
```

## Parameters
- **hookId** (`Autodesk.Revit.DB.ElementId`) - id of the hook type

## Returns
True if the hook lengths are automatically calculated, otherwise false

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

