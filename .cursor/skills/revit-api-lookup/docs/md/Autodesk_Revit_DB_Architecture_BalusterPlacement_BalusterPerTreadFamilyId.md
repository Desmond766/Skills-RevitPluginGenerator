---
kind: property
id: P:Autodesk.Revit.DB.Architecture.BalusterPlacement.BalusterPerTreadFamilyId
source: html/eeb75390-9f5e-1ff8-6259-d454ec3e99e2.htm
---
# Autodesk.Revit.DB.Architecture.BalusterPlacement.BalusterPerTreadFamilyId Property

The id of baluster per tread family.

## Syntax (C#)
```csharp
public ElementId BalusterPerTreadFamilyId { get; set; }
```

## Remarks
The property defines a baluster family type which is used for creation of balusters on treads.
 The number of such balusters is set by "BalusterPerTreadNumber" property.
 It works only for stairs which have treads and have "UseBalusterPerTreadOnStairs" set.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The balusterPerTreadFamilyId doesn't refer to a valid baluster family.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

