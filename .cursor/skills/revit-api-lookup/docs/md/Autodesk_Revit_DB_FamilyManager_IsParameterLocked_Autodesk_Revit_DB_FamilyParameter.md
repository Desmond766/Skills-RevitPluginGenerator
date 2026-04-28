---
kind: method
id: M:Autodesk.Revit.DB.FamilyManager.IsParameterLocked(Autodesk.Revit.DB.FamilyParameter)
source: html/b2b1deb8-e2c0-8f48-7b03-368ec43746c5.htm
---
# Autodesk.Revit.DB.FamilyManager.IsParameterLocked Method

For Conceptual Mass and Curtain Panel families,
indicate whether the specified dimension-driving
parameter is locked.

## Syntax (C#)
```csharp
public bool IsParameterLocked(
	FamilyParameter familyParameter
)
```

## Parameters
- **familyParameter** (`Autodesk.Revit.DB.FamilyParameter`)

## Returns
True if the parameter is lockable
and is locked; false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown if this family is not a Conceptual Mass or Curtain Panel family.

