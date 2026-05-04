---
kind: method
id: M:Autodesk.Revit.DB.IFC.IFCProductWrapper.AddSpace(Autodesk.Revit.DB.IFC.IFCAnyHandle,Autodesk.Revit.DB.IFC.IFCLevelInfo,Autodesk.Revit.DB.IFC.IFCExtrusionCreationData,System.Boolean)
source: html/1b6b85a0-b51e-9f82-cfa7-6db4cda9f884.htm
---
# Autodesk.Revit.DB.IFC.IFCProductWrapper.AddSpace Method

Adds an IfcSpace handle to associate with the IfcProduct in this wrapper.

## Syntax (C#)
```csharp
public void AddSpace(
	IFCAnyHandle spaceHandle,
	IFCLevelInfo pLevelInfo,
	IFCExtrusionCreationData pParams,
	bool relateToLevel
)
```

## Parameters
- **spaceHandle** (`Autodesk.Revit.DB.IFC.IFCAnyHandle`) - The IfcSpace handle.
- **pLevelInfo** (`Autodesk.Revit.DB.IFC.IFCLevelInfo`) - Information on the associated level.
- **pParams** (`Autodesk.Revit.DB.IFC.IFCExtrusionCreationData`) - The extrusion creation data associated with the given space. Optional, can be Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **relateToLevel** (`System.Boolean`) - True to relate the space to the level, false otherwise.

## Remarks
If the IFCLevelInfo is not provided, and relateToLevel to true, the handle will be associated to the building handle.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

