---
kind: method
id: M:Autodesk.Revit.DB.IFC.ImporterIFC.ProcessIFCProject(Autodesk.Revit.DB.IFC.IFCAnyHandle)
source: html/5c81eabb-0622-f97b-fe4c-8fae55f6ff68.htm
---
# Autodesk.Revit.DB.IFC.ImporterIFC.ProcessIFCProject Method

The entry point to the native IFC import function. Processes the main IfcProject and creates appropriate Revit elements.

## Syntax (C#)
```csharp
public void ProcessIFCProject(
	IFCAnyHandle ifcProject
)
```

## Parameters
- **ifcProject** (`Autodesk.Revit.DB.IFC.IFCAnyHandle`) - The IfcProject containing the entities in the IFC file.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

