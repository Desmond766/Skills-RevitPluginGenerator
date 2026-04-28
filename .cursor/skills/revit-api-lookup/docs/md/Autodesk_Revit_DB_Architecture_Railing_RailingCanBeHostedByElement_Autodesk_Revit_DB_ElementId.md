---
kind: method
id: M:Autodesk.Revit.DB.Architecture.Railing.RailingCanBeHostedByElement(Autodesk.Revit.DB.ElementId)
zh: 栏杆
source: html/7f73d2b0-b1ad-9070-4330-6c9d7f28a835.htm
---
# Autodesk.Revit.DB.Architecture.Railing.RailingCanBeHostedByElement Method

**中文**: 栏杆

Checks whether the specified element can be used as a host for the railing.
 The host can be:
 stairs stairs component ramp floor slab edge wall roof

## Syntax (C#)
```csharp
public bool RailingCanBeHostedByElement(
	ElementId hostId
)
```

## Parameters
- **hostId** (`Autodesk.Revit.DB.ElementId`) - Element id to check.

## Returns
True if the element can be used as host for the railing.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

