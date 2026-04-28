---
kind: type
id: T:Autodesk.Revit.DB.Structure.RebarBendData
source: html/027b5619-ad82-74b3-1d78-efe86a1ef96b.htm
---
# Autodesk.Revit.DB.Structure.RebarBendData

The values in this class provide a summary of information taken from the RebarBarType, RebarHookType, and RebarStyle.

## Syntax (C#)
```csharp
public class RebarBendData : IDisposable
```

## Remarks
The purpose of collecting the values in this class is to allow you to
 create and analyze an accurate representation of a RebarShape, without creating a Rebar
 instance, and without referring to RebarBarType, RebarHookType, and RebarStyle.
 If you do have a Rebar instance, its GetBendData() method will produce a RebarBendData
 object.

