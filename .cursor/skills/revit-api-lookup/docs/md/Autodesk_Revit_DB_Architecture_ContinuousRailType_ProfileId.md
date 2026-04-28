---
kind: property
id: P:Autodesk.Revit.DB.Architecture.ContinuousRailType.ProfileId
source: html/79f73965-9ca2-42d9-8473-b799a01bb961.htm
---
# Autodesk.Revit.DB.Architecture.ContinuousRailType.ProfileId Property

The id of the profile of the rail

## Syntax (C#)
```csharp
public ElementId ProfileId { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The profileId is neither a valid element id nor invalidElementId.
 -or-
 When setting this property: The profileId is not a valid profile symbol for continuous rail.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

