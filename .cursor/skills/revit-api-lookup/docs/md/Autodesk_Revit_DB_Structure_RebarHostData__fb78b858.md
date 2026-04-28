---
kind: type
id: T:Autodesk.Revit.DB.Structure.RebarHostData
source: html/2b39b172-ad0f-e1c6-99a4-3b828346200c.htm
---
# Autodesk.Revit.DB.Structure.RebarHostData

Interface to rebar-specific data stored in each valid rebar host element.

## Syntax (C#)
```csharp
public class RebarHostData : IDisposable
```

## Remarks
Rebar host elements keep track of the "exposed faces," those that are not completely
 concealed by another rebar host. Faces may be concealed by joins; for instance,
 the top face of a beam that supports a slab is concealed. Faces can also be concealed
 by adjacency; for instance, the bottom face of a column that is supported by a
 foundation. Each exposed face of a rebar host must have a valid CoverType associated
 with it. Rebar hosts also have cover parameters, providing a limited interface
 to the GetCoverType and SetCoverType 
 methods.
 Each parameter simply gets or sets the cover setting associated with one or more
 particular faces of the host. CLEAR_COVER_EXTERIOR (walls only) CLEAR_COVER_INTERIOR (walls only) CLEAR_COVER_OTHER (all hosts except in-place families and stairs) CLEAR_COVER (in-place families and stairs) CLEAR_COVER_TOP (all hosts except walls, in-place families, and stairs) CLEAR_COVER_BOTTOM (all hosts except walls, in-place families, and stairs)

