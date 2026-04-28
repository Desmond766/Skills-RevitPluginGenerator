---
kind: property
id: P:Autodesk.Revit.DB.WallSweepInfo.ProfileId
source: html/cb72ef85-5bb7-a89b-f054-8af475455958.htm
---
# Autodesk.Revit.DB.WallSweepInfo.ProfileId Property

The element id of the profile family used to create the sweep or reveal.

## Syntax (C#)
```csharp
public ElementId ProfileId { get; set; }
```

## Remarks
This value is not used when creating standalone wall sweeps. The profile id of the
 wall sweep's type is used instead.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

