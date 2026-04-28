---
kind: method
id: M:Autodesk.Revit.DB.ParameterValue.IsEqual(Autodesk.Revit.DB.ParameterValue)
source: html/561e8901-0ee7-2ff8-5ffa-d0397ca0b3c0.htm
---
# Autodesk.Revit.DB.ParameterValue.IsEqual Method

Tests equality with another instance of the same class.

## Syntax (C#)
```csharp
public bool IsEqual(
	ParameterValue other
)
```

## Parameters
- **other** (`Autodesk.Revit.DB.ParameterValue`) - The instance to compare with

## Remarks
The result is always False if the two comparands are of a different value types.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

