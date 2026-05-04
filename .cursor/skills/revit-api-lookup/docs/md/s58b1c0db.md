---
kind: method
id: M:Autodesk.Revit.DB.IFC.IFCProductWrapper.AddElement(Autodesk.Revit.DB.IFC.IFCAnyHandle,Autodesk.Revit.DB.IFC.IFCLevelInfo,Autodesk.Revit.DB.IFC.IFCExtrusionCreationData,System.Boolean)
source: html/390959ad-cb5f-d6d9-f7a9-7c926f88edd5.htm
---
# Autodesk.Revit.DB.IFC.IFCProductWrapper.AddElement Method

Adds an IfcElement handle to associate with the IfcProduct in this wrapper.

## Syntax (C#)
```csharp
public void AddElement(
	IFCAnyHandle elementHandle,
	IFCLevelInfo pLevelInfo,
	IFCExtrusionCreationData params,
	bool relateToLevel
)
```

## Parameters
- **elementHandle** (`Autodesk.Revit.DB.IFC.IFCAnyHandle`) - The IfcElement handle.
- **pLevelInfo** (`Autodesk.Revit.DB.IFC.IFCLevelInfo`) - The level info.
- **params** (`Autodesk.Revit.DB.IFC.IFCExtrusionCreationData`) - The extrusion creation data associated with the given element. Optional, can be Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **relateToLevel** (`System.Boolean`) - True to relate the element to the level, false otherwise.

## Remarks
If the IFCLevelInfo is not provided, and relateToLevel to true, the handle will be associated to the building handle.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

