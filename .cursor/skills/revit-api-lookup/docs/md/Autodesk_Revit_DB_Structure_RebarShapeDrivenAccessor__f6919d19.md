---
kind: type
id: T:Autodesk.Revit.DB.Structure.RebarShapeDrivenAccessor
source: html/6d2f77e7-bbe2-5bd5-723a-bf27c3df1a65.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeDrivenAccessor

A class that is used to access the properties and capabilities of shape-driven Rebar.

## Syntax (C#)
```csharp
public class RebarShapeDrivenAccessor : IDisposable
```

## Remarks
Obtain an instance of this class from GetShapeDrivenAccessor () () () .
 The accessor includes a reference to the Rebar element.
 If the referenced Rebar element is deleted, using the methods form this class will throw exception.

