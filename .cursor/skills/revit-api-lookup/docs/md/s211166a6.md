---
kind: method
id: M:Autodesk.Revit.DB.IFC.IFCProductWrapper.AddAnnotation(Autodesk.Revit.DB.IFC.IFCAnyHandle,Autodesk.Revit.DB.IFC.IFCLevelInfo,System.Boolean)
source: html/81879d31-9d99-661c-5251-918c2e496677.htm
---
# Autodesk.Revit.DB.IFC.IFCProductWrapper.AddAnnotation Method

Adds an annotation handle to associate with the IfcProduct in this wrapper.

## Syntax (C#)
```csharp
public void AddAnnotation(
	IFCAnyHandle annoHnd,
	IFCLevelInfo levelInfo,
	bool relateToLevel
)
```

## Parameters
- **annoHnd** (`Autodesk.Revit.DB.IFC.IFCAnyHandle`) - The annotation handle.
- **levelInfo** (`Autodesk.Revit.DB.IFC.IFCLevelInfo`) - Information on the associated level. Optional, can be Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **relateToLevel** (`System.Boolean`) - True to relate the annotation to the level, false otherwise.

## Remarks
If the IFCLevelInfo is not provided, and relateToLevel to true, the handle will be associated to the building handle.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

