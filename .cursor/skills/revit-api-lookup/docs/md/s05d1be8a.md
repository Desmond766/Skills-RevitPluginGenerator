---
kind: type
id: T:Autodesk.Revit.DB.IFC.IFCTransformSetter
source: html/75b9525d-3b8d-70d8-55de-a193b9eb5e76.htm
---
# Autodesk.Revit.DB.IFC.IFCTransformSetter

A state-based class that forces an extra transformation applied to objects being exported.

## Syntax (C#)
```csharp
public class IFCTransformSetter : IDisposable
```

## Remarks
IFC has a system of local placements; these are created from a set of transforms in Revit.
 Sometimes there is a need to create a 'fake' transform to get the right local placement structure for IFC.
 This class is intended to maintain the transformation for the duration that it is needed.
 To ensure that the lifetime of the object is correctly managed, you should declare an instance
 of this class as a part of a 'using' statement in C# or
 similar construct in other lanuguages.

