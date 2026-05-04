---
kind: type
id: T:Autodesk.Revit.DB.BarTypeDiameterOptions
source: html/a4f6aef6-f961-7b77-7c4b-6248193c258a.htm
---
# Autodesk.Revit.DB.BarTypeDiameterOptions

This class stores the diameter information from the RebarBarType.

## Syntax (C#)
```csharp
public class BarTypeDiameterOptions : IDisposable
```

## Remarks
This class can be used to create a whole new set of diameter values for a RebarBarType.
 It can be used when copying the diameter information as a bulk of data from a RebarBarType to another.
 The new diameters can be set in the RebarBarType in the following way:
 1. Create a BarTypeDiameterOptions object with the new diameters.
 2. Set the new diameters in RebarBarType using [!:Autodesk::Revit::DB::Structure::RebarBarType::SetBarTypeDiameters(Autodesk::Revit::DB::BarTypeDiameterOptions ^diametersOpt)] .
 The method [!:Autodesk::Revit::DB::Structure::RebarBarType::SetBarTypeDiameters(Autodesk::Revit::DB::BarTypeDiameterOptions ^diametersOpt)] 
 is responsible for diameters validation.

