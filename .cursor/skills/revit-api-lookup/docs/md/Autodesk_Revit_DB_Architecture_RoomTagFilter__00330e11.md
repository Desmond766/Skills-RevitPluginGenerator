---
kind: type
id: T:Autodesk.Revit.DB.Architecture.RoomTagFilter
source: html/24dc181b-f767-f32d-7ae4-2c41ff1ceba9.htm
---
# Autodesk.Revit.DB.Architecture.RoomTagFilter

A filter used to match room tags.

## Syntax (C#)
```csharp
public class RoomTagFilter : ElementSlowFilter
```

## Remarks
This filter is a slow filter, but it uses a quick filter to eliminate non-candidate elements
 before the elements are obtained and expanded. Therefore this filter does not have to be
 paired with another quick filter to minimize the number of Elements that are expanded.

