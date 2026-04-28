---
kind: method
id: M:Autodesk.Revit.DB.IFC.IFCExtrusionCreationData.SetLocalPlacement(Autodesk.Revit.DB.IFC.IFCAnyHandle)
source: html/0053794b-01e0-bc6e-ff1c-f78b16be0c71.htm
---
# Autodesk.Revit.DB.IFC.IFCExtrusionCreationData.SetLocalPlacement Method

Sets the data to reference an IfcLocalPlacement handle when creating the extrusion.
 Side effect: will set ReuseLocalPlacement to true.

## Syntax (C#)
```csharp
public void SetLocalPlacement(
	IFCAnyHandle localPlacement
)
```

## Parameters
- **localPlacement** (`Autodesk.Revit.DB.IFC.IFCAnyHandle`) - The IfcLocalPlacement handle.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

