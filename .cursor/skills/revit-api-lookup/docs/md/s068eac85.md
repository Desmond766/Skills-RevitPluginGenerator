---
kind: type
id: T:Autodesk.Revit.DB.IFC.IFCExtrusionCreationData
source: html/9447a335-6861-0533-6896-e6ff1fd41761.htm
---
# Autodesk.Revit.DB.IFC.IFCExtrusionCreationData

A utility object that is used to pass information related to extrusion creation.

## Syntax (C#)
```csharp
public class IFCExtrusionCreationData : IDisposable
```

## Remarks
This class accepts input used to attempt to create an extrusion (possibly with openings) from Revit geometry.
 The output contains information about the created extrusion and its openings. The information set is used to
 generate properties for the extruded body and related opening elements in the IFC file.

