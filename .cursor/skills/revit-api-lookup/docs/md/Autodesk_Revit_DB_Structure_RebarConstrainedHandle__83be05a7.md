---
kind: type
id: T:Autodesk.Revit.DB.Structure.RebarConstrainedHandle
source: html/08b4c4a3-3bb9-0801-9cc8-cd5420a306d9.htm
---
# Autodesk.Revit.DB.Structure.RebarConstrainedHandle

A class representing a handle on a Rebar that can be joined to a reference, such
 as a host Element's surface or cover, or another Rebar's handle.

## Syntax (C#)
```csharp
public class RebarConstrainedHandle : IDisposable
```

## Remarks
A rebar element's flexible geometry is controlled by several handles. The shape
 of the bar is controlled by a handle at each end of the bar (blue circle controls)
 and a handle each edge (blue triangle controls). Another handle is used to
 control the location of the plane in which the rebar lies. An additional handle
 controls the length of a set of rebar. RebarConstrainedHandles can only be constructed internally by Revit. They are
 available to the API by querying a rebar element's RebarConstraintsManager.

