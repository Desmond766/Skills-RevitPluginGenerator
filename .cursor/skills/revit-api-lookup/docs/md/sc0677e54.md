---
kind: method
id: M:Autodesk.Revit.DB.Architecture.NonContinuousRailStructure.IsValidNonContinuousRailProfile(Autodesk.Revit.DB.ElementId)
source: html/6c2ad41d-bba5-3ecb-15d2-09c201727dc3.htm
---
# Autodesk.Revit.DB.Architecture.NonContinuousRailStructure.IsValidNonContinuousRailProfile Method

Checks whether the input id represents a profile which can be used as the profile of this non-continuous rail.

## Syntax (C#)
```csharp
public bool IsValidNonContinuousRailProfile(
	ElementId profileId
)
```

## Parameters
- **profileId** (`Autodesk.Revit.DB.ElementId`) - The profile Id to be checked.

## Returns
True if the ElementId refers to a valid NonContinuousRail profile, false otherwise.

## Remarks
InvalidElementId is considered a valid NonContinuousRail profile (the default profile).

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

