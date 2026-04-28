---
kind: type
id: T:Autodesk.Revit.DB.ReferenceWithContext
source: html/fccc2688-a00f-9e3a-26bf-f6d04a58c56c.htm
---
# Autodesk.Revit.DB.ReferenceWithContext

An object including a reference to a geometric object and related context, as instance transform etc.

## Syntax (C#)
```csharp
public class ReferenceWithContext : IDisposable
```

## Remarks
The ReferenceWithContext is used as the returned value from the method [!:Autodesk::Revit::DB::Document::FindReferencesWithContextByDirection] ,
 ReferenceIntersector.Find(XYZ, XYZ), or ReferenceIntersector.FindNearest(XYZ, XYZ).
 It includes a reference intersecting a line extended in a certain direction from an origin point and the context of the geometric object, as
 the transform and proximity.

