---
kind: method
id: M:Autodesk.Revit.DB.FamilyManager.IsParameterLockable(Autodesk.Revit.DB.FamilyParameter)
source: html/b0ab3d1e-01e7-dc91-373b-c14d396c1a3e.htm
---
# Autodesk.Revit.DB.FamilyManager.IsParameterLockable Method

For Conceptual Mass and Curtain Panel families,
indicate whether the specified parameter can be locked.

## Syntax (C#)
```csharp
public bool IsParameterLockable(
	FamilyParameter familyParameter
)
```

## Parameters
- **familyParameter** (`Autodesk.Revit.DB.FamilyParameter`)

## Returns
True if the family is a Conceptual Mass or Curtain
Panel Family and the parameter drives one or more
dimensions; false otherwise.

