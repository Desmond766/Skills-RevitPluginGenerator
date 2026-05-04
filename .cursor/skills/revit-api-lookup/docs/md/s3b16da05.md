---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarBarType.SetHookTangentLength(Autodesk.Revit.DB.ElementId,System.Double)
source: html/4c4ba82f-3645-13bd-1e3e-233f9b9c13b5.htm
---
# Autodesk.Revit.DB.Structure.RebarBarType.SetHookTangentLength Method

Identifies the hook tangent length for a hook type

## Syntax (C#)
```csharp
public void SetHookTangentLength(
	ElementId hookId,
	double newLength
)
```

## Parameters
- **hookId** (`Autodesk.Revit.DB.ElementId`) - id of the hook type
- **newLength** (`System.Double`) - The hook tangent length for a hook type

## Remarks
AutoCalcHookLengths is ignored when this property is set

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - the rebar hook type id hookId is not valid
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

