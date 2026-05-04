---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarBarType.SetHookOffsetLength(Autodesk.Revit.DB.ElementId,System.Double)
source: html/5e40bac1-64af-fa65-8825-58730e036daa.htm
---
# Autodesk.Revit.DB.Structure.RebarBarType.SetHookOffsetLength Method

Identifies the hook offset length for a hook type

## Syntax (C#)
```csharp
public void SetHookOffsetLength(
	ElementId hookId,
	double newLength
)
```

## Parameters
- **hookId** (`Autodesk.Revit.DB.ElementId`) - id of the hook type
- **newLength** (`System.Double`) - The hook offset length for a hook type

## Remarks
AutoCalcHookLengths is ignored when this property is set

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - the rebar hook type id hookId is not valid
 -or-
 the hook specified by id hookId doesn't have valid offset length
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

