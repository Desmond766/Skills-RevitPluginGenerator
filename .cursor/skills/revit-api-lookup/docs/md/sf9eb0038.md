---
kind: type
id: T:Autodesk.Revit.DB.LocationPoint
source: html/0a36b1c4-f112-38f6-7b14-d572ea11584b.htm
---
# Autodesk.Revit.DB.LocationPoint

Provides location functionality for all elements that have a single insertion point.

## Syntax (C#)
```csharp
public class LocationPoint : Location
```

## Remarks
The location point objects adds additional functionality to its base location object
class. This includes setting the elements location to a specific point and retrieving its
rotation around its insertion point. Inplace families do not have a single insertion point and therefore do not have meaningful LocationPoint data.

