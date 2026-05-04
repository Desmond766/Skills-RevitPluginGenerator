---
kind: method
id: M:Autodesk.Revit.DB.FamilyManager.MakeNonReporting(Autodesk.Revit.DB.FamilyParameter)
source: html/c271cd56-7c6b-c1a1-c9fb-05bcd68604fc.htm
---
# Autodesk.Revit.DB.FamilyManager.MakeNonReporting Method

Set the reporting family parameter as a regular/driving parameter.

## Syntax (C#)
```csharp
public void MakeNonReporting(
	FamilyParameter familyParameter
)
```

## Parameters
- **familyParameter** (`Autodesk.Revit.DB.FamilyParameter`)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input argument-"familyParameter"-is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when attempting to make a parameter which is labeled to an arc length dimension non-reporting.

