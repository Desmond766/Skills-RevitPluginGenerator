---
kind: property
id: P:Autodesk.Revit.DB.Architecture.Railing.HostId
zh: 栏杆
source: html/4fe4b0e6-591d-70d1-10f7-e192393fae26.htm
---
# Autodesk.Revit.DB.Architecture.Railing.HostId Property

**中文**: 栏杆

The host of the railing.

## Syntax (C#)
```csharp
public ElementId HostId { get; set; }
```

## Remarks
If the host will be a Stairs in MultistoryStairs element, use [M:Autodesk.Revit.DB.Architecture.Railing.SetMultistoryStairsPlacementLevels(System.Collections.Generic.ISet`1{Autodesk.Revit.DB.ElementId})] to set the base levels of the stairs where the railing should be placed.
If %hostId% is the id of a Stairs Component (Run or Landing), it means that the Railing will be hosted by the Stairs element but railing adjustment to the stairs will start from the Component.
 If a stairs id is set as a host, the lowest stairs component below or above the railing sketch will be chosen as the host instead.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The hostId is not a valid railing host.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

