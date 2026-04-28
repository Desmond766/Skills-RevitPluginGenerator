---
kind: method
id: M:Autodesk.Revit.DB.FamilyType.AsString(Autodesk.Revit.DB.FamilyParameter)
source: html/6cb7afb5-f59f-3d35-7dc2-2fa665a35183.htm
---
# Autodesk.Revit.DB.FamilyType.AsString Method

Provides access to the string contents of the given family parameter.

## Syntax (C#)
```csharp
public string AsString(
	FamilyParameter familyParameter
)
```

## Parameters
- **familyParameter** (`Autodesk.Revit.DB.FamilyParameter`)

## Returns
The string contained in the parameter. Returns Nothing nullptr a null reference ( Nothing in Visual Basic) if the storage type of the input
argument is not string type or this parameter has no value.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input argument-"familyParameter"-is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the input argument-"familyParameter"-is invalid,

