---
kind: type
id: T:Autodesk.Revit.DB.Analysis.MEPNetworkIterator
source: html/ef919819-8e7e-7729-5994-096e56dfe420.htm
---
# Autodesk.Revit.DB.Analysis.MEPNetworkIterator

An iterator to traverse the MEP analytical network.

## Syntax (C#)
```csharp
public class MEPNetworkIterator : IDisposable
```

## Remarks
The iterator will visit the entire MEP analytical network in the depth-first order. For evert next step,
 one analytical node and one analytical segment are typically visited. Sometimes an extra node is
 provided if the iteration reaches the end on one side and restarts at the previous intersect node.
 Also note that the start step may not contain any segment.

