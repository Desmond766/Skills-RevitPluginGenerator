---
kind: method
id: M:Autodesk.Revit.DB.FamilyManager.SetParameterLocked(Autodesk.Revit.DB.FamilyParameter,System.Boolean)
source: html/9ee4b404-c9e9-7d52-389a-a5fa21eae2e5.htm
---
# Autodesk.Revit.DB.FamilyManager.SetParameterLocked Method

For Conceptual Mass and Curtain Panel families,
lock or unlock a dimension-driving
parameter.

## Syntax (C#)
```csharp
public void SetParameterLocked(
	FamilyParameter familyParameter,
	bool locked
)
```

## Parameters
- **familyParameter** (`Autodesk.Revit.DB.FamilyParameter`)
- **locked** (`System.Boolean`)

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown if this family is not a Conceptual Mass or
Curtain Panel family.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the parameter is not lockable.

