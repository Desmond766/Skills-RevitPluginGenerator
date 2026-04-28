---
kind: type
id: T:Autodesk.Revit.DB.Mechanical.MEPSection
source: html/a618b793-4084-a631-191a-043aac84d039.htm
---
# Autodesk.Revit.DB.Mechanical.MEPSection

A section in the Autodesk Revit MEP product.

## Syntax (C#)
```csharp
public class MEPSection : IDisposable
```

## Remarks
This is the base class for duct and pipe section.
 This class is mainly for pressure loss calculation.
 It is a series of connected elements (segments - ducts or pipes, fittings, terminals and accessories).
 All section members should have same flow analysis properties: Flow, Size, Velocity, Friction and Roughness.
 One section member element which contains more than one connector can belongs to multiple section.
 e.g.: One Tee which has 3 connectors, usually, it belongs 3 sections.
 One segment which connect to a tap will be divided into 2 sections.

