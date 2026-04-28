---
kind: property
id: P:Autodesk.Revit.DB.Architecture.NonContinuousRailInfo.ProfileId
source: html/d7125deb-176d-1ff7-5b36-ace635da5703.htm
---
# Autodesk.Revit.DB.Architecture.NonContinuousRailInfo.ProfileId Property

The profile id of the non-continuous rail, or invalidElementId if none.

## Syntax (C#)
```csharp
public ElementId ProfileId { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The profileId is not an Id of a valid NonContinuousRail profile.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

