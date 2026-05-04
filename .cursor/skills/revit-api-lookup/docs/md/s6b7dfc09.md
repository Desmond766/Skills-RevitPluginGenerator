---
kind: method
id: M:Autodesk.Revit.DB.AssemblyInstance.PlaceInstance(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.XYZ)
source: html/3b78e1fa-58d2-2e47-9955-78646763fdd0.htm
---
# Autodesk.Revit.DB.AssemblyInstance.PlaceInstance Method

Places an assembly instance of a given assembly type at the specified location.

## Syntax (C#)
```csharp
public static AssemblyInstance PlaceInstance(
	Document document,
	ElementId assemblyTypeId,
	XYZ location
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document for the new assembly instance.
- **assemblyTypeId** (`Autodesk.Revit.DB.ElementId`) - The id of the assembly type to be used for the instance.
- **location** (`Autodesk.Revit.DB.XYZ`) - The placement location for the instance in project coordinates.

## Returns
The newly created assembly instance.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

