---
kind: method
id: M:Autodesk.Revit.DB.FamilyManager.MakeReporting(Autodesk.Revit.DB.FamilyParameter)
source: html/a4ee2a95-1e8f-55e4-fb3b-3a926e7cf668.htm
---
# Autodesk.Revit.DB.FamilyManager.MakeReporting Method

Set the family parameter as a reporting parameter.

## Syntax (C#)
```csharp
public void MakeReporting(
	FamilyParameter familyParameter
)
```

## Parameters
- **familyParameter** (`Autodesk.Revit.DB.FamilyParameter`)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input argument-"familyParameter"-is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the parameter can not be changed to a reporting parameter.

