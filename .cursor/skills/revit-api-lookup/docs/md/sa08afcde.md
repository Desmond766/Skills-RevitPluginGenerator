---
kind: type
id: T:Autodesk.Revit.DB.Architecture.RoomFilter
source: html/356881b1-5ee4-621a-0379-965c3e6f6dcf.htm
---
# Autodesk.Revit.DB.Architecture.RoomFilter

A filter used to match rooms.

## Syntax (C#)
```csharp
public class RoomFilter : ElementSlowFilter
```

## Remarks
This filter is a slow filter, but it uses a quick filter to eliminate non-candidate elements
 before the elements are obtained and expanded. Therefore this filter does not have to be
 paired with another quick filter to minimize the number of Elements that are expanded.

