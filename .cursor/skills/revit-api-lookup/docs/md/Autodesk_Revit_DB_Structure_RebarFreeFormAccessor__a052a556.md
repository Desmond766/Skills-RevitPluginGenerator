---
kind: type
id: T:Autodesk.Revit.DB.Structure.RebarFreeFormAccessor
source: html/bf146aa3-f780-646e-c3cd-42e7a61d18e6.htm
---
# Autodesk.Revit.DB.Structure.RebarFreeFormAccessor

A class that is used to access the properties and capabilities of free-form Rebar.

## Syntax (C#)
```csharp
public class RebarFreeFormAccessor : IDisposable
```

## Remarks
Obtain an instance of this class from GetFreeFormAccessor () () () .
 The accessor includes a reference to the Rebar element.
 If the referenced Rebar element is deleted, using the methods form this class will throw exception.

