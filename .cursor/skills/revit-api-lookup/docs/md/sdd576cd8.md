---
kind: property
id: P:Autodesk.Revit.DB.CurtainSystem.CurtainGrids
source: html/b19b2f13-c741-a233-34ba-26415acacce3.htm
---
# Autodesk.Revit.DB.CurtainSystem.CurtainGrids Property

Get all the CurtainGrid object of this CurtainSystem. Each CurtainGrid corresponds to one face.

## Syntax (C#)
```csharp
public CurtainGridSet CurtainGrids { get; }
```

## Returns
A CurtainGrid set will be returned if the operation succeeds. Nothing nullptr a null reference ( Nothing in Visual Basic) will be returned if the 
CurtainSystem doesn't include any CurtainGrid.

