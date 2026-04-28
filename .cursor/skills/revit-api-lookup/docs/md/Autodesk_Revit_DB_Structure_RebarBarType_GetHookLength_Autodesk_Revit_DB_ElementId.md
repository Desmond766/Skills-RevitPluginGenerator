---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarBarType.GetHookLength(Autodesk.Revit.DB.ElementId)
source: html/abcf48ad-052f-40bd-ee5f-b5d59d607123.htm
---
# Autodesk.Revit.DB.Structure.RebarBarType.GetHookLength Method

Identifies the hook length for a hook type

## Syntax (C#)
```csharp
public double GetHookLength(
	ElementId hookId
)
```

## Parameters
- **hookId** (`Autodesk.Revit.DB.ElementId`) - id of the hook type

## Returns
The hook length for a hook type

## Remarks
If the AutoCalcHookLengths property is turned off, the default hook length will be returned

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - the rebar hook type id hookId is not valid
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

